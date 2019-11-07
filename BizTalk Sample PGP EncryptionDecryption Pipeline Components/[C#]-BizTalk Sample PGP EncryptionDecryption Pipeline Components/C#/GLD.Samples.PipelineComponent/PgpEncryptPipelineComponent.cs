using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.BizTalk.Message.Interop;
using Microsoft.BizTalk.Component.Interop;
using System.ComponentModel;
using System.Resources;
using System.Reflection;
using System.Drawing;
using System.IO;

namespace GLD.Samples.PipelineComponents
{

    [ComponentCategory(CategoryTypes.CATID_PipelineComponent)]
    [ComponentCategory(CategoryTypes.CATID_Encoder)]
    [ComponentCategory(CategoryTypes.CATID_Decoder)]
    [System.Runtime.InteropServices.Guid("74FD2768-8BFE-4EAF-AA94-7756BA41FD6A")]
    public class PgpEncrypt :
        IBaseComponent,
        Microsoft.BizTalk.Component.Interop.IComponent,
        IPersistPropertyBag,
        IComponentUI
    {
        #region Properties
        static private string SOO_App_Name = "GLD.Samples.Pipelines";

        private string pubKeyFile =
           Microsoft.SSO.Utility.SSOConfigHelper.Read(SOO_App_Name, "Encrypt_PublicKeyFile");
        private string extension =
             Microsoft.SSO.Utility.SSOConfigHelper.Read(SOO_App_Name, "Encrypt_Extension");
        private string tempDirectory =
            Microsoft.SSO.Utility.SSOConfigHelper.Read(SOO_App_Name, "Encrypt_TempDirectory");
        private bool asciiArmorFlag =
            System.Convert.ToBoolean(Microsoft.SSO.Utility.SSOConfigHelper.Read(SOO_App_Name, "Encrypt_ASCIIArmorFlag"));
        private bool integrityCheckFlag =
            System.Convert.ToBoolean(Microsoft.SSO.Utility.SSOConfigHelper.Read(SOO_App_Name, "Encrypt_IntegrityCheckFlag"));

        #endregion

        #region IBaseComponent Members

        [Browsable(false)]
        string IBaseComponent.Description
        {
            get { return "BizTalk Receive Pipeline Component for PGP Encryption"; }
        }

        [Browsable(false)]
        string IBaseComponent.Name
        {
            get { return "PgpEncrypt v.3"; }
        }

        [Browsable(false)]
        string IBaseComponent.Version
        {
            get { return "3.0"; }
        }

        #endregion

        #region IPersistPropertyBag Members

        void IPersistPropertyBag.GetClassID(out Guid classID)
        {
            classID = new Guid("74FD2768-8BFE-4EAF-AA94-7756BA41FD6A");

        }

        void IPersistPropertyBag.InitNew()        {        }

        public virtual void Load(IPropertyBag propertyBag, int errorLog)        {        }

        public virtual void Save(IPropertyBag propertyBag, bool clearDirty, bool saveAllProperties)        {        }

        #endregion

        #region IComponentUI Members

        IntPtr IComponentUI.Icon
        {
            get
            {
                ResourceManager rm = new ResourceManager("GLD.Samples.PipelineComponent.Resource.PgpEncrypt", Assembly.GetExecutingAssembly());
                Bitmap bm = (Bitmap)rm.GetObject("Secure");
                return bm.GetHicon();
            }
        }

        System.Collections.IEnumerator IComponentUI.Validate(object projectSystem)
        {
            System.Collections.ArrayList errors = new System.Collections.ArrayList();

            if ("." == this.extension.Substring(1, 1))
                this.extension = this.extension.Substring(1);

            return errors.GetEnumerator();
        }

        #endregion

        #region IComponent Members

        IBaseMessage Microsoft.BizTalk.Component.Interop.IComponent.Execute(IPipelineContext pContext, IBaseMessage pInMsg)
        {
            System.Diagnostics.Trace.WriteLine(">>> PgpEncrypt.Execute ()  v.3");
            IBaseMessagePart bodyPart = pInMsg.BodyPart;
            IBaseMessageContext context = pInMsg.Context;
            string filename = "";

            if (bodyPart != null)
            {
                filename = context.Read("ReceivedFileName", "http://schemas.microsoft.com/BizTalk/2003/file-properties").ToString();

                if (filename.Contains("\\")) { filename = filename.Substring(filename.LastIndexOf("\\") + 1); }
                if (filename.Contains("/")) { filename = filename.Substring(filename.LastIndexOf("/") + 1); }

                if (!String.IsNullOrEmpty(tempDirectory))
                    if (!Directory.Exists(this.tempDirectory))
                        Directory.CreateDirectory(this.tempDirectory);
                filename = Path.Combine(this.tempDirectory, filename);

                string tempFile = Path.Combine(this.tempDirectory, Guid.NewGuid().ToString());

                Stream encStream = PGPWrapper.EncryptStream(bodyPart.Data, this.pubKeyFile, tempFile, this.extension, this.asciiArmorFlag, this.integrityCheckFlag);

                encStream.Seek(0, SeekOrigin.Begin);
                bodyPart.Data = encStream;
                pContext.ResourceTracker.AddResource(encStream);
                context.Write("ReceivedFileName", "http://schemas.microsoft.com/BizTalk/2003/file-properties", filename + ".pgp");
            }
            return pInMsg;
        }

        #endregion
    }
}
