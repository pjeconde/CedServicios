// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Permissive License.
// See http://www.microsoft.com/resources/sharedsource/licensingbasics/sharedsourcelicenses.mspx.
// All other rights reserved.


/// <reference name="MicrosoftAjax.debug.js" />
/// <reference name="MicrosoftAjaxTimer.debug.js" />
/// <reference name="MicrosoftAjaxWebForms.debug.js" />
/// <reference path="../ExtenderBase/BaseScripts.js" />
/// <reference path="../Common/Common.js" />


Type.registerNamespace('AjaxControlToolkit');

AjaxControlToolkit.TextBoxWatermarkBehavior = function(element) {
    /// <summary>
    /// The TextBoxWatermarkBehavior applies a watermark to a textbox
    /// </summary>
    /// <param name="element" type="Sys.UI.DomElement" domElement="true">
    /// Textbox associated with the behavior
    /// </param>
    AjaxControlToolkit.TextBoxWatermarkBehavior.initializeBase(this, [element]);
    
    // Properties
    this._watermarkText = null;
    this._watermarkCssClass = null;

    // Member variables
    this._focusHandler = null;
    this._blurHandler = null;
    this._keyPressHandler = null;
    this._propertyChangedHandler = null;
    this._watermarkChangedHandler = null;
    this._oldClassName = null;
    this._clearedForSubmit = null;
    this._maxLength = null;

    // Hook into the ASP.NET WebForm_OnSubmit function to clear watermarks prior to submission
    if ((typeof(WebForm_OnSubmit) == 'function') && !AjaxControlToolkit.TextBoxWatermarkBehavior._originalWebForm_OnSubmit) {
        AjaxControlToolkit.TextBoxWatermarkBehavior._originalWebForm_OnSubmit = WebForm_OnSubmit;
        WebForm_OnSubmit = AjaxControlToolkit.TextBoxWatermarkBehavior.WebForm_OnSubmit;
    }
}
AjaxControlToolkit.TextBoxWatermarkBehavior.prototype = {
    initialize : function() {
        /// <summary>
        /// Initialize the behavior
        /// </summary>
        AjaxControlToolkit.TextBoxWatermarkBehavior.callBaseMethod(this, 'initialize');

        var e = this.get_element();

        // Determine if this textbox is focused initially
        var hasInitialFocus = false;
        
        var clientState = AjaxControlToolkit.TextBoxWatermarkBehavior.callBaseMethod(this, 'get_ClientState');
        if (clientState != null && clientState != "") {
            hasInitialFocus = (clientState == "Focused");
            AjaxControlToolkit.TextBoxWatermarkBehavior.callBaseMethod(this, 'set_ClientState', null);
        }

        // Capture the initial style so we can toggle back and forth
        // between this and the watermarked style
        this._oldClassName = e.className;

        // Create delegates
        this._focusHandler = Function.createDelegate(this, this._onFocus);
        this._blurHandler = Function.createDelegate(this, this._onBlur);
        this._keyPressHandler = Function.createDelegate(this, this._onKeyPress);

        // Attach events
        $addHandler(e, 'focus', this._focusHandler);
        $addHandler(e, 'blur', this._blurHandler);
        $addHandler(e, 'keypress', this._keyPressHandler);

        this.registerPropertyChanged();

        // Initialize state and simulate a blur to apply the watermark if appropriate
        // Note: The comparison against _watermarkText is undesirable, but seemingly
        // necessary to support the load->Home->Back scenario in IE
        var currentValue = AjaxControlToolkit.TextBoxWrapper.get_Wrapper(this.get_element()).get_Current();
        var wrapper = AjaxControlToolkit.TextBoxWrapper.get_Wrapper(this.get_element());
        if (("" == currentValue) || (this._watermarkText == currentValue)) {
            wrapper.set_Watermark(this._watermarkText)
            wrapper.set_IsWatermarked(true);
        }
        if (hasInitialFocus) {
            this._onFocus();
        } else {
            e.blur();
            this._onBlur();
        }

        this._clearedForSubmit = false;

        this.registerPartialUpdateEvents();

        this._watermarkChangedHandler = Function.createDelegate(this, this._onWatermarkChanged);
        wrapper.add_WatermarkChanged(this._watermarkChangedHandler);
    },

    dispose : function() {
        /// <summary>
        /// Dispose the behavior
        /// </summary>
        var e = this.get_element();

        if (this._watermarkChangedHandler) {
            AjaxControlToolkit.TextBoxWrapper.get_Wrapper(this.get_element()).remove_WatermarkChanged(this._watermarkChangedHandler);
            this._watermarkChangedHandler = null;
        }

        // Unhook from Sys.Preview.UI.TextBox if present
        if(e.control && this._propertyChangedHandler) {
            e.control.remove_propertyChanged(this._propertyChangedHandler);
            this._propertyChangedHandler = null;
        }

        // Detach events
        if (this._focusHandler) {
            $removeHandler(e, 'focus', this._focusHandler);
            this._focusHandler = null;
        }
        if (this._blurHandler) {
            $removeHandler(e, 'blur', this._blurHandler);
            this._blurHandler = null;
        }
        if (this._keyPressHandler) {
            $removeHandler(e, 'keypress', this._keyPressHandler);
            this._keyPressHandler = null;
        }

        // Clear watermark text to avoid confusion during Refresh/Back/Forward
        if(AjaxControlToolkit.TextBoxWrapper.get_Wrapper(this.get_element()).get_IsWatermarked()) {
            this.clearText(false);
        }

        AjaxControlToolkit.TextBoxWatermarkBehavior.callBaseMethod(this, 'dispose');
    },

    _onWatermarkChanged : function(sender, eventArgs) {
        /// <summary>
        /// Handler invoked when the watermark changes
        /// </summary>
        /// <param name="sender" type="Object" mayBeNull="true"/>
        /// <param name="eventArgs" type="Sys.EventArgs" mayBeNull="true" />
        if (AjaxControlToolkit.TextBoxWrapper.get_Wrapper(this.get_element()).get_IsWatermarked()) {
            this._onBlur();
        } else {
            this._onFocus();
        }
    },

    clearText : function(focusing) {
        /// <summary>
        /// Clear the text from the target
        /// </summary>
        /// <param name="focusing" type="Boolean">
        /// Whether or not we are focusing on the textbox
        /// </param>
        var element = this.get_element();
        var wrapper = AjaxControlToolkit.TextBoxWrapper.get_Wrapper(element);
        wrapper.set_Value("");
        wrapper.set_IsWatermarked(false);
        if(focusing) {
            element.setAttribute("autocomplete","off");  // Avoid NS_ERROR_XPC_JS_THREW_STRING error in Firefox
            element.select();  // This fix displays the blinking cursor in a focused, empty text box in IE
        }
    },

    _onFocus : function(evt) {
        /// <summary>
        /// Handler for the textbox's focus event
        /// </summary>
        /// <param name="evt" type="Sys.UI.DomEvent">
        /// Event info
        /// </param>
        
        var e = this.get_element();
        if(AjaxControlToolkit.TextBoxWrapper.get_Wrapper(e).get_IsWatermarked()) {
            // Clear watermark
            this.clearText(evt ? true : false);
        }
        e.className = this._oldClassName;
        
        // Restore the MaxLength on the TextBox when we edit
        // the non-watermarked text
        if (this._maxLength > 0) {
            this.get_element().maxLength = this._maxLength;
            this._maxLength = null;
        }
    },

    _onBlur : function() {
        /// <summary>
        /// Handle the textbox's blur event
        /// </summary>
        var wrapper = AjaxControlToolkit.TextBoxWrapper.get_Wrapper(this.get_element());
        if(("" == wrapper.get_Current()) || wrapper.get_IsWatermarked()) {
            // Enlarge the TextBox's MaxLength if it's not big enough
            // to accomodate the watermark
            if (this.get_element().maxLength > 0 && this._watermarkText.length > this.get_element().maxLength) {
                this._maxLength = this.get_element().maxLength;
                this.get_element().maxLength = this._watermarkText.length;
            }
            
            this._applyWatermark();
        }
    },

    _applyWatermark : function() {
        /// <summary>
        /// Apply the watermark to the textbox
        /// </summary>
        var wrapper = AjaxControlToolkit.TextBoxWrapper.get_Wrapper(this.get_element());
        wrapper.set_Watermark(this._watermarkText);
        wrapper.set_IsWatermarked(true);
        if(this._watermarkCssClass) {
            this.get_element().className = this._watermarkCssClass;
        }
    },

    _onKeyPress : function() {
        /// <summary>
        /// Handle the textbox's keypress event
        /// </summary>
        AjaxControlToolkit.TextBoxWrapper.get_Wrapper(this.get_element()).set_IsWatermarked(false);
    },

    registerPropertyChanged : function() {
        /// <summary>
        /// Method called to hook up to Sys.Preview.UI.TextBox if present
        /// Note: This method must be called manually if the Sys.Preview.UI.TextBox
        ///       is added after the TextBoxWatermarkBehavior is initialized.
        /// </summary>

        var e = this.get_element();
        if(e.control && !this._propertyChangedHandler) {
            this._propertyChangedHandler = Function.createDelegate(this, this._onPropertyChanged);
            e.control.add_propertyChanged(this._propertyChangedHandler);
        }
    },

    _onPropertyChanged : function(sender, propertyChangedEventArgs) {
        /// <summary>
        /// Handler called automatically when a property change event is fired
        /// </summary>
        /// <param name="sender" type="Object">
        /// Sender
        /// </param>
        /// <param name="propertyChangedEventArgs" type="Sys.PropertyChangedEventArgs">
        /// Event arguments
        /// </param>
        if("text" == propertyChangedEventArgs.get_propertyName()) {
            this.set_Value(AjaxControlToolkit.TextBoxWrapper.get_Wrapper(this.get_element()).get_Current());
        }
    },

    _onSubmit : function() {
        /// <summary>
        /// Handler Called automatically when a submit happens to clear the watermark before posting back
        /// </summary>
        if(AjaxControlToolkit.TextBoxWrapper.get_Wrapper(this.get_element()).get_IsWatermarked()) {
            // Clear watermark text before page is submitted
            this.clearText(false);
            this._clearedForSubmit = true;
        }
    },

    _partialUpdateEndRequest : function(sender, endRequestEventArgs) {
        /// <summary>
        /// Handler Called automatically when a partial postback ends
        /// </summary>
        /// <param name="sender" type="Object">
        /// Sender
        /// </param>
        /// <param name="endRequestEventArgs" type="Sys.WebForms.EndRequestEventArgs">
        /// Event arguments
        /// </param>
        AjaxControlToolkit.TextBoxWatermarkBehavior.callBaseMethod(this, '_partialUpdateEndRequest', [sender, endRequestEventArgs]);

        if (this.get_element() && this._clearedForSubmit) {
            // Restore the cleared watermark (useful when the submit was wrapped in an UpdatePanel)
            this.get_element().blur();
            this._onBlur();
            this._clearedForSubmit = false;
        }
    },

    get_WatermarkText : function() {
        /// <value type="String">
        /// The text to show when the control has no value
        /// </value>
        return this._watermarkText;
    },
    set_WatermarkText : function(value) {
        if (this._watermarkText != value) {
            this._watermarkText = value;
            if (AjaxControlToolkit.TextBoxWrapper.get_Wrapper(this.get_element()).get_IsWatermarked()) {
                this._applyWatermark();
            }
            this.raisePropertyChanged('WatermarkText');
        }
    },

    get_WatermarkCssClass : function() {
        /// <value type="String">
        /// The CSS class to apply to the TextBox when it has no value (e.g. the watermark text is shown).
        /// </value>
        return this._watermarkCssClass;
    },
    set_WatermarkCssClass : function(value) {
        if (this._watermarkCssClass != value) {
            this._watermarkCssClass = value;
            if (AjaxControlToolkit.TextBoxWrapper.get_Wrapper(this.get_element()).get_IsWatermarked()) {
                this._applyWatermark();
            }
            this.raisePropertyChanged('WatermarkCssClass');
        }
    },

    get_Text : function() {
        /// <value type="String">
        /// Wrapper for the textbox's text that will ignore or create the watermark as appropriate
        /// </value>
        return AjaxControlToolkit.TextBoxWrapper.get_Wrapper(this.get_element()).get_Value();
    },
    set_Text : function(value) {
        if ("" == value) {
            AjaxControlToolkit.TextBoxWrapper.get_Wrapper(this.get_element()).set_Current("");
            this.get_element().blur();
            this._onBlur();  // onBlur needs to see ""
        } else {
            this._onFocus();  // onFocus sets ""
            AjaxControlToolkit.TextBoxWrapper.get_Wrapper(this.get_element()).set_Current(value);
        }
    }
}
AjaxControlToolkit.TextBoxWatermarkBehavior.registerClass('AjaxControlToolkit.TextBoxWatermarkBehavior', AjaxControlToolkit.BehaviorBase);

AjaxControlToolkit.TextBoxWatermarkBehavior.WebForm_OnSubmit = function() {
    /// <summary>
    /// Wraps ASP.NET's WebForm_OnSubmit in order to strip all watermarks prior to submission
    /// </summary>
    /// <returns type="Boolean">
    /// Result of original WebForm_OnSubmit
    /// </returns>
    var result = AjaxControlToolkit.TextBoxWatermarkBehavior._originalWebForm_OnSubmit();
    if (result) {
        var components = Sys.Application.getComponents();
        for(var i = 0 ; i < components.length ; i++) {
            var component = components[i];
            if (AjaxControlToolkit.TextBoxWatermarkBehavior.isInstanceOfType(component)) {
                component._onSubmit();
            }
        }
    }
    return result;
}
