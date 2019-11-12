namespace WMP.PipelineComponenets
{
    using System;
    using System.IO;
    using System.Text;
    using System.Drawing;
    using System.Resources;
    using System.Reflection;
    using System.Diagnostics;
    using System.Collections;
    using System.ComponentModel;
    using Microsoft.BizTalk.Message.Interop;
    using Microsoft.BizTalk.Component.Interop;
    using Microsoft.BizTalk.Component;
    using Microsoft.BizTalk.Messaging;
    
    
    [ComponentCategory(CategoryTypes.CATID_PipelineComponent)]
    [System.Runtime.InteropServices.Guid("71f9b872-7acc-4f0e-b27f-cf90703c085b")]
    [ComponentCategory(CategoryTypes.CATID_Decoder)]
    public class StreamingArchive : Microsoft.BizTalk.Component.Interop.IComponent, IBaseComponent, IPersistPropertyBag, IComponentUI
    {
        
        private System.Resources.ResourceManager resourceManager = new System.Resources.ResourceManager("WMP.PipelineComponenets.StreamingArchive", Assembly.GetExecutingAssembly());

        #region Configuration Properties

        private string _FileNameProperty;
        
        public string FileNameProperty
        {
            get
            {
                return _FileNameProperty;
            }
            set
            {
                _FileNameProperty = value;
            }
        }

        private string _FileNamePropertyNamespace;

        public string FileNamePropertyNamespace
        {
            get
            {
                return _FileNamePropertyNamespace;
            }
            set
            {
                _FileNamePropertyNamespace = value;
            }
        }
        
        private string _ArchivePath;
        
        public string ArchivePath
        {
            get
            {
                return _ArchivePath;
            }
            set
            {
                _ArchivePath = value;
            }
        }
        
        private bool _ArchiveFiles;
        
        public bool ArchiveFiles
        {
            get
            {
                return _ArchiveFiles;
            }
            set
            {
                _ArchiveFiles = value;
            }
        }

        #endregion

        #region IBaseComponent members
        /// <summary>
        /// Name of the component
        /// </summary>
        [Browsable(false)]
        public string Name
        {
            get
            {
                return resourceManager.GetString("COMPONENTNAME", System.Globalization.CultureInfo.InvariantCulture);
            }
        }
        
        /// <summary>
        /// Version of the component
        /// </summary>
        [Browsable(false)]
        public string Version
        {
            get
            {
                return resourceManager.GetString("COMPONENTVERSION", System.Globalization.CultureInfo.InvariantCulture);
            }
        }
        
        /// <summary>
        /// Description of the component
        /// </summary>
        [Browsable(false)]
        public string Description
        {
            get
            {
                return resourceManager.GetString("COMPONENTDESCRIPTION", System.Globalization.CultureInfo.InvariantCulture);
            }
        }
        #endregion
        
        #region IPersistPropertyBag members
        /// <summary>
        /// Gets class ID of component for usage from unmanaged code.
        /// </summary>
        /// <param name="classid">
        /// Class ID of the component
        /// </param>
        public void GetClassID(out System.Guid classid)
        {
            classid = new System.Guid("71f9b872-7acc-4f0e-b27f-cf90703c085b");
        }
        
        /// <summary>
        /// not implemented
        /// </summary>
        public void InitNew()
        {
        }
        
        /// <summary>
        /// Loads configuration properties for the component
        /// </summary>
        /// <param name="pb">Configuration property bag</param>
        /// <param name="errlog">Error status</param>
        public virtual void Load(Microsoft.BizTalk.Component.Interop.IPropertyBag pb, int errlog)
        {
            object val = null;
            val = this.ReadPropertyBag(pb, "FileNameProperty");
            if ((val != null))
            {
                this._FileNameProperty = ((string)(val));
            }
            val = this.ReadPropertyBag(pb, "FileNamePropertyNamespace");
            if ((val != null))
            {
                this._FileNamePropertyNamespace = ((string)(val));
            }
            
            val = this.ReadPropertyBag(pb, "ArchivePath");
            if ((val != null))
            {
                this._ArchivePath = ((string)(val));
            }
            val = this.ReadPropertyBag(pb, "ArchiveFiles");
            if ((val != null))
            {
                this._ArchiveFiles = ((bool)(val));
            }
        }
        
        /// <summary>
        /// Saves the current component configuration into the property bag
        /// </summary>
        /// <param name="pb">Configuration property bag</param>
        /// <param name="fClearDirty">not used</param>
        /// <param name="fSaveAllProperties">not used</param>
        public virtual void Save(Microsoft.BizTalk.Component.Interop.IPropertyBag pb, bool fClearDirty, bool fSaveAllProperties)
        {
            this.WritePropertyBag(pb, "FileNameProperty", this.FileNameProperty);
            this.WritePropertyBag(pb, "FileNamePropertyNamespace", this.FileNamePropertyNamespace);
            this.WritePropertyBag(pb, "ArchivePath", this.ArchivePath);
            this.WritePropertyBag(pb, "ArchiveFiles", this.ArchiveFiles);
        }
        
        #region utility functionality
        /// <summary>
        /// Reads property value from property bag
        /// </summary>
        /// <param name="pb">Property bag</param>
        /// <param name="propName">Name of property</param>
        /// <returns>Value of the property</returns>
        private object ReadPropertyBag(Microsoft.BizTalk.Component.Interop.IPropertyBag pb, string propName)
        {
            object val = null;
            try
            {
                pb.Read(propName, out val, 0);
            }
            catch (System.ArgumentException )
            {
                return val;
            }
            catch (System.Exception e)
            {
                throw new System.ApplicationException(e.Message);
            }
            return val;
        }
        
        /// <summary>
        /// Writes property values into a property bag.
        /// </summary>
        /// <param name="pb">Property bag.</param>
        /// <param name="propName">Name of property.</param>
        /// <param name="val">Value of property.</param>
        private void WritePropertyBag(Microsoft.BizTalk.Component.Interop.IPropertyBag pb, string propName, object val)
        {
            try
            {
                pb.Write(propName, ref val);
            }
            catch (System.Exception e)
            {
                throw new System.ApplicationException(e.Message);
            }
        }
        #endregion
        #endregion
        
        #region IComponentUI members
        /// <summary>
        /// Component icon to use in BizTalk Editor
        /// </summary>
        [Browsable(false)]
        public IntPtr Icon
        {
            get
            {
                return ((System.Drawing.Bitmap)(this.resourceManager.GetObject("COMPONENTICON", System.Globalization.CultureInfo.InvariantCulture))).GetHicon();
            }
        }
        
        /// <summary>
        /// The Validate method is called by the BizTalk Editor during the build 
        /// of a BizTalk project.
        /// </summary>
        /// <param name="obj">An Object containing the configuration properties.</param>
        /// <returns>The IEnumerator enables the caller to enumerate through a collection of strings containing error messages. These error messages appear as compiler error messages. To report successful property validation, the method should return an empty enumerator.</returns>
        public System.Collections.IEnumerator Validate(object obj)
        {
            // example implementation:
            // ArrayList errorList = new ArrayList();
            // errorList.Add("This is a compiler error");
            // return errorList.GetEnumerator();
            return null;
        }
        #endregion
        
        #region IComponent members
        /// <summary>
        /// Implements IComponent.Execute method.
        /// </summary>
        /// <param name="pc">Pipeline context</param>
        /// <param name="inmsg">Input message</param>
        /// <returns>Original input message</returns>
        /// <remarks>
        /// IComponent.Execute method is used to initiate
        /// the processing of the message in this pipeline component.
        /// </remarks>
        public Microsoft.BizTalk.Message.Interop.IBaseMessage Execute(Microsoft.BizTalk.Component.Interop.IPipelineContext pc, Microsoft.BizTalk.Message.Interop.IBaseMessage inmsg)
        {
            if (_ArchiveFiles)
            {
                string archiveFileName = inmsg.Context.Read(_FileNameProperty, _FileNamePropertyNamespace) as string;
                if (archiveFileName != null && !string.IsNullOrEmpty(archiveFileName))
                {
                    if (archiveFileName.Contains("\\"))
                        archiveFileName = archiveFileName.Substring(archiveFileName.LastIndexOf("\\") + 1);

                    ArchivingStream archivingStream = new ArchivingStream(inmsg.BodyPart.Data, _ArchivePath + "\\" + archiveFileName);
                    pc.ResourceTracker.AddResource(archivingStream);
                    inmsg.BodyPart.Data = archivingStream;
                }
            }
            return inmsg;
        }
        #endregion
    }
}
