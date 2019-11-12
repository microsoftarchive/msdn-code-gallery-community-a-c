using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.IO;
using System.Net;
using System.Threading;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.UI;

using System.Web.Security;

using NReco.PdfGenerator;

namespace Controllers {
	
	public class PdfController : Controller {

		public ActionResult DemoPage() {
			return View();
		}

		[ValidateInput(false)]
		public ActionResult GeneratePdf(string htmlContent, string htmlUrl) {
			var htmlToPdf = new HtmlToPdfConverter();

			var pdfContentType = "application/pdf";
			if (!String.IsNullOrEmpty(htmlUrl)) {
				return File( htmlToPdf.GeneratePdfFromFile(htmlUrl, null), pdfContentType);
			} else {
				return File( htmlToPdf.GeneratePdf(htmlContent, null), pdfContentType);
			}
		}





	}
}
