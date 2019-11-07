using System;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Security;

namespace CustomHitCounterWebPart.Features.Feature1
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>

    [Guid("cfb18a00-b96a-4048-9e7d-297d12ad8683")]
    public class Feature1EventReceiver : SPFeatureReceiver
    {
        // Uncomment the method below to handle the event raised after a feature has been activated.

        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            SPWeb web = null;
            try
            {
                 web = properties.GetWeb();
                // _Url = web.Site.Url;
                CustomList.CreateList(web);
            }
            catch (Exception ex)
            {
                
            }
           
        }


         //Uncomment the method below to handle the event raised before a feature is deactivated.

        public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
        {
        }


        // Uncomment the method below to handle the event raised after a feature has been installed.

        //public override void FeatureInstalled(SPFeatureReceiverProperties properties)
        //{
        //}


        // Uncomment the method below to handle the event raised before a feature is uninstalled.

        //public override void FeatureUninstalling(SPFeatureReceiverProperties properties)
        //{
        //}

        // Uncomment the method below to handle the event raised when a feature is upgrading.

        //public override void FeatureUpgrading(SPFeatureReceiverProperties properties, string upgradeActionName, System.Collections.Generic.IDictionary<string, string> parameters)
        //{
        //}
    }
    public static class Extensions
    {
        /// <summary>
        /// Gets the web.
        /// </summary>
        /// <param name="properties">The properties.</param>
        /// <returns></returns>
        public static SPWeb GetWeb(this SPFeatureReceiverProperties properties)
        {
            SPWeb site;
            if (properties.Feature.Parent is SPWeb)
            {
                site = (SPWeb)properties.Feature.Parent;
            }
            else if (properties.Feature.Parent is SPSite)
            {
                site = ((SPSite)properties.Feature.Parent).RootWeb;
            }
            else
            {
                throw new Exception("Unable to retrieve SPWeb - this feature is not Site or Web-scoped.");
            }
            return site;
        }
    }

}
