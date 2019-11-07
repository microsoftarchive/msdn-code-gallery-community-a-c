#region

using System;
using System.Linq;
using BTL.Infrastructure.Configuration;

#endregion

namespace BTL.Infrastructure.Extensions
{
    public static class ObjectExtension
    {
        public static void FillProperty(this object settingObject, SectionConfigurationElement element)
        {
            var objType = settingObject.GetType();
            var info = objType.GetProperties().FirstOrDefault(e => e.Name.ToLower() == element.Name.ToLower());
            if (info != null && info.CanWrite)
            {
                var provalue = Convert.ChangeType(element.Value, info.PropertyType);
                info.SetValue(settingObject, provalue, null);
            }
            else if (settingObject as ISectionConfiguration != null)
            {
                (settingObject as ISectionConfiguration).Add(element.Name, element.Value, element.KeyValuePairs);
            }
        }
    }
}