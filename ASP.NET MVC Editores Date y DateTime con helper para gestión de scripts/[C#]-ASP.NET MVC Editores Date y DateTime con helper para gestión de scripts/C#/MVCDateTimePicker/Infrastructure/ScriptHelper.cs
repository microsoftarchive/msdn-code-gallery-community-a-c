using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDateTimePicker.Infrastructure
{
    public static class ScriptHelper
    {

        private const string scriptItemsKey = "ScriptBlocks";

        private enum ScriptType { Code, File }

        private class ScriptBlock
        {
            public ScriptType ScriptType { get; set; }
            public string Script { get; set; }
        }

        private static Dictionary<string, ScriptBlock> ScriptCollection(HtmlHelper html)
        {
            HttpContextBase _httpContext = html.ViewContext.HttpContext;
            if (!_httpContext.Items.Contains(scriptItemsKey))
                _httpContext.Items[scriptItemsKey] = new Dictionary<string, ScriptBlock>();
            return (Dictionary<string, ScriptBlock>)_httpContext.Items[scriptItemsKey];
        }

        public static MvcHtmlString AddScript(this HtmlHelper html, string key, string scriptCode)
        {
            Dictionary<string, ScriptBlock> scripts = ScriptCollection(html);
            if (!scripts.ContainsKey(key))
                scripts.Add(key
                    , new ScriptBlock { ScriptType = ScriptType.Code, Script = scriptCode });
            return MvcHtmlString.Empty;
        }

        public static MvcHtmlString AddScriptFile(this HtmlHelper html, string key, string scriptFile)
        {
            Dictionary<string, ScriptBlock> scripts = ScriptCollection(html);
            if (!scripts.ContainsKey(key))
                scripts.Add(key
                , new ScriptBlock { ScriptType = ScriptType.File, Script = scriptFile });
            return MvcHtmlString.Empty;
        }

        public static MvcHtmlString RenderScripts(this HtmlHelper html)
        {
            Dictionary<string, ScriptBlock> scripts = ScriptCollection(html);
            string result = string.Empty;
            foreach (ScriptBlock item in scripts.Values)
            {
                TagBuilder scriptTag = new TagBuilder("script");
                scriptTag.MergeAttribute("type", "text/javascript");
                if (item.ScriptType == ScriptType.File)
                    scriptTag.MergeAttribute("src", UrlHelper.GenerateContentUrl(item.Script, html.ViewContext.HttpContext));
                else
                    scriptTag.InnerHtml = Environment.NewLine + item.Script + Environment.NewLine;
                result += scriptTag.ToString(TagRenderMode.Normal) + Environment.NewLine;
            }
            html.ViewContext.HttpContext.Items.Remove(scriptItemsKey);
            return MvcHtmlString.Create(result);
        }
    }
}