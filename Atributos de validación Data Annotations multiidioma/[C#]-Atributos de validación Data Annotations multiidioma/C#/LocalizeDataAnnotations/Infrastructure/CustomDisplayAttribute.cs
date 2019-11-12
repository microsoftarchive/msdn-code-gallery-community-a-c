using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace LocalizeDataAnnotations.Infrastructure
{

    public class CustomDisplayAttribute : DisplayNameAttribute
    {

        public CustomDisplayAttribute(): base() { }

        public CustomDisplayAttribute(string displayName): base(displayName){ }

        public override string DisplayName
        {
            get
            {
                string displayName = TextosBBDD.Recuperar(base.DisplayName);
                return displayName ?? base.DisplayName;
            }
        }
        

    }
}