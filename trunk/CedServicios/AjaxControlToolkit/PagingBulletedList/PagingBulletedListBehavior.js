// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Permissive License.
// See http://www.microsoft.com/resources/sharedsource/licensingbasics/sharedsourcelicenses.mspx.
// All other rights reserved.


/// <reference name="MicrosoftAjax.debug.js" />
/// <reference name="MicrosoftAjaxTimer.debug.js" />
/// <reference name="MicrosoftAjaxWebForms.debug.js" />
/// <reference path="../ExtenderBase/BaseScripts.js" />


Type.registerNamespace('AjaxControlToolkit');

AjaxControlToolkit.PagingBulletedListBehavior = function(element) {
    /// <summary>
    /// The PagingBulletedListBehavior provides sorting and paging of a bulleted list
    /// </summary>
    /// <param name="element" type="Sys.UI.DomElement" domElement="true">
    /// DOM element the behavior is associated with
    /// </param>
    AjaxControlToolkit.PagingBulletedListBehavior.initializeBase(this, [element]);
    
    
    
    this._indexSizeValue =  1;
    this._separatorValue = ' - ';
    
    //From Server Componant
    this._heightValue = null;
    this._maxItemPerPage = null;
    this._clientSortValue = false;
    this._selectIndexCssClassValue = null;
    this._unselectIndexCssClassValue = null;
    

    
    // Local
    this._tabValue = new Array();
    this._tabValueObject =  new Array();
    this._tabIndex =  new Array();
    this._divContent = null;
    this._divContentIndex = null;
    this._divContentUl = null;
    this._prevIndexSelected = null;
    this._indexSelected = 0;
    
    // Event
    this._clickIndex = null;
    
}
AjaxControlToolkit.PagingBulletedListBehavior.prototype = {
    initialize : function() {
        /// <summary>
        /// Initialize the behavior
        /// </summary>
        AjaxControlToolkit.PagingBulletedListBehavior.callBaseMethod(this, 'initialize');
    
        // ClientState
        var clientState = this.get_ClientState();
        if (clientState){
            var stateItems = clientState.split(";");
            if (stateItems.length) {
               this._indexSelected = stateItems[0];
               if (stateItems[1] == "null")
                this._indexSizeValue = null;
               else
                this._indexSizeValue = stateItems[1];
               if (stateItems[2] == "null")
                this._maxItemPerPage = null;
               else
                this._maxItemPerPage = stateItems[2];
               if (stateItems[3] == "true"){
                 this._clientSortValue = true; 
               }else{
                 this._clientSortValue = false;
               }            
            }
        }    
    
        var e = this.get_element();
        //Div Content
        this._divContent = document.createElement('div');
        //insert Div
        e.parentNode.insertBefore(this._divContent, e);

        var liElements = e.childNodes;

        // Create the OnClick Index
        this._clickIndex = Function.createDelegate(this, this._onIndexClick);

        var inner;
        var index;

        this._divContentIndex = document.createElement('DIV');
        this._divContentIndex.style.marginBottom = '5px';
        this._divContent.appendChild(this._divContentIndex);

        //Extract LI elements in _tabValueObject
        for (var i = 0 ; i < liElements.length; i++) {
            if (liElements[i].nodeName == 'LI') {
	            if ((liElements[i].firstChild) && (liElements[i].firstChild.innerHTML)) {
	                inner = liElements[i].firstChild.innerHTML;
	            } else {
	                inner = liElements[i].innerHTML;
	            }
	            this._tabValueObject[this._tabValueObject.length] = {text : inner, obj : liElements[i], index : i};
	         }
        }
        
        //Sort if need
        if(this._clientSortValue) {
            this._tabValueObject.sort(this.liElementSortText);
        }
        
        //Generate Index and dispatch in TabIndex and TabValue
        this._generateIndexAndTabForView();
        
        //Remove LI
        this._removeChilds(e.childNodes);
        //Add DIV for Index
        this._divContentUl = document.createElement('DIV');
        
        //Height of DivContent
        this._changeHeightDivContent();
       
        //Re-insert LI
        this._divContentUl.appendChild(e);
        this._divContent.appendChild(this._divContentUl);
        
        this._updateIndexAndView(this._indexSelected);
    },
    
    _changeHeightDivContent : function() {
        /// <summary>
        /// Change the height of the list
        /// </summary>

        if (this._heightValue) {
            this._divContentUl.style.overflow = 'scroll';
            this._divContentUl.style.height = (this._heightValue) + 'px';
        } else {
            this._divContentUl.style.overflow = '';
            this._divContentUl.style.height = '';
        }
    },
    
    _createAHrefIndex : function(indexText, indexNumber) {
        /// <summary>
        /// Create an index and display it above the list
        /// </summary>
        /// <param name="indexText" type="String">
        /// Text of the index
        /// </param>
        /// <param name="indexNumber" type="Number" integer="true">
        /// Index
        /// </param>
        /// <returns type="Sys.UI.DomElement" domElement="true">
        /// Seperator element appended after the new index (so it can be removed later if last)
        /// </returns>

        var spanSeparator;
        var aIndex;
        //Create a for Index
        aIndex = document.createElement('a');
        aIndex.href = '';
        //Add _unSelectIndexCssClass by default
        Sys.UI.DomElement.addCssClass(aIndex, this._unselectIndexCssClassValue);
        aIndex.innerHTML = indexText;
        aIndex.tag = indexNumber;
        //Attach event
        $addHandler(aIndex, 'click',this._clickIndex);
        
        //Save a Object in _tabIndex
        this._tabIndex[this._tabIndex.length] = aIndex;
        this._divContentIndex.appendChild(aIndex);
        
        //Add SPAN
        spanSeparator = document.createElement('SPAN');
        //Add FEFF carater for not delete the first or last space 
        spanSeparator.innerHTML = '\uFEFF' + this._separatorValue + '\uFEFF';
        this._divContentIndex.appendChild(spanSeparator);
        
        //Return Separator for remove the last one
        return spanSeparator;
    },
    
    liElementSortText : function(x, y) {
        /// <summary>
        /// Sort function to compare two strings
        /// </summary>
        /// <param name="x" type="Object">
        /// Object (of the form {text, index})
        /// </param>
        /// <param name="y" type="Object">
        /// Object (of the form {text, index})
        /// </param>
        /// <returns type="Number" integer="true">
        /// -1 if the first is less than the second, 0 if they are equal, 1 if the first is greater than the second
        /// </returns>

        //Sort by text
        if (x.text.toLowerCase() == y.text.toLowerCase()) {
            return 0;
        } else {
            if (x.text.toLowerCase() < y.text.toLowerCase()) {
                return -1;
            } else {
                return 1;
            }
        }
     },
     
    liElementSortIndex : function(x, y) {
        /// <summary>
        /// Sort function to compare two indices
        /// </summary>
        /// <param name="x" type="Object">
        /// Object (of the form {text, index})
        /// </param>
        /// <param name="y" type="Object">
        /// Object (of the form {text, index})
        /// </param>
        /// <returns type="Number" integer="true">
        /// -1 if the first is less than the second, 0 if they are equal, 1 if the first is greater than the second
        /// </returns>

        //Sort by index (init order)
        return x.index - y.index;
     },
    
    _generateIndexAndTabForView : function() {
        /// <summary>
        /// Create the indices
        /// </summary>

        this._deleteTabIndexAndTabValue();
        this._tabValue = new Array();
        this._tabIndex = new Array();
        var lastSpanSeparator;
        
        this._removeChilds(this._divContentIndex.childNodes);
        //Cut array _tabValueObject in _tabValue with 1 dimension per 1 index
        if(this._maxItemPerPage) {
            //if _maxItemPerPage index generation become automatique
            if (this._maxItemPerPage > 0) {
                var j = -1;
                for(var i = 0; i < this._tabValueObject.length; i++) {
                    if((i % this._maxItemPerPage) == 0) {
                        j++;
                        index = this._tabValueObject[i].text;
                        this._tabValue[j] = new Array();
                        lastSpanSeparator = this._createAHrefIndex(index, j);
                    }
                    this._tabValue[j][this._tabValue[j].length] = this._tabValueObject[i].obj;
                }
            }
        } else {
            //if Generate index with _indexSizeValue
            if (this._indexSizeValue > 0) {
                var currentIndex = '';
                var j = -1;
                for(var i = 0; i < this._tabValueObject.length; i++) {
                    index = this._tabValueObject[i].text.substr(0, this._indexSizeValue).toUpperCase();
                    if (currentIndex != index) {
                        j++;
                        this._tabValue[j] = new Array();
                        lastSpanSeparator = this._createAHrefIndex(index, j);
                        currentIndex = index;
                    }
                    this._tabValue[j][this._tabValue[j].length] = this._tabValueObject[i].obj;
                }
            }
        }
        
	    //Remove last SpanSeparator
	    if (lastSpanSeparator) {
	        this._divContentIndex.removeChild(lastSpanSeparator);        
	    }
    },
    
    _deleteTabIndexAndTabValue : function() {
        /// <summary>
        /// Delete the indices
        /// </summary>

        //Remove Event
        if (this._clickIndex) {
            for(var i = 0; i < this._tabIndex.length; i++) {
                var aIndex = this._tabIndex[i];
                if(aIndex) {
                    $removeHandler(aIndex, 'click', this._clickIndex);
                }
            }
            this._changeHandler = null;
        }
        //Delete _tabIndex
        delete this._tabIndex;
        //Delete Dimention two _tabValue[x]
        for(var i = 0; i < this._tabValue.length; i++) {
            delete this._tabValue[i];
        }
        //Delete _tabValue
        delete this._tabValue;   
    },
    
    dispose : function() {
        /// <summary>
        /// Dispose the behavior
        /// </summary>
        this._deleteTabIndexAndTabValue();
        delete this._tabValueObject;
        AjaxControlToolkit.PagingBulletedListBehavior.callBaseMethod(this, 'dispose');
    },

    _removeChilds : function(eChilds) {
        /// <summary>
        /// Remove the children from their parent
        /// </summary>
        /// <param name="eChilds" type="Array" elementType="Sys.UI.DomElement" elementDomElement="true">
        /// Children to remove
        /// </param>
        for(var i = 0; eChilds.length; i++) {
            eChilds[0].parentNode.removeChild(eChilds[0]);
        }
    },
    
    _renderHtml : function(index) {
        /// <summary>
        /// Display the elements for the given index
        /// </summary>
        /// <param name="index" type="Number" integer="true">
        /// Index
        /// </param>

        var e = this.get_element();
        
        this._removeChilds(e.childNodes);
        for(var i = 0; i<this._tabValue[index].length; i++) {
            e.appendChild(this._tabValue[index][i]);
        }
        //Position scroll to top
        this._divContentUl.scrollTop = 0;
    },
    
    _selectIndex : function(index) {
        /// <summary>
        /// Select the first index
        /// </summary>

        //Add Style Select to first Index
	    if (this._tabIndex.length > 0) {
	        Sys.UI.DomElement.removeCssClass(this._tabIndex[index], this._unselectIndexCssClassValue);
            Sys.UI.DomElement.addCssClass(this._tabIndex[index], this._selectIndexCssClassValue);
            //Save previous Select Index
            this._prevIndexSelected = this._tabIndex[index];
            
            //Invoke IndexChange
            this.raiseIndexChanged(this._tabIndex[index]);
        }
    },
    
    _onIndexClick : function(evt) {
        /// <summary>
        /// Handle click events raised when the index is changed
        /// </summary>
        /// <param name="evt" type="Sys.UI.DomEvent">
        /// Event info
        /// </param>

        var e = this.get_element();        
        // Get the control that raised the event
        var aIndex = evt.target;
        
        //Change Style for selected index
        Sys.UI.DomElement.removeCssClass(this._prevIndexSelected, this._selectIndexCssClassValue);
        Sys.UI.DomElement.addCssClass(this._prevIndexSelected, this._unselectIndexCssClassValue);
        Sys.UI.DomElement.removeCssClass(aIndex, this._unselectIndexCssClassValue);
        Sys.UI.DomElement.addCssClass(aIndex, this._selectIndexCssClassValue);
        //Save previous index selected
        this._prevIndexSelected = aIndex;

        //Clear
        this._renderHtml(aIndex.tag);
        
        //Invoke IndexChange
        this.raiseIndexChanged(aIndex);
            
        evt.preventDefault();
    },

    add_indexChanged : function(handler) {
        /// <summary>
        /// Add a handler to the indexChanged event
        /// </summary>
        /// <param name="handler" type="Function">
        /// Handler
        /// </param>
        this.get_events().addHandler('indexChanged', handler);
    },
    remove_indexChanged : function(handler) {
        /// <summary>
        /// Remove a handler from the indexChanged event
        /// </summary>
        /// <param name="handler" type="Function">
        /// Handler
        /// </param>
        this.get_events().removeHandler('indexChanged', handler);
    },
    raiseIndexChanged : function(eventArgs) {
        /// <summary>
        /// Raise the indexChanged event
        /// </summary>
        /// <param name="eventArgs" type="Sys.EventArgs">
        /// Event Arguments
        /// </param>
        
        // Update the selected index        
        this._indexSelected = eventArgs.tag;
        
        var handler = this.get_events().getHandler('indexChanged');
        if (handler) {
            if (!eventArgs) {
                eventArgs = Sys.EventArgs.Empty;
            }
            handler(this, eventArgs);
        }
        this.set_ClientState(eventArgs.tag+";"+this.get_IndexSize()+";"+this.get_MaxItemPerPage()+";"+this.get_ClientSort());
    },
    
    get_tabIndex : function() {
        /// <value type="Array" elementType="Sys.UI.DomElement" elementDomElement="true">
        /// DOM elements of the indices
        /// </value>
        return this._tabIndex;
    },
    
    get_tabValue : function() {
        /// <value type="Array" elementType="Sys.UI.DomElement" elementDomElement="true">
        /// DOM elements of the items to display for each index
        /// </value>
        return this._tabValue;
    },

    _updateIndexAndView : function(index) {
        /// <summary>
        /// Regenerate the tables of indices and display
        /// </summary>

        //Re-Generate TabIndex and TabValue
        this._generateIndexAndTabForView()
        //Select clientState index or default select first index
        if (this._tabIndex.length > 0) {
            if (index < this._tabIndex.length) {
                this._renderHtml(this._tabIndex[index].tag);
                this._selectIndex(index);
            } else {
                this._renderHtml(this._tabIndex[0].tag);
                this._selectIndex(0);
            }
        }
    },
    
    get_Height : function() {
        /// <value type="Number" integer="true">
        /// Height of the bulleted list
        /// </value>
        return this._heightValue;
    },
    set_Height : function(value) {
        if (this._heightValue != value) {
            this._heightValue = value;
            if (this.get_isInitialized()) {
                //Change Height in the DOM
                this._changeHeightDivContent();
            }
            this.raisePropertyChanged('Height');
        }
    },
    
    get_IndexSize : function() {
        /// <value type="Number" integer="true">
        /// Number of characters in the index headings (ignored if MaxItemPerPage is set)
        /// </value>
        return this._indexSizeValue;
    },
    set_IndexSize : function(value) {
        if (this._indexSizeValue != value) {
            //Clear ClientState to set 0 index
            this.set_ClientState("0;"+value+";"+this.get_MaxItemPerPage()+";"+this.get_ClientSort());

            this._indexSizeValue = value;
            if (this.get_isInitialized()) {
                //Update TabIndex and TabValue and Select first Index
                this._updateIndexAndView(0);
            }
            this.raisePropertyChanged('IndexSize');
        }
    },
    
    get_MaxItemPerPage : function() {
        /// <value type="Number" integer="true">
        /// Maximum number of items per page (ignores the IndexSize property)
        /// </value>
        return this._maxItemPerPage;
    },
    set_MaxItemPerPage : function(value) {
        if(this._maxItemPerPage != value) {
            //Clear ClientState to set 0 index
            this.set_ClientState("0;"+this.get_IndexSize()+";"+value+";"+this.get_ClientSort());


            this._maxItemPerPage = value;
            if (this.get_isInitialized()) {
                //Update TabIndex and TabValue and Select first Index
                this._updateIndexAndView(0);
            }

            this.raisePropertyChanged('MaxItemPerPage');
        }
    },
    
    get_Separator : function() {
        /// <value type="String">
        /// Separator text to be placed between indices
        /// </value>
        return this._separatorValue;
    },
    set_Separator : function(value) {
        if (this._separatorValue != value) {
            if (value) {
                this._separatorValue = value;
            } else {
                this._separatorValue = '';
            }    
            if (this.get_isInitialized()) {
                //Update TabIndex and TabValue and Select first Index
                this._updateIndexAndView(0);
            }
            this.raisePropertyChanged('Separator');
        }
    },
    
    get_ClientSort : function() {
        /// <value type="Boolean">
        /// Whether or not the items should be sorted client-side
        /// </value>
        return this._clientSortValue;
    },
    set_ClientSort : function(value) {
        if (this._clientSortValue != value) {
            //Clear ClientState to set 0 index
            this.set_ClientState("0;"+this.get_IndexSize()+";"+this.get_MaxItemPerPage()+";"+value);


            this._clientSortValue = value;
            if (this.get_isInitialized()) {
                //if _clientSortValue sort Objects else sorton index init
                if (this._clientSortValue)
                    this._tabValueObject.sort(this.liElementSortText);
                else
                    this._tabValueObject.sort(this.liElementSortIndex);
                //Update TabIndex and TabValue and Select first Index
                this._updateIndexAndView(0);
            }    
            this.raisePropertyChanged('ClientSort');
        }
    },
    
    get_SelectIndexCssClass : function() {
        /// <value type="String">
        /// CSS class for the selected index.
        /// </value>
        return this._selectIndexCssClassValue;
    },
    set_SelectIndexCssClass : function(value) {
        if (this._selectIndexCssClassValue != value) {
            this._selectIndexCssClassValue = value;
            this.raisePropertyChanged('SelectIndexCssClass');
        }
    },
    
    get_UnselectIndexCssClass : function() {
        /// <value type="String">
        /// CSS class for indices that aren't selected
        /// </value>
        return this._unselectIndexCssClassValue;
    },
    set_UnselectIndexCssClass : function(value) {
        if (this._unselectIndexCssClassValue != value) {
            this._unselectIndexCssClassValue = value;
            this.raisePropertyChanged('UnselectIndexCssClass');
        }
    }
}
AjaxControlToolkit.PagingBulletedListBehavior.registerClass('AjaxControlToolkit.PagingBulletedListBehavior', AjaxControlToolkit.BehaviorBase);
//    getDescriptor : function() {
//        var td = AjaxControlToolkit.PagingBulletedListBehavior.callBaseMethod(this, 'getDescriptor');
//        
//        td.addProperty('Separator', String);        
//        td.addProperty('Height', Number);        
//        td.addProperty('IndexSize', String);    
//        td.addProperty('MaxItemPerPage', Number);   
//        td.addProperty('ClientSort', Boolean); 
//        td.addProperty('SelectIndexCssClass', String);
//        td.addProperty('UnselectIndexCssClass', String);
//        td.addEvent('IndexChanged', true);
//        return td;
//    },
