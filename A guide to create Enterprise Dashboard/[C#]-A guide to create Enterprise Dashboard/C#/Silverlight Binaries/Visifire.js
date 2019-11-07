/*
Visifire.js v4.0.3.1

Copyright (C) 2011 Webyog Softworks Private Limited.

This file is a part of Visifire Data Visualization Controls.
 
Webyog  provides Visifire under a flexible commercial license designed
to meet your specific usage and distribution requirements. If you have
already  obtained  a  commercial license from Webyog, you can use this 
file under those license terms.

*/

if (!window.Visifire) {

    /*  Visifire
    pXapPath     => Location of XAP (e.g. SL.Visifire.Charts.xap/SL.Visifire.Gauges.xap) file path.
    pId          => Silverlight object id.
    pWidth       => Width of the Silverlight control container.
    pHeight      => Height of the Silverlight control container.
    pBackground  => Background of the silverlight object
    pWindowless  => Whether the Silverlight object is windowless
    */
    window.Visifire = function (pXapPath, pId, pWidth, pHeight, pBackground, pWindowless) {
        this.id = null;                             // Silverlight object id.
        this.logLevel = 1;                          // Determines whether to log or not.
        this.xapPath = null;                        // xap file path (default is taken as SL.Visifire.Gauges.xap in the same directory).
        this.targetElement = null;                  // Target div element name.
        this.dataXml = null;                        // Visifire Xml string.
        this.dataUri = null;                        // Visifire xml file uri path.
        this.windowless = null;                     // Windowless property.
        this.width = null;                          // Width of the SL Control.
        this.height = null;                         // Height of the SL Control.
        this.background = null;                     // Background of the Silverlight control container.
        this.preLoad = null;                        // Preload event handler.
        this.loaded = null;                         // Loaded event handler.
        this.onError = null;                        // OnError event handler.

        /*  Array of Silverlight control references. Visifire Silverlight control can contain more than one control.
        Silverlight control reference can be used for updating them at real-time
        */
        this.controls = null;

        //  pId not present
        if (Number(pId)) {
            if (pHeight)
                this.background = pHeight;

            pHeight = pWidth;
            pWidth = pId;
        }
        else    // pId present
        {
            this.id = pId;

            if (pBackground)
                this.background = pBackground;
        }

        if (pXapPath)
            this.xapPath = pXapPath;

        if (pWidth)
            this.width = pWidth;

        if (pHeight)
            this.height = pHeight;

        if (pBackground)
            this.background = pBackground;

        if (pWindowless)
            this.windowless = pWindowless;

        this.vThisObject = this;

        this.index = ++Visifire._slCount;
    }

    window.Visifire._slCount = 0;  // Number of Visifire controls present in the current window.

    /*  Set windowless state of silverlight object
        
    pWindowless  => Whether the Silverlight object is windowless
    */
    Visifire.prototype.setWindowlessState = function (pWindowless) {
        if (pWindowless != null)
            this.windowless = Boolean(pWindowless);
    }

    /*  Set Visifire data Xml
        
    pDataXml  => Visifire data xml as string
    */
    Visifire.prototype.setDataXml = function (pDataXml) {
        var slControl = this._getSlControl();

        this.dataXml = pDataXml;

        if (slControl != null && this.dataXml != null)
            slControl.Content.wrapper.AddDataXML(pDataXml);
    }

    /*  Set data Uri to Visifire control
        
    pDataUri  => Visifire data uri as string
    */
    Visifire.prototype.setDataUri = function (pDataUri) {
        var slControl = this._getSlControl();

        this.dataUri = pDataUri;

        if (slControl != null && this.dataUri != null)
            slControl.Content.wrapper.AddDataUri(pDataUri);
    }

    /*  Render Visifire data xml
        
    pTargetElement  => Target div element
    */
    Visifire.prototype.render = function (pTargetElement) {
        var vThisObject = this;            // This Class
        var vSlControl = this._getSlControl();

        vThisObject._attachEvents();

        if (vSlControl == null)
            this._render(pTargetElement);
        else
            this._reRender(vSlControl);
    }

    /*  Set size of the Silverlight control
        
    pWidth   => Width of the Silverlight control
    pHeight  => Height of the Silverlight control
    */
    Visifire.prototype.setSize = function (pWidth, pHeight) {
        var slControl = this._getSlControl();

        if (slControl != null) {
            slControl.width = pWidth;
            slControl.height = pHeight;
            slControl.Content.wrapper.Resize(pWidth, pHeight);
        }
        else {
            this.width = pWidth;
            this.height = pHeight;
        }
    }

    /*  Set LogLevel of the Silverlight Control
        
    level  => loglevel value used to generate a process log depending on logging level.
    */
    Visifire.prototype.setLogLevel = function (pLevel) {
        if (pLevel != null)
            this.logLevel = pLevel;
    }

    /*  Checks whether the silverlight control is loaded 
    */
    Visifire.prototype.isLoaded = function () {
        var slControl = this._getSlControl();

        try {
            if (slControl.Content.wrapper != null)
                return true;
        }
        catch (ex) {
            return false;
        }
    }

    /*  Whether the Visifire data xml is loaded and ready for render
    */
    Visifire.prototype.isDataLoaded = function () {
        var slControl = this._getSlControl();
        return slControl.Content.wrapper.IsDataLoaded;
    }

    /*  Attach required events
    */
    Visifire.prototype._attachEvents = function () {
        var vThisObject = this; // This Class

        window["setVisifireControlsRef" + vThisObject.index] = function (e) {
            vThisObject.controls = e;
        }

        if (vThisObject.preLoad != null)
            window["visifireControlPreLoad" + vThisObject.index] = vThisObject.preLoad;

        if (vThisObject.loaded != null)
            window["visifireControlLoaded" + vThisObject.index] = vThisObject.loaded;

        if (vThisObject.onError != null)
            window["visifireControlOnError" + vThisObject.index] = vThisObject.onError;
    }

    /*  Returns current silverlight control reference 
    */
    Visifire.prototype._getSlControl = function () {
        var vThisObject = this; // This Class

        if (vThisObject.id != null) {
            var slControl = document.getElementById(vThisObject.id);
            return slControl;
        }

        return null;
    }

    /*  Render Visifire data XML
        
    pTargetElement  => Target div element
    */
    Visifire.prototype._render = function (pTargetElement) {
        var vThisObject = this;            // This Class
        var vWidth;                        // Width of the Silverlight control container
        var vHeight;                       // Height of the Silverlight control container

        vThisObject.targetElement = (typeof (pTargetElement) == "string") ? document.getElementById(pTargetElement) : pTargetElement;

        vWidth = (vThisObject.width != null) ? vThisObject.width : (vThisObject.targetElement.offsetWidth != 0) ? vThisObject.targetElement.offsetWidth : 400;

        vHeight = (vThisObject.height != null) ? vThisObject.height : (vThisObject.targetElement.offsetHeight != 0) ? vThisObject.targetElement.offsetHeight : 400;

        if (!vThisObject.id)
            vThisObject.id = 'VisifireControl' + vThisObject.index;

        var html = '<object id="' + vThisObject.id + '" data="data:application/x-silverlight-2," type="application/x-silverlight-2" width="' + vWidth + '" height="' + vHeight + '">';

        html += '<param name="source" value="' + vThisObject.xapPath + '"/>'
        html += '<param name="initParams" value="';
        html += "logLevel=" + vThisObject.logLevel + ",";
        html += "controlId=" + vThisObject.id + ",";
        html += "setVisifireControlsRef=setVisifireControlsRef" + vThisObject.index + ",";

        if (vThisObject.preLoad != null)
            html += "onControlPreLoad=visifireControlPreLoad" + vThisObject.index + ",";

        if (vThisObject.loaded != null)
            html += "onControlLoaded=visifireControlLoaded" + vThisObject.index + ",";

        if (vThisObject.dataXml != null) {
            window["getVisifireDataXml" + vThisObject.index] = function (sender, args) {
                var _uThisObj = vThisObject;
                return _uThisObj.dataXml;
            };

            html += 'dataXml=getVisifireDataXml' + vThisObject.index + ',';
        }
        else if (vThisObject.dataUri != null) {
            html += 'dataUri=' + vThisObject.dataUri + ',';
        }

        if (vThisObject.background == null)
            vThisObject.background = "White";

        if (vThisObject.windowless == null) {
            if (vThisObject.background == "Transparent" || vThisObject.background == "transparent")
                vThisObject.windowless = true;
            else
                vThisObject.windowless = false;
        }

        html += 'width=' + vWidth + ',' + 'height=' + vHeight + '';
        html += "\"/>";

        if (vThisObject.onError != null)
            html += '<param name="onError" value="visifireControlOnError' + vThisObject.index + '" />'

        html += '<param name="enableHtmlAccess" value="true" />'
		        + '<param name="background" value="' + vThisObject.background + '" />'
		        + '<param name="windowless" value="' + vThisObject.windowless + '" />'
		        + '<a href="http://go.microsoft.com/fwlink/?LinkID=149156&v=4.0.50401.0" style="text-decoration: none;">'
		        + '<img src="http://go.microsoft.com/fwlink/?LinkId=161376" alt="Get Microsoft Silverlight" style="border-style: none; height:210; width:265.3"/>'
		        + '<br/>You need Microsoft Silverlight to view Visifire Controls.'
		        + '<br/> You can install it by clicking on this link.'
		        + '<br/>Please restart the browser after installation.'
		        + '</a>'
		        + '</object>';

        this.targetElement.innerHTML = html;
    }

    /*  Re-render the Visifire Control

    pSlControl  => Silverlight control reference
    */
    Visifire.prototype._reRender = function (pSlControl) {
        pSlControl.Content.wrapper.ReRenderControl();
    }
}