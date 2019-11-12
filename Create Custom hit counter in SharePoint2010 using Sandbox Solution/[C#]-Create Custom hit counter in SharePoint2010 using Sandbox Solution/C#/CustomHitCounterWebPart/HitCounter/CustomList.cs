using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;

namespace CustomHitCounterWebPart
{
    class CustomList
    {
       
        public static void CreateList(SPWeb web)
        {
        //SPSite site = SPContext.Current.Site;
        //site.AllowUnsafeUpdates = true;
        //SPWeb web = site.RootWeb;
        web.AllowUnsafeUpdates = true;

        SPListCollection coll = web.Lists;
        SPListTemplateCollection temlcoll = web.ListTemplates;
        SPDocTemplateCollection docTemp = web.DocTemplates;
        SPFieldCollection fieldcoll = web.Fields;

        SPListTemplate temp = temlcoll[0];
       
        //SPListTemplateType.CustomGrid is a list template that works like table in ASP.NET or Excel sheet.
        Guid gd = coll.Add(Constants.listName, "A custom list to store Record data", SPListTemplateType.CustomGrid);
        coll[gd].Fields.Add(Constants.fieldUrl, SPFieldType.Note, true);
        coll[gd].Fields.Add(Constants.fieldDate, SPFieldType.Text, true);
        coll[gd].Fields.Add(Constants.fieldUser, SPFieldType.Text, true);

        //update the custom list with all those newly created fields
        coll[gd].Update();

        //create the view for display in the site - both sides must match

        string defaultquery = coll[gd].Views[0].Query;
        SPViewCollection viewcoll = coll[gd].Views;
        Guid anothergd = coll[gd].Views[0].ID;
        viewcoll.Delete(anothergd);

        System.Collections.Specialized.StringCollection viewfields = new System.Collections.Specialized.StringCollection();

        //Title field is always needed by SharePoint sites and it is always automatically created by WSS/MOSS even though you didn't tell it to
        viewfields.Add(Constants.fieldUrl);
        viewfields.Add(Constants.fieldDate);
        viewfields.Add(Constants.fieldUser);

        coll[gd].Views.Add("View name", viewfields, defaultquery, 100, true, true);
        coll[gd].Update();
        }
        
    }
}
