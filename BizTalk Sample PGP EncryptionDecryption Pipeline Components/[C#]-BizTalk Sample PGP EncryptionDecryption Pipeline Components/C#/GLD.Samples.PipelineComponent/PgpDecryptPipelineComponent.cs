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
    [System.Runtime.InteropServices.Guid("D5A3AAD3-F6C6-4D7E-938C-8A5DD5EA9C55")]
    public class PgpDecrypt :
        IBaseComponent,
        Microsoft.BizTalk.Component.Interop.IComponent,
        IPersistPropertyBag,
        IComponentUI
    {
        #region Properties
        static private string SOO_App_Name = "GLD.Samples.Pipelines";

        private string privateKeyFile = 
            Microsoft.SSO.Utility.SSOConfigHelper.Read(SOO_App_Name, "Decrypt_PrivateKeyFile"); 
        private string passphrase = 
             Microsoft.SSO.Utility.SSOConfigHelper.Read(SOO_App_Name, "Decrypt_Passphrase"); 
        private string tempDirectory = 
            Microsoft.SSO.Utility.SSOConfigHelper.Read(SOO_App_Name, "Decrypt_TempDirectory"); 
        #endregion

        #region IBaseComponent Members

        [Browsable(false)]
        string IBaseComponent.Description
        {
            get { return "BizTalk Receive Pipeline Component for PGP Decryption"; }
        }

        [Browsable(false)]
        string IBaseComponent.Name
        {
            get { return "PgpDecrypt v.3"; }
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
            classID = new Guid("D5A3AAD3-F6C6-4D7E-938C-8A5DD5EA9C55");

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
                ResourceManager rm = new ResourceManager("GLD.Samples.PipelineComponent.Resource.PgpDecrypt", Assembly.GetExecutingAssembly());
                Bitmap bm = (Bitmap)rm.GetObject("Secure");
                return bm.GetHicon();
            }
        }

        System.Collections.IEnumerator IComponentUI.Validate(object projectSystem)
        {
            System.Collections.ArrayList errors = new System.Collections.ArrayList();

            // verify required properties are supplied
            //if (0 == this.PrivateKeyFile.Length) { errors.Add("Private Key File is required for decryption."); }
            //else if (!File.Exists(this.PrivateKeyFile)) { errors.Add("Private Key File could not be found: " + this.PrivateKeyFile); }

            if (0 == this.passphrase.Length) { errors.Add("Passphrase is required for decryption."); }
            return errors.GetEnumerator();
        }

        #endregion

        #region IComponent Members

        IBaseMessage Microsoft.BizTalk.Component.Interop.IComponent.Execute(IPipelineContext pContext, IBaseMessage pInMsg)
        {
            System.Diagnostics.Trace.WriteLine(">>> PgpDecrypt.Execute () v.3");
            IBaseMessagePart bodyPart = pInMsg.BodyPart;
            IBaseMessageContext context = pInMsg.Context;
            string filename = "";

            if (bodyPart != null)
            {
                filename = context.Read("ReceivedFileName", "http://schemas.microsoft.com/BizTalk/2003/file-properties").ToString();

                if (filename.Contains("\\")) { filename = filename.Substring(filename.LastIndexOf("\\") + 1); }
                if (filename.Contains("/")) { filename = filename.Substring(filename.LastIndexOf("/") + 1); }

                if (0 < this.tempDirectory.Length)
                    if (!Directory.Exists(this.tempDirectory))
                        Directory.CreateDirectory(this.tempDirectory);
                filename = Path.Combine(this.tempDirectory, filename);
                string tempFile = Path.Combine(this.tempDirectory, Guid.NewGuid().ToString());

                Stream decStream = PGPWrapper.DecryptStream(bodyPart.Data, this.privateKeyFile, this.passphrase, tempFile, this.tempDirectory);

                decStream.Seek(0, SeekOrigin.Begin);
                bodyPart.Data = decStream;
                pContext.ResourceTracker.AddResource(decStream);
                context.Write("ReceivedFileName", "http://schemas.microsoft.com/BizTalk/2003/file-properties", filename.Replace(".pgp", ""));

            }
            return pInMsg;
        }

        #endregion
    }
}
