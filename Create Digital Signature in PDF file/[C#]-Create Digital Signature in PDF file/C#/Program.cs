using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spire.Pdf;
using Spire.Pdf.Security;
using System.Drawing;

namespace CreateVisibleDigitalSignatureinPDF
{
    class Program
    {
        static void Main(string[] args)
        {
            PdfDocument doc = new PdfDocument(@"..\..\test.pdf");
            PdfCertificate cert = new PdfCertificate(@"..\..\Demo.pfx", "e-iceblue");
            var signature = new PdfSignature(doc, doc.Pages[0], cert, "Requestd1");
            signature.Bounds = new RectangleF(new PointF(280, 600), new SizeF(260, 90));
            signature.IsTag = true;
            signature.DigitalSignerLable = "Digitally signed by";
            signature.DigitalSigner = "Harry Hu for Test";

            signature.DistinguishedName = "DN:";
            signature.LocationInfoLabel = "Location:";
            signature.LocationInfo = "London";

            signature.ReasonLabel = "Reason: ";
            signature.Reason = "Le document est certifie";

            signature.DateLabel = "Date: ";
            signature.Date = DateTime.Now;

            signature.ContactInfoLabel = "Contact: ";
            signature.ContactInfo = "123456789";

            signature.Certificated = false;

            signature.ConfigGraphicType = ConfiguerGraphicType.Picture;
            signature.ConfiguerGraphicPath = "..\\..\\img1.png";
            signature.DocumentPermissions = PdfCertificationFlags.ForbidChanges;
            doc.SaveToFile(@"..\..\sample.pdf");
            System.Diagnostics.Process.Start(@"..\..\sample.pdf");





        }
    }
}
