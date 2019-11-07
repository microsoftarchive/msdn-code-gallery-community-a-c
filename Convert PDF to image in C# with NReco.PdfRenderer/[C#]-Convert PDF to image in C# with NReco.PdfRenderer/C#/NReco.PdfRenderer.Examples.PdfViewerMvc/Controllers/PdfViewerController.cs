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

using NReco.PdfRenderer;

namespace Controllers {
	
	public class PdfViewerController : Controller {

		public ActionResult Index() {
			return View();
		}

		public ActionResult GetPdfPageImage(int page) {
			var pdfFilePath = HttpContext.Server.MapPath("~/App_Data/Sample3.PDF");

			var pdfToImg = new PdfToImageConverter();
			pdfToImg.ScaleTo = 800;

			var memStream = new MemoryStream();
			pdfToImg.GenerateImage(pdfFilePath, page, ImageFormat.Png, memStream);
			return File( memStream.ToArray(), "image/png");
		}


	}
}
