namespace SBDBTControlCS.Common
{
    public class Settings
    {
        public static string DeviceName
        {
            get
            {
                if (Windows.Storage.ApplicationData.Current.LocalSettings.Values.ContainsKey("DeviceName"))
                {
                    if (Windows.Storage.ApplicationData.Current.LocalSettings.Values["DeviceName"].ToString().Length > 0)
                    {
                        return Windows.Storage.ApplicationData.Current.LocalSettings.Values["DeviceName"].ToString();
                    }
                    else
                    {
                        return "SBDBT-001bdc05bf3f";
                    }
                }
                else
                {
                    return "SBDBT-001bdc05bf3f";
                }
            }
            set
            {
                if (value != null)
                {
                    Windows.Storage.ApplicationData.Current.LocalSettings.Values["DeviceName"] = value;
                }
                else
                {
                    Windows.Storage.ApplicationData.Current.LocalSettings.Values["DeviceName"] = "";
                }
            }
        }
    }
}
