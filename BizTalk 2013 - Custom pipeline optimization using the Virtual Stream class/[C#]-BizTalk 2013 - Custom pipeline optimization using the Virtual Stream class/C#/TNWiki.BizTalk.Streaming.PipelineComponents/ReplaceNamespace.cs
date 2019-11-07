//Standard namespaces
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

//Import namespaces

//Microsoft.BizTalk.Messaging
using Microsoft.BizTalk.Message.Interop;

//Microsoft.BizTalk..Pipeline.
using Microsoft.BizTalk.Component;
using Microsoft.BizTalk.Component.Interop;

using Microsoft.BizTalk.Messaging;
//Microsoft.BizTalk.Streaming
using Microsoft.BizTalk.Streaming;

namespace TNWiki.BizTalk.Streaming.PipelineComponents
{
    [ComponentCategory(CategoryTypes.CATID_PipelineComponent)]
    [System.Runtime.InteropServices.Guid("4fa446c7-eca3-48c7-a170-7a58032177bd")]
    [ComponentCategory(CategoryTypes.CATID_Any)]
    public class ReplaceNamespace : Microsoft.BizTalk.Component.Interop.IComponent, IBaseComponent, IPersistPropertyBag, IComponentUI
    {
        //Assign default values to properties
        private string _oldNamespace = string.Empty;
        private string _newNamespace = string.Empty;
        private bool _enabled = false;

        Dictionary<string, string> _Replacements = new Dictionary<string, string>();

        #region properties

        [Description("Property containing the new namespace to replace the old namespace")]
        public string NewNamespace
        {
            get
            {
                return _newNamespace;
            }
            set
            {
                _newNamespace = value;
            }
        }

        [Description("Property containing the old namespace to be replaced")]
        public string OldNamespace
        {
            get
            {
                return _oldNamespace;
            }
            set
            {
                _oldNamespace = value;
            }
        }

        [Description("Property saying if the replacement should be done or not")]
        public bool Enabled
        {
            get
            {
                return _enabled;
            }
            set
            {
                _enabled = value;
            }
        }

        #endregion properties

        #region IBaseComponent Members

        public string Description
        {
            get { return "Replaces the namespace from one value to another"; }
        }

        public string Name
        {
            get
            {
                return "ReplaceNamespace";
            }
        }

        public string Version
        {
            get
            {
                return "1.0.0.0";
            }
        }


        #endregion

        #region IPersistPropertyBag Members

        public void GetClassID(out Guid classID)
        {
            classID = new System.Guid("cd9b3c09-77a6-4a9f-a708-3e5f38cd52b7");
        }

        public void InitNew()
        {
        }

        public void Load(IPropertyBag propertyBag, int errorLog)
        {
            object val = null;

            val = this.ReadPropertyBag(propertyBag, "OldNamespace");
            if ((val != null))
            {
                this._oldNamespace = ((string)(val));
            }

            val = null;

            val = this.ReadPropertyBag(propertyBag, "NewNamespace");
            if ((val != null))
            {
                this._newNamespace = ((string)(val));
            }

            val = null;

            val = this.ReadPropertyBag(propertyBag, "Enabled");
            if ((val != null))
            {
                this._enabled = ((bool)(val));
            }
        }

        public void Save(IPropertyBag propertyBag, bool clearDirty, bool saveAllProperties)
        {
            WritePropertyBag(propertyBag, "OldNamespace", OldNamespace);
            WritePropertyBag(propertyBag, "NewNamespace", NewNamespace);
            WritePropertyBag(propertyBag, "Enabled", Enabled);
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
            catch (System.ArgumentException)
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

        #region IComponentUI Members

        public IntPtr Icon
        {
            get
            {
                return System.IntPtr.Zero;
            }
        }

        public IEnumerator Validate(object projectSystem)
        {
            // An example implementation:
            // ArrayList errorList = new ArrayList();
            // errorList.Add("This is a compiler error");
            // return errorList.GetEnumerator();
            ArrayList errors = new ArrayList();

            //If enabled check values
            if (Enabled)
            {
                if (string.IsNullOrEmpty(NewNamespace))
                {
                    errors.Add("NewNamespace must contain a value");
                }

                if (string.IsNullOrEmpty(OldNamespace))
                {
                    errors.Add("OldNamespace must contain a value");
                }
            }

            return errors.GetEnumerator();
        }


        #endregion

        #region IComponent Members

        public IBaseMessage Execute(IPipelineContext pContext, IBaseMessage pInMsg)
        {

            System.Diagnostics.Trace.Write("1. Enter Pipeline");

            try
            {
                System.Diagnostics.Trace.Write("2. Namespace Replace Enable : " + Enabled.ToString());

                //If enabled
                if (Enabled)
                {
                    //Create StreamReader, VirtualStream and StreamWriter instance
                    StreamReader sReader = new StreamReader(pInMsg.BodyPart.Data);
                    VirtualStream vInStream = new VirtualStream();
                    StreamWriter sWriter = new StreamWriter(vInStream);

                    System.Diagnostics.Trace.Write("3. Created StreamReader, VirtualStream and StreamWriter instances.");

                    //Write message body to a virutal memory stream
                    sWriter.Write(sReader.ReadToEnd());
                    sWriter.Flush();
                    sReader.Close();

                    System.Diagnostics.Trace.Write("4. Message body written to a virutal memory stream.");

                    vInStream.Seek(0, SeekOrigin.Begin);

                    //create a string
                    string body = new StreamReader(vInStream).ReadToEnd();

                    System.Diagnostics.Trace.Write("5. Message body : " + body);
                    System.Diagnostics.Trace.Write("6. Old Namespace : " + OldNamespace);
                    System.Diagnostics.Trace.Write("7. New Namespace : " + NewNamespace);

                    VirtualStream vOutStream = new VirtualStream();

                    //Add property to Namespace.
                    //Manipulate the Namespace of the message
                    body = body.Replace(OldNamespace, NewNamespace);

                    System.Diagnostics.Trace.Write("8. Namespace replaced");

                    //Write the output
                    StreamWriter writer = new StreamWriter(vOutStream);
                    writer.AutoFlush = true;
                    writer.Write(body);
                    vOutStream.Position = 0;

                    System.Diagnostics.Trace.Write("9. Write output.");

                    //Put the stream back
                    pInMsg.BodyPart.Data = vOutStream;

                    System.Diagnostics.Trace.Write("10. Exit Pipeline.");
                }

                return pInMsg;
            }
            catch (Exception ex)
            {
                if (pInMsg != null)
                {
                    pInMsg.SetErrorInfo(ex);
                }

                throw ex;
            }
        }

        #endregion

    }
}
