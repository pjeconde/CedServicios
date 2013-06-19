// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Permissive License.
// See http://www.microsoft.com/resources/sharedsource/licensingbasics/sharedsourcelicenses.mspx.
// All other rights reserved.


/// <reference name="MicrosoftAjax.debug.js" />
/// <reference name="MicrosoftAjaxTimer.debug.js" />
/// <reference name="MicrosoftAjaxWebForms.debug.js" />
/// <reference path="../ExtenderBase/BaseScripts.js" />
/// <reference path="../Common/Common.js" />
/// <reference path="../DynamicPopulate/DynamicPopulateBehavior.js" />
/// <reference path="../Compat/Timer/Timer.js" />
/// <reference path="../Animation/Animations.js" />
/// <reference path="../Animation/AnimationBehavior.js" />
/// <reference path="../PopupExtender/PopupBehavior.js" />
/// <reference path="../PopupControl/PopupControlBehavior.js" />


// ListSearchExtender originally created by Damian Mehers http://damianblog.com
Type.registerNamespace('AjaxControlToolkit');

AjaxControlToolkit.ListSearchBehavior = function(element) {
    /// <summary>
    /// The ListSearchBehavior allows users to search incrementally within a Select
    /// </summary>
    /// <param name="element" type="Sys.UI.DomElement" domElement="true">
    /// Select associated with the behavior
    /// </param>

    AjaxControlToolkit.ListSearchBehavior.initializeBase(this, [element]);

    // Properties
    this._promptCssClass = null;
    this._promptText = AjaxControlToolkit.Resources.ListSearch_DefaultPrompt;
    this._offsetX = 0;
    this._offsetY = 0;
    this._promptPosition = AjaxControlToolkit.ListSearchPromptPosition.Top;
    this._raiseImmediateOnChange = false;
    this._queryPattern = AjaxControlToolkit.ListSearchQueryPattern.StartsWith;
    this._isSorted = false;


    // Variables
    this._popupBehavior = null;
    this._onShowJson = null;
    this._onHideJson = null;
    this._originalIndex = 0;    // Index of the selected option when a key is first hit (before it is changed by the browser)
    this._newIndex = -1;         // New index to which we want to move.   We need this because Firefox shifts the selected option even though we preventDefault and preventPropagation in _onKeyPress.
    this._showingPromptText = false;
    this._searchText = '';      // Actual search text (text displayed in the PromptDiv may be clipped)
    this._ellipsis = String.fromCharCode(0x2026);
    this._binarySearch = false;
    this._applicationLoadDelegate = null;
    this._focusIndex = 0;       // Selected Index when the list is initially given focus
    this._queryTimeout = 0;     // Timeout in milliseconds after which search text will be cleared
    this._timer = null;     // Holds the opaque ID returned by setTimeout function. Needed to correctly clear the timeout reference.
    this._matchFound = false;   // Set to true means an item was selected after searching. False means no item match search criteria

    this._focusHandler = null;
    this._blurHandler = null;
    this._keyDownHandler = null;
    this._keyUpHandler = null;
    this._keyPressHandler = null;
}

AjaxControlToolkit.ListSearchBehavior.prototype = {

    initialize : function() {
        /// <summary>
        /// Initialize the behavior
        /// </summary>

        AjaxControlToolkit.ListSearchBehavior.callBaseMethod(this, 'initialize');
        
        var element = this.get_element();
        
        // Check for a SELECT since a ControlAdapter could have rendered the ListBox or DropDown as something else
        if(element && element.tagName === 'SELECT') {

            this._focusHandler = Function.createDelegate(this, this._onFocus);
            this._blurHandler = Function.createDelegate(this, this._onBlur);
            this._keyDownHandler = Function.createDelegate(this, this._onKeyDown);
            this._keyUpHandler = Function.createDelegate(this, this._onKeyUp);
            this._keyPressHandler = Function.createDelegate(this, this._onKeyPress);

            $addHandler(element, "focus",     this._focusHandler);
            $addHandler(element, "blur",     this._blurHandler);
            $addHandler(element, "keydown",   this._keyDownHandler);
            $addHandler(element, "keyup",     this._keyUpHandler);
            $addHandler(element, "keypress",  this._keyPressHandler);

            // We use the load event to determine whether the control has focus and display prompt text.  We can't do it here.
            this._applicationLoadDelegate = Function.createDelegate(this, this._onApplicationLoad);
            Sys.Application.add_load(this._applicationLoadDelegate);
        }
    },
    
    dispose : function() {
        /// <summary>
        /// Dispose the behavior
        /// </summary>
        var element = this.get_element();
        $removeHandler(element, "keypress",  this._keyPressHandler);
        $removeHandler(element, "keyup",     this._keyUpHandler);
        $removeHandler(element, "keydown",   this._keyDownHandler);
        $removeHandler(element, "blur",      this._blurHandler);
        $removeHandler(element, "focus",     this._focusHandler);
        this._onShowJson = null;
        this._onHideJson = null;
        this._disposePopupBehavior();
        
        if(this._applicationLoadDelegate) {
            Sys.Application.remove_load(this._applicationLoadDelegate);
            this._applicationLoadDelegate = null;
        }
        
        if(this._timer) {
            this._stopTimer();
        }        

        AjaxControlToolkit.ListSearchBehavior.callBaseMethod(this, 'dispose');
    },

    _onApplicationLoad : function(sender, applicationLoadEventArgs) {
        /// <summary>
        /// Handler called automatically when a all scripts are loaded and controls are initialized
        /// Called after all scripts have been loaded and controls initialized.  If the current Select is the one that has
        /// focus then it shows the prompt text.  We cannot do this in the initialize method because the second pass initialization
        /// of the popup behavior hides it.
        /// </summary>
        /// <param name="sender" type="Object">
        /// Sender
        /// </param>
        /// <param name="applicationLoadEventArgs" type="Sys.ApplicationLoadEventArgs">
        /// Event arguments
        /// </param>

        // Determine if this SELECT is focused initially
        var hasInitialFocus = false;
        
        var clientState = AjaxControlToolkit.ListSearchBehavior.callBaseMethod(this, 'get_ClientState');
        if (clientState != null && clientState != "") {
            hasInitialFocus = (clientState === "Focused");
            AjaxControlToolkit.ListSearchBehavior.callBaseMethod(this, 'set_ClientState', null);
        }
        
        if(hasInitialFocus) {
            this._handleFocus();
        }
    },

    
   
    _checkIfSorted : function(options) {
        /// <summary>
        /// Checks to see if the list is sorted to see if we can do the fast binary search or the slower linear search
        /// </summary>
        /// <param name="options" type="Object">
        /// Collections of options in a SELECT
        /// </param>

        if (this._isSorted) {
            // we assume this is sorted
            return true;
        } else {
            // it is not known if elements list is sorted, so check it by itself
            var previousOptionValue = null;
            var optionsLength = options.length;
            for(var index = 0; index < optionsLength; index++) {
                var optionValue = options[index].text.toLowerCase();
                if(previousOptionValue && this._compareStrings(optionValue, previousOptionValue) < 0) {
                    return false;
                }
                previousOptionValue = optionValue;
            }
            return true;
        }
    },
    
    _onFocus : function(e) {
        /// <summary>
        /// Handler for the Select's focus event
        /// </summary>
        /// <param name="e" type="Sys.UI.DomEvent">
        /// Event info
        /// </param>
        this._handleFocus();
    },
    
    _handleFocus : function() {
        /// <summary>
        /// Utility method called when the form is loaded if the Select has the default focus, or when it is explicitly focused
        /// </summary>
        var element = this.get_element();
        this._focusIndex = element.selectedIndex;
        if(!this._promptDiv) {
            this._promptDiv = document.createElement('div');
            this._promptDiv.id = element.id + '_promptDiv';
        
            // Need to initialize _promptDiv here even though it is set below by _updatePromptDiv because otherwise both
            // FireFox and IE bomb -- I guess there needs to be some content in the Div.  We need a value, which will be overwritten
            // below anyway.
            this._promptDiv.innerHTML = this._promptText && this._promptText.length > 0 ? this._promptText : AjaxControlToolkit.Resources.ListSearch_DefaultPrompt;
            this._showingPromptText = true;
            
            if(this._promptCssClass) {
                this._promptDiv.className = this._promptCssClass;
            }
                    
            element.parentNode.insertBefore(this._promptDiv, element.nextSibling);
            this._promptDiv.style.overflow = 'hidden';
            this._promptDiv.style.height = this._promptDiv.offsetHeight + 'px';
            this._promptDiv.style.width = element.offsetWidth + 'px';
        }
        // Hook up a PopupBehavior to the promptDiv
        if(!this._popupBehavior) {
            this._popupBehavior = $create(AjaxControlToolkit.PopupBehavior, { parentElement : element }, {}, {}, this._promptDiv);
        }
        if (this._promptPosition && this._promptPosition == AjaxControlToolkit.ListSearchPromptPosition.Bottom) {
            this._popupBehavior.set_positioningMode(AjaxControlToolkit.PositioningMode.BottomLeft);
        } else {
            this._popupBehavior.set_positioningMode(AjaxControlToolkit.PositioningMode.TopLeft);
        }
        
        // Create the animations (if they were set before the behavior was created)
        if (this._onShowJson) {
            this._popupBehavior.set_onShow(this._onShowJson);
        }
        if (this._onHideJson) {
            this._popupBehavior.set_onHide(this._onHideJson);
        }
        
        this._popupBehavior.show();

        this._updatePromptDiv(this._promptText);
    },
    
    _onBlur : function() {
        /// <summary>
        /// Handle the Select's blur event
        /// </summary>
        this._disposePopupBehavior();

        // Remove the DIV showing the text typed so far
        var promptDiv = this._promptDiv;
        var element = this.get_element();

        if(promptDiv) {
           this._promptDiv = null;
           element.parentNode.removeChild(promptDiv);
        }
        
        if(!this._raiseImmediateOnChange && this._focusIndex != element.selectedIndex) {
            this._raiseOnChange(element);
        }        
    },
    
    _disposePopupBehavior : function() {
        /// <summary>
        /// Utilty function to dispose of the popup behavior, called when the Select loses focus or when the extender is being disposed
        /// </summary>
        if (this._popupBehavior) {
            this._popupBehavior.dispose();
            this._popupBehavior = null;
        }
    },
    
    _onKeyDown : function(e) {
        /// <summary>
        /// Handler for the Select's KeyDown event
        /// </summary>
        /// <param name="e" type="Sys.UI.DomEvent">
        /// Event info
        /// </param>

        var element = this.get_element();
        var promptDiv = this._promptDiv;
        
        if(!element || !promptDiv) {
            return;
        }
        
        this._originalIndex = element.selectedIndex;

        if(this._showingPromptText) {
            promptDiv.innerHTML = '';
            this._searchText = '';
            this._showingPromptText = false;
            this._binarySearch = this._checkIfSorted(element.options);   // Delayed until required
        }              

        // Backspace not passed to keyPressed event in IE, so handle it here
        if(e.keyCode == Sys.UI.Key.backspace) {
            e.preventDefault();
            e.stopPropagation();

            this._removeCharacterFromPromptDiv();
            this._searchForTypedText(element);
            
            if(!this._searchText || this._searchText.length == 0) {
                this._stopTimer();
            }
        } else if(e.keyCode == Sys.UI.Key.esc) {
            e.preventDefault();
            e.stopPropagation();

            promptDiv.innerHTML = '';
            this._searchText = '';
            this._searchForTypedText(element);
            
            this._stopTimer();
        } else if(e.keyCode == Sys.UI.Key.enter && !this._raiseImmediateOnChange && this._focusIndex != element.selectedIndex) {
            this._focusIndex = element.selectedIndex;   // So that OnChange is not fired again when the list loses focus
            this._raiseOnChange(element);
        }      
    },
    
    _onKeyUp : function(e) {
        /// <summary>
        /// Handler for the Select's KeyUp event.  We need this because Firefox shifts the selected option even though
        /// we preventDefault and preventPropagation in _onKeyPress
        /// </summary>
        /// <param name="e" type="Sys.UI.DomEvent">
        /// Event info
        /// </param>

        var element = this.get_element();
        var promptDiv = this._promptDiv;
        
        if(!element || !promptDiv) {
            return;
        }

        if(this._newIndex == -1 || !element || !promptDiv || promptDiv.innerHTML == '') {
            this._newIndex = -1;
            return;
        }
        
        element.selectedIndex = this._newIndex;
        this._newIndex = -1;
    },

    _onKeyPress : function(e) {
        /// <summary>
        /// Handler for the Select's KeyPress event.
        /// </summary>
        /// <param name="e" type="Sys.UI.DomEvent">
        /// Event info
        /// </param>

        var element = this.get_element();
        var promptDiv = this._promptDiv;
        
        if(!element || !promptDiv) {
            return;
        }
                
        if(!this._isNormalChar(e)) {
            if(e.charCode == Sys.UI.Key.backspace) {
                e.preventDefault();
                e.stopPropagation();
                
                if(this._searchText && this._searchText.length == 0) {
                    this._stopTimer();
                }                               
            }
            return;
        }
        
        e.preventDefault();
        e.stopPropagation();

        // Add key pressed to the displayed DIV and search for it
        this._addCharacterToPromptDiv(e.charCode);
        this._searchForTypedText(element);
        
        this._stopTimer();
        // start auto reset timer only if search text is not empty
        if(this._searchText && this._searchText.length != 0) {
            this._startTimer();
        }        
    },
    
    _isNormalChar : function(e) {
        /// <summary>
        /// Returns true if the specified charCode is a key rather than a normal (displayable) character
        /// </summary>
        /// <param name="e" type="Sys.UI.DomEvent">
        /// Event info
        /// </param>
        /// <returns type="Boolean" />

        // Walking through Sys.UI.Keys won't work -- Ampersand is code 38 which matches 
        if (Sys.Browser.agent == Sys.Browser.Firefox && e.rawEvent.keyCode) {
            return false;
        }

        if (Sys.Browser.agent == Sys.Browser.Opera && e.rawEvent.which == 0) {
            return false;
        }

        if (e.charCode && (e.charCode < Sys.UI.Key.space || e.charCode > 6000)) {
            return false;
        }
        return true;
    },

    _updatePromptDiv : function(newText) {
        /// <summary>
        /// Updates the text in the promptDiv.
        /// </summary>
        /// <param name="newText" type="String">
        /// The new text to be displayed in the promptDiv.  Optional.  If not specified then uses the _searchText member.
        /// </param>
        ///
        
        var promptDiv = this._promptDiv;
        if(!promptDiv || !this.get_element()) {
            return;
        }
                        
        var text = typeof(newText) === 'undefined' ? this._searchText : newText;
        var textNode = promptDiv.firstChild;
        
        if(!textNode) {
            textNode = document.createTextNode(text);
            promptDiv.appendChild(textNode);
        } else {
            textNode.nodeValue = text;
        }

        if(promptDiv.scrollWidth <= promptDiv.offsetWidth && promptDiv.scrollHeight <= promptDiv.offsetHeight) {
            return;  // Already fit
        }

        // Remove characters until they fit
        for(var maxFit = text.length - 1; maxFit > 0 && (promptDiv.scrollWidth > promptDiv.offsetWidth || promptDiv.scrollHeight > promptDiv.offsetHeight); maxFit--) {
            textNode.nodeValue = this._ellipsis + text.substring(text.length - maxFit, text.length);
        }
    },

    _addCharacterToPromptDiv : function (charCode) {
        /// <summary>
        /// Adds the specified character to the promptDiv.
        /// </summary>
        /// <param name="charCode" type="Int">
        /// The charCode of the character to be added
        /// </param>
        this._searchText += String.fromCharCode(charCode);
        this._updatePromptDiv();
    },

    _removeCharacterFromPromptDiv : function () {
        /// <summary>
        /// Removes a character from the end of the promptDiv.
        /// </summary>
        if(this._searchText && this._searchText != '') {
            this._searchText = this._searchText.substring(0, this._searchText.length - 1);
            this._updatePromptDiv();
        }
    },

    _searchForTypedText  : function(element) {
        /// <summary>
        /// Searches for the text typed so far in the Select
        /// </summary>
        /// <param name="element" type="Sys.UI.DomElement" domElement="true">
        /// Select associated with the behavior
        /// </param>
        var searchText = this._searchText;
        var options = element.options;
        var text = searchText ? searchText.toLowerCase() : "";
        
        this._matchFound = false;

        if(text.length == 0) {  // Probably hit delete -- select the first option
            if(options.length > 0) {
                element.selectedIndex = 0;
                this._newIndex = 0;
            }
        } else {
            var selectedIndex = -1;
                         
            if(this._binarySearch && (this._queryPattern == AjaxControlToolkit.ListSearchQueryPattern.StartsWith)) {
                selectedIndex = this._doBinarySearch(options, text, 0, options.length - 1);
            } else {
                selectedIndex = this._doLinearSearch(options, text, 0, options.length - 1);
            }
         
            // If nothing is found then stick with the current option
            if(selectedIndex == -1) {
                // Need this because firefox has aleady changed the current option based on the character typed
                this._newIndex = this._originalIndex; 
            } else {    // Otherwise move to the new option
                element.selectedIndex = selectedIndex;
                this._newIndex = selectedIndex;
                this._matchFound = true;
            }
        }
        
        if(this._raiseImmediateOnChange && this._originalIndex != element.selectedIndex) {
            // Fire an OnChange
            this._raiseOnChange(element);
        }
    },
    
    _raiseOnChange : function(element) {
        /// <summary>
        /// Fires a OnChange event
        /// </summary>
        /// <param name="element" type="Sys.UI.DomElement" domElement="true">
        /// Select associated with the behavior
        /// </param>
        if (document.createEvent) {
            var onchangeEvent = document.createEvent('HTMLEvents');
            onchangeEvent.initEvent('change', true, false);
            element.dispatchEvent(onchangeEvent);
        } else if( document.createEventObject ) {
            element.fireEvent('onchange');
        }
    },
    
    _compareStrings : function(strA, strB) {
        /// <summary>
        /// Compare two strings
        /// </summary>
        /// <param name="strA" type="String">
        /// The first string
        /// </param>
        /// <param name="strB" type="String">
        /// The second string
        /// </param>
        /// <returns type="Number" Integer="true">
        /// 0 if equal, -1 if strA < strB, 1 otherwise
        /// </returns>
        return ((strA == strB) ? 0 : ((strA < strB) ? -1 : 1))
    },
    
    _doBinarySearch : function(options, value, left, right) {
        /// <summary>
        /// Does a binary search for a value in the Select's options
        /// </summary>
        /// <param name="options" type="Object">
        /// The collection of options in the Select
        /// </param>
        /// <param name="value" type="String">
        /// The value being searched for
        /// </param>
        /// <param name="left" type="Int">
        /// The left bounds of the search
        /// </param>
        /// <param name="right" type="Right">
        /// The right bounds of the search
        /// </param>
        while (left <= right) {
            var mid = Math.floor((left+right)/2);
            var option = options[mid].text.toLowerCase().substring(0, value.length);
            var compareResult = this._compareStrings(value, option);
            if (compareResult > 0) {
                left = mid+1
            } else if(compareResult < 0) {
                right = mid-1;
            } else {
                // We've found a match, but it might not be the first -- do a linear search backwards
                while(mid > 0 && options[mid - 1].text.toLowerCase().startsWith(value)) {
                    mid--;
                }
                return mid;
            }
        }
        return -1;
    },
    
    _doLinearSearch : function(options, value, left, right) {
        /// <summary>
        /// Does a linear search for a value in the Select's options
        /// </summary>
        /// <param name="options" type="Object">
        /// The collection of options in the Select
        /// </param>
        /// <param name="value" type="String">
        /// The value being searched for
        /// </param>
        /// <param name="left" type="Int">
        /// The left bounds of the search
        /// </param>
        /// <param name="right" type="Right">
        /// The right bounds of the search
        /// </param>
        
        if (this._queryPattern == AjaxControlToolkit.ListSearchQueryPattern.Contains) {
            for(var i = left; i <= right; i++) {
                if(options[i].text.toLowerCase().indexOf(value) >= 0) {
                    return i;
                }
            }
        } else if (this._queryPattern == AjaxControlToolkit.ListSearchQueryPattern.StartsWith) {
            for(var i = left; i <= right; i++) {
                if(options[i].text.toLowerCase().startsWith(value)) {
                    return i;
                }
            }
        }

        return -1;
    },
    
    _onTimerTick : function() {
        /// <summary>
        /// On timer tick since user is not responsive, so reset search text if no match is found.
        /// </summary>    
        this._stopTimer();
      
        // reset search text only if no match was found        
        if (!this._matchFound) {
            this._searchText = '';
            this._updatePromptDiv();
        }
    },
    
    _startTimer : function() {
        /// <summary>
        /// Starts timer to monitor user interaction only if greater than zero.
        /// </summary>     
        if (this._queryTimeout > 0) {
            this._timer = window.setTimeout(Function.createDelegate(this, this._onTimerTick), this._queryTimeout);
        }
    },

    _stopTimer : function() {
        /// <summary>
        /// Stops and clears previously created timer.
        /// </summary>     
        if(this._timer != null) {
            window.clearTimeout(this._timer);
        }
        this._timer = null;
    },
    
    get_onShow : function() {
        /// <value type="String" mayBeNull="true">
        /// Generic OnShow Animation's JSON definition
        /// </value>
        return this._popupBehavior ? this._popupBehavior.get_onShow() : this._onShowJson;
    },
    set_onShow : function(value) {
        if (this._popupBehavior) {
            this._popupBehavior.set_onShow(value)
        } else {
            this._onShowJson = value;
        }
        this.raisePropertyChanged('onShow');
    },
    get_onShowBehavior : function() {
        /// <value type="AjaxControlToolkit.Animation.GenericAnimationBehavior">
        /// Generic OnShow Animation's behavior
        /// </value>
        return this._popupBehavior ? this._popupBehavior.get_onShowBehavior() : null;
    },
    onShow : function() {
        /// <summary>
        /// Play the OnShow animation
        /// </summary>
        /// <returns />
        if (this._popupBehavior) {
            this._popupBehavior.onShow();
        }
    },
    
    get_onHide : function() {
        /// <value type="String" mayBeNull="true">
        /// Generic OnHide Animation's JSON definition
        /// </value>
        return this._popupBehavior ? this._popupBehavior.get_onHide() : this._onHideJson;
    },
    set_onHide : function(value) {
        if (this._popupBehavior) {
            this._popupBehavior.set_onHide(value)
        } else {
            this._onHideJson = value;
        }
        this.raisePropertyChanged('onHide');
    },
    get_onHideBehavior : function() {
        /// <value type="AjaxControlToolkit.Animation.GenericAnimationBehavior">
        /// Generic OnHide Animation's behavior
        /// </value>
        return this._popupBehavior ? this._popupBehavior.get_onHideBehavior() : null;
    },
    onHide : function() {
        /// <summary>
        /// Play the OnHide animation
        /// </summary>
        /// <returns />
        if (this._popupBehavior) {
            this._popupBehavior.onHide();
        }
    },
    
    get_promptText : function() {
        /// <summary>
        /// The prompt text displayed when user clicks the list
        /// </summary>
        /// <value type="String" />
        return this._promptText;
    },              

    set_promptText : function(value) {
        if (this._promptText != value) {
            this._promptText = value;
            this.raisePropertyChanged('promptText');
        }
    },              

    get_promptCssClass : function() {
        /// <summary>
        /// CSS class applied to prompt when user clicks list.
        /// </summary>
        /// <value type="String" />
        return this._promptCssClass;
    },              

    set_promptCssClass : function(value) {
        if (this._promptCssClass != value) {
            this._promptCssClass = value;
            this.raisePropertyChanged('promptCssClass');
        }
    },

    get_promptPosition : function() {
        /// <value type="AjaxControlToolkit.ListSearchPromptPosition">
        /// Where the prompt should be positioned relative to the target control.
        /// Can be Top (default) or Bottom
        /// </value>
        return this._promptPosition;
    },

    set_promptPosition : function(value) {
        if (this._promptPosition != value) {
            this._promptPosition = value;
            this.raisePropertyChanged('promptPosition');
        }
    },

    get_raiseImmediateOnChange : function() {
        /// <summary>
        /// Boolean indicating whether an OnChange event should be fired as soon as the selected element
        /// is changed, or only when the list loses focus or the user hits enter.
        /// </summary>
        /// <value type="String" />
        return this._raiseImmediateOnChange;
    },

    set_raiseImmediateOnChange : function(value) {
        if (this._raiseImmediateOnChange != value) {
            this._raiseImmediateOnChange = value;
            this.raisePropertyChanged('raiseImmediateOnChange');
        }
    },
    
    get_queryTimeout : function() {
        /// <summary>
        /// Value indicating timeout in milliseconds after which search query will be cleared.
        /// Zero means no auto reset at all.
        /// </summary>
        /// <value type="Number" />    
        return this._queryTimeout;
    },

    set_queryTimeout : function(value) {
        if (this._queryTimeout != value) {
            this._queryTimeout = value;
            this.raisePropertyChanged('queryTimeout');    
        }
    },
    
    get_isSorted : function() {
        /// <value type="Boolean">
        /// When setting this to true, we instruct search routines that
        /// all values in List are already sorted on population,
        /// so binary search can be used if on StartsWith criteria is set.
        /// </value>
        return this._isSorted;
    },
    
    set_isSorted : function(value) {
        if (this._isSorted != value) {
            this._isSorted = value;
            this.raisePropertyChanged('isSorted');
        }
    },
    
    get_queryPattern : function() {
        /// <value type="AjaxControlToolkit.ListSearchQueryPattern">
        /// Search query pattern to be used to find items.
        /// Can be StartsWith (default) or Contains
        /// </value>
        return this._queryPattern;
    },

    set_queryPattern : function(value) {
        if (this._queryPattern != value) {
            this._queryPattern = value;
            this.raisePropertyChanged('queryPattern');
        }
    }    
}

AjaxControlToolkit.ListSearchBehavior.registerClass('AjaxControlToolkit.ListSearchBehavior', AjaxControlToolkit.BehaviorBase);

AjaxControlToolkit.ListSearchPromptPosition = function() {
    throw Error.invalidOperation();
}

AjaxControlToolkit.ListSearchPromptPosition.prototype = {
    Top: 0,
    Bottom: 1
}
AjaxControlToolkit.ListSearchPromptPosition.registerEnum('AjaxControlToolkit.ListSearchPromptPosition');

AjaxControlToolkit.ListSearchQueryPattern = function() {
    /// <summary>
    /// Choose what query pattern to use to search for matching words.
    /// </summary>
    /// <field name="StartsWith" type="Number" integer="true" />
    /// <field name="Contains" type="Number" integer="true" />
    throw Error.invalidOperation();
}

AjaxControlToolkit.ListSearchQueryPattern.prototype = {
    StartsWith: 0,
    Contains: 1
}
AjaxControlToolkit.ListSearchQueryPattern.registerEnum('AjaxControlToolkit.ListSearchQueryPattern');
