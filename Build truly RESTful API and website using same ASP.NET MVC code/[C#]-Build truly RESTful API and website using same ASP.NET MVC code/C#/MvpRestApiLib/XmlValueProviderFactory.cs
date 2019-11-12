using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace MvpRestApiLib
{
    // Author: Richard Garside [www.nogginbox.co.uk]
    // Ref: http://www.nogginbox.co.uk/blog/xml-to-asp.net-mvc-action-method
    namespace NogginBox.MvcExtras.Providers
    {
        using System;
        using System.Collections;
        using System.Collections.Generic;
        using System.Globalization;
        using System.Web.Mvc;
        using System.Xml;
        using System.Xml.Linq;

        public class XmlValueProviderFactory : ValueProviderFactory
        {
            private static void AddToBackingStore(Dictionary<string, object> backingStore, string prefix, XElement xmlDoc)
            {
                // Check the keys to see if this is an array or an object
                var uniqueKeys = new List<String>();
                int totalCount = 0;
                foreach (XElement element in xmlDoc.Elements())
                {
                    if (!uniqueKeys.Contains(element.Name.LocalName))
                    {
                        uniqueKeys.Add(element.Name.LocalName);
                    }
                    totalCount++;
                }

                bool isArray;
                if (uniqueKeys.Count == 1)
                {
                    isArray = true;
                }
                else if (uniqueKeys.Count == totalCount)
                {
                    isArray = false;
                }
                else
                {
                    // Not sure how to deal with a XML doc that has some keys the same, but not all
                    // For now don't process this node
                    return;
                }

                // Add the elements to the backing store
                int elementCount = 0;
                foreach (XElement element in xmlDoc.Elements())
                {
                    if (element.HasElements)
                    {
                        if (isArray)
                        {
                            // Omit local name for arrays and add index instead
                            AddToBackingStore(backingStore, String.Format("{0}[{1}]", prefix, elementCount), element);
                        }
                        else
                        {
                            AddToBackingStore(backingStore, MakePropertyKey(prefix, element.Name.LocalName), element);
                        }
                    }
                    else
                    {
                        backingStore.Add(MakePropertyKey(prefix, element.Name.LocalName), element.Value);
                    }

                    elementCount++;
                }
            }

            private static XDocument GetDeserializedXml(ControllerContext controllerContext)
            {
                var contentType = controllerContext.HttpContext.Request.ContentType;
                if (!contentType.StartsWith("text/xml", StringComparison.OrdinalIgnoreCase)
                    && !contentType.StartsWith("application/xml", StringComparison.OrdinalIgnoreCase))
                {
                    // Are there any other XML mime types that are used? (Add them here)

                    // not XML request
                    return null;
                }


                XDocument xml;
                try
                {
                    var xmlReader = new XmlTextReader(controllerContext.HttpContext.Request.InputStream);
                    xml = XDocument.Load(xmlReader);
                }
                catch (Exception)
                {
                    return null;
                }


                if (xml.FirstNode == null)
                {
                    // No XML data
                    return null;
                }

                return xml;
            }

            public override IValueProvider GetValueProvider(ControllerContext controllerContext)
            {
                XDocument xmlData = GetDeserializedXml(controllerContext);
                if (xmlData == null)
                {
                    return null;
                }

                Dictionary<string, object> backingStore = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
                AddToBackingStore(backingStore, String.Empty, xmlData.Root);
                return new DictionaryValueProvider<object>(backingStore, CultureInfo.CurrentCulture);
            }

            private static string MakeArrayKey(string prefix, int index)
            {
                return prefix + "[" + index.ToString(CultureInfo.InvariantCulture) + "]";
            }

            private static string MakePropertyKey(string prefix, string propertyName)
            {
                return (String.IsNullOrEmpty(prefix)) ? propertyName : prefix + "." + propertyName;
            }
        }
    }
}
