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

AjaxControlToolkit.MutuallyExclusiveCheckBoxBehavior = function(element) {
    /// <summary>
    /// The MutuallyExclusiveCheckBoxBehavior allows only one checkbox in
    /// a group with the same Key to be checked at a time
    /// </summary>
    /// <param name="element" type="Sys.UI.DomElement" domElement="true">
    /// The DOM Element the behavior is associated with
    /// </param>
    AjaxControlToolkit.MutuallyExclusiveCheckBoxBehavior.initializeBase(this, [element]);
    
    this._key = "";
    this._clickHandler = Function.createDelegate(this, this._onclick);
}
AjaxControlToolkit.MutuallyExclusiveCheckBoxBehavior.prototype = {
    initialize : function() {
        /// <summary>
        /// Initialize the behavior
        /// </summary>
        AjaxControlToolkit.MutuallyExclusiveCheckBoxBehavior.callBaseMethod(this, 'initialize');
        $addHandler(this.get_element(), "click", this._clickHandler);
    },
    
    dispose : function() {
        /// <summary>
        /// Dispose the behavior
        /// </summary>
        if (this._key) {
            var keys = AjaxControlToolkit.MutuallyExclusiveCheckBoxBehavior.Keys;
            var ar = keys[this._key];
            Array.remove(ar, this);
            this._key = null;
        }
        if (this._clickHandler) {
            $removeHandler(this.get_element(), "click", this._clickHandler);
            this._clickHandler = null;
        }
        AjaxControlToolkit.MutuallyExclusiveCheckBoxBehavior.callBaseMethod(this, 'dispose');
    },
    
    get_Key : function() {
        /// <value type="String">
        /// The unique key to use to associate checkboxes. This key does not respect INamingContainer renaming.
        /// </value>
        return this._key;
    },
    set_Key : function(value) {
        var keys = AjaxControlToolkit.MutuallyExclusiveCheckBoxBehavior.Keys;
        if(value != this._key) {
            if(this._key) {
                var ar = keys[this._key];
                Array.remove(ar, this._key);
            }
            this._key = value;
            if(value) {
                var ar = keys[this._key];
                if(ar == null) {
                    ar = keys[this._key] = [];
                }
                Array.add(ar, this);
            }
        }
    },
    
    _onclick : function() {
        /// <summary>
        /// Click handler used to ensure only one checkbox in its key is checked
        /// </summary>
        var element = this.get_element();
        var keys = AjaxControlToolkit.MutuallyExclusiveCheckBoxBehavior.Keys;
        if(this._key && element.checked) {
            var ar = keys[this._key];
            var t = this;
            Array.forEach(ar, function(b) {
                /// <summary>
                /// Uncheck all other checkboxes in the same key group
                /// </summary>
                /// <param name="b" type="AjaxControlToolkit.MutuallyExclusiveCheckBoxBehavior">
                /// Checkbox in the same key group
                /// </param>
                if(b != t) {
                    b.get_element().checked = false;
                    $common.tryFireEvent(b.get_element(), "change");
                }
            });
        }
        
        this.raiseChecked(new AjaxControlToolkit.MutuallyExclusiveCheckBoxEventArgs(element, this._key));
    },
    
    add_checked : function(handler) {
        /// <summary>
        /// Add an event handler for the checked event
        /// </summary>
        /// <param name="handler" type="Function" mayBeNull="false">
        /// Event handler
        /// </param>
        /// <returns />
        this.get_events().addHandler('checked', handler);
    },
    remove_checked : function(handler) {
        /// <summary>
        /// Remove an event handler from the checked event
        /// </summary>
        /// <param name="handler" type="Function" mayBeNull="false">
        /// Event handler
        /// </param>
        /// <returns />
        this.get_events().removeHandler('checked', handler);
    },
    raiseChecked : function(eventArgs) {
        /// <summary>
        /// Raise the checked event
        /// </summary>
        /// <param name="eventArgs" type="AjaxControlToolkit.MutuallyExclusiveCheckBoxEventArgs" mayBeNull="false">
        /// Event arguments for the checked event
        /// </param>
        /// <returns />
        
        var handler = this.get_events().getHandler('checked');
        if (handler) {
            handler(this, eventArgs);
        }
    }
}    
AjaxControlToolkit.MutuallyExclusiveCheckBoxBehavior.registerClass('AjaxControlToolkit.MutuallyExclusiveCheckBoxBehavior', AjaxControlToolkit.BehaviorBase);
AjaxControlToolkit.MutuallyExclusiveCheckBoxBehavior.Keys = {};


AjaxControlToolkit.MutuallyExclusiveCheckBoxEventArgs = function(checkbox, key) {
    /// <summary>
    /// Event arguments used when the checked event is raised
    /// </summary>
    /// <param name="checkbox" type="Sys.UI.DomElement" mayBeNull="False" isDomElement="true">
    /// Checkbox that was checked or unchecked
    /// </param>
    /// <param name="key" type="String" mayBeNull="False">
    /// The unique key used to associate checkboxes
    /// </param>
    AjaxControlToolkit.MutuallyExclusiveCheckBoxEventArgs.initializeBase(this);
    
    this._key = key;
    this._checkbox = checkbox;
}
AjaxControlToolkit.MutuallyExclusiveCheckBoxEventArgs.prototype = {
    get_checkbox : function() {
        /// <value type="Sys.UI.DomElement" mayBeNull="False">
        /// Checkbox that was checked or unchecked
        /// </value>
        return this._checkbox;
    },
    
    get_key : function() {
        /// <value type="String" mayBeNull="False">
        /// The unique key used to associate checkboxes
        /// </value>
        return this._key;
    }
}
AjaxControlToolkit.MutuallyExclusiveCheckBoxEventArgs.registerClass('AjaxControlToolkit.MutuallyExclusiveCheckBoxEventArgs', Sys.EventArgs);
