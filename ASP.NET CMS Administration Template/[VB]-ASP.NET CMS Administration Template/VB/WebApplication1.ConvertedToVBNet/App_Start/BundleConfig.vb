Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Optimization

Public Class BundleConfig
	Public Shared Sub RegisterBundles(bundles As BundleCollection)
		bundles.Add(New ScriptBundle("~/bundles/WebFormsJs").Include("~/Scripts/WebForms/WebForms.js", "~/Scripts/WebForms/WebUIValidation.js", "~/Scripts/WebForms/MenuStandards.js", "~/Scripts/WebForms/Focus.js", "~/Scripts/WebForms/GridView.js", "~/Scripts/WebForms/DetailsView.js", _
			"~/Scripts/WebForms/TreeView.js", "~/Scripts/WebForms/WebParts.js"))

		bundles.Add(New ScriptBundle("~/bundles/MsAjaxJs").Include("~/Scripts/WebForms/MsAjax/MicrosoftAjax.js", "~/Scripts/WebForms/MsAjax/MicrosoftAjaxCore.js", "~/Scripts/WebForms/MsAjax/MicrosoftAjaxSerialization.js", "~/Scripts/WebForms/MsAjax/MicrosoftAjaxNetwork.js", "~/Scripts/WebForms/MsAjax/MicrosoftAjaxWebServices.js", "~/Scripts/WebForms/MsAjax/MicrosoftAjaxApplicationServices.js", _
			"~/Scripts/WebForms/MsAjax/MicrosoftAjaxComponentModel.js", "~/Scripts/WebForms/MsAjax/MicrosoftAjaxGlobalization.js", "~/Scripts/WebForms/MsAjax/MicrosoftAjaxTimer.js", "~/Scripts/WebForms/MsAjax/MicrosoftAjaxHistory.js", "~/Scripts/WebForms/MsAjax/MicrosoftAjaxWebForms.js"))

		bundles.Add(New ScriptBundle("~/bundles/modernizr").Include("~/Scripts/modernizr-*"))

		bundles.Add(New StyleBundle("~/Content/css").Include("~/Content/site.css"))

		bundles.Add(New StyleBundle("~/Content/themes/base/css").Include("~/Content/themes/base/jquery.ui.core.css", "~/Content/themes/base/jquery.ui.resizable.css", "~/Content/themes/base/jquery.ui.selectable.css", "~/Content/themes/base/jquery.ui.accordion.css", "~/Content/themes/base/jquery.ui.autocomplete.css", "~/Content/themes/base/jquery.ui.button.css", _
			"~/Content/themes/base/jquery.ui.dialog.css", "~/Content/themes/base/jquery.ui.slider.css", "~/Content/themes/base/jquery.ui.tabs.css", "~/Content/themes/base/jquery.ui.datepicker.css", "~/Content/themes/base/jquery.ui.progressbar.css", "~/Content/themes/base/jquery.ui.theme.css"))
	End Sub
End Class
