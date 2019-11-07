using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Drawing;

// Use EVO PDF Namespace
using EvoPdf.HtmlToPdfClient;

namespace EvoHtmlToPdfDemo.PDF_Creator
{
    public partial class Graphic_Elements : System.Web.UI.Page
    {
        protected void createPdfButton_Click(object sender, EventArgs e)
        {
            // Get the server IP and port
            String serverIP = textBoxServerIP.Text;
            uint serverPort = uint.Parse(textBoxServerPort.Text);

            // Create a PDF document
            Document pdfDocument = new Document(serverIP, serverPort);

            // Set optional service password
            if (textBoxServicePassword.Text.Length > 0)
                pdfDocument.ServicePassword = textBoxServicePassword.Text;

            // Set license key received after purchase to use the converter in licensed mode
            // Leave it not set to use the converter in demo mode
            pdfDocument.LicenseKey = "4W9+bn19bn5ue2B+bn1/YH98YHd3d3c=";

            // The titles font used to mark various sections of the PDF document
            PdfFont titleFont = new PdfFont("Times New Roman", 12, true);
            titleFont.Bold = true;

            // Create a PDF page in PDF document
            PdfPage pdfPage = pdfDocument.AddPage();

            // Line Elements

            // Add section title
            TextElement titleTextElement = new TextElement(5, 5, "Line Elements", titleFont);
            titleTextElement.ForeColor = RgbColor.Black;
            pdfPage.AddElement(titleTextElement);

            // Add a line with default properties
            LineElement lineElement = new LineElement(0, 0, 50, 0);
            pdfDocument.AddElement(lineElement, 10);

            // Add a bold line
            LineElement boldLineElement = new LineElement(0, 0, 50, 0);
            boldLineElement.LineStyle.LineWidth = 3;
            pdfDocument.AddElement(boldLineElement, 10, true, false, 0, true, false);

            // Add dotted line
            LineElement dottedLineElement = new LineElement(0, 0, 50, 0);
            dottedLineElement.LineStyle.LineDashStyle = LineDashStyle.Dot;
            dottedLineElement.ForeColor = RgbColor.Green;
            pdfDocument.AddElement(dottedLineElement, 10, true, false, 0, true, false);

            // Add a dashed line
            LineElement dashedLineElement = new LineElement(0, 0, 50, 0);
            dashedLineElement.LineStyle.LineDashStyle = LineDashStyle.Dash;
            dashedLineElement.ForeColor = RgbColor.Green;
            pdfDocument.AddElement(dashedLineElement, 10, true, false, 0, true, false);

            // Add a dash-dot-dot line
            LineElement dashDotDotLineElement = new LineElement(0, 0, 50, 0);
            dashDotDotLineElement.LineStyle.LineDashStyle = LineDashStyle.DashDotDot;
            dashDotDotLineElement.ForeColor = RgbColor.Green;
            pdfDocument.AddElement(dashDotDotLineElement, 10, true, false, 0, true, false);

            // Add a bold line with rounded cap style
            LineElement roundCapBoldLine = new LineElement(0, 0, 50, 0);
            roundCapBoldLine.LineStyle.LineWidth = 5;
            roundCapBoldLine.LineStyle.LineCapStyle = LineCapStyle.RoundCap;
            roundCapBoldLine.ForeColor = RgbColor.Blue;
            pdfDocument.AddElement(roundCapBoldLine, 10, true, false, 0, true, false);

            // Add a bold line with projecting square cap style
            LineElement projectingSquareCapBoldLine = new LineElement(0, 0, 50, 0);
            projectingSquareCapBoldLine.LineStyle.LineWidth = 5;
            projectingSquareCapBoldLine.LineStyle.LineCapStyle = LineCapStyle.ProjectingSquareCap;
            projectingSquareCapBoldLine.ForeColor = RgbColor.Blue;
            pdfDocument.AddElement(projectingSquareCapBoldLine, 10, true, false, 0, true, false);

            // Add a bold line with projecting butt cap style
            LineElement buttCapBoldLine = new LineElement(0, 0, 50, 0);
            buttCapBoldLine.LineStyle.LineWidth = 5;
            buttCapBoldLine.LineStyle.LineCapStyle = LineCapStyle.ButtCap;
            buttCapBoldLine.ForeColor = RgbColor.Blue;
            pdfDocument.AddElement(buttCapBoldLine, 10, true, false, 0, true, false);

            // Line Join Styles

            // Add section title
            titleTextElement = new TextElement(0, 0, "Line Join and Cap Styles", titleFont);
            titleTextElement.ForeColor = RgbColor.Black;
            pdfDocument.AddElement(titleTextElement, 5, false, 10, true);

            // Add graphic path with miter join line style
            PathElement miterJoinPath = new PathElement(new PointFloat(0, 50));
            // Add path lines
            miterJoinPath.AddLineSegment(new PointFloat(25, 0));
            miterJoinPath.AddLineSegment(new PointFloat(50, 50));
            // Set path style
            miterJoinPath.LineStyle.LineWidth = 5;
            miterJoinPath.LineStyle.LineCapStyle = LineCapStyle.ProjectingSquareCap;
            miterJoinPath.LineStyle.LineJoinStyle = LineJoinStyle.MiterJoin;
            miterJoinPath.ForeColor = RgbColor.Coral;
            pdfDocument.AddElement(miterJoinPath, 5, false, 10, true);

            // Add graphic path with round join line style
            PathElement roundJoinPath = new PathElement(new PointFloat(0, 50));
            // Add path lines
            roundJoinPath.AddLineSegment(new PointFloat(25, 0));
            roundJoinPath.AddLineSegment(new PointFloat(50, 50));
            // Set path style
            roundJoinPath.LineStyle.LineWidth = 5;
            roundJoinPath.LineStyle.LineCapStyle = LineCapStyle.RoundCap;
            roundJoinPath.LineStyle.LineJoinStyle = LineJoinStyle.RoundJoin;
            roundJoinPath.ForeColor = RgbColor.Coral;
            pdfDocument.AddElement(roundJoinPath, 20, true, false, 0, true, false);


            // Add graphic path with bevel join line style
            PathElement bevelJoinPath = new PathElement(new PointFloat(0, 50));
            // Add lines to path
            bevelJoinPath.AddLineSegment(new PointFloat(25, 0));
            bevelJoinPath.AddLineSegment(new PointFloat(50, 50));
            // Set path style
            bevelJoinPath.LineStyle.LineWidth = 5;
            bevelJoinPath.LineStyle.LineCapStyle = LineCapStyle.ButtCap;
            bevelJoinPath.LineStyle.LineJoinStyle = LineJoinStyle.BevelJoin;
            bevelJoinPath.ForeColor = RgbColor.Coral;
            // Add element to document
            pdfDocument.AddElement(bevelJoinPath, 20, true, false, 0, true, false);

            // Add a polygon with miter join line style
            PointFloat[] polygonPoints = new PointFloat[]{ 
                                new PointFloat(0, 50),  
                                new PointFloat(25, 0), 
                                new PointFloat(50, 50)};
            PolygonElement miterJoinPolygon = new PolygonElement(polygonPoints);
            // Set polygon style
            miterJoinPolygon.LineStyle.LineWidth = 5;
            miterJoinPolygon.LineStyle.LineJoinStyle = LineJoinStyle.MiterJoin;
            miterJoinPolygon.ForeColor = RgbColor.Green;
            miterJoinPolygon.BackColor = RgbColor.AliceBlue;
            pdfDocument.AddElement(miterJoinPolygon, 20, true, false, 0, true, false);

            // Add a polygon with round join line style
            polygonPoints = new PointFloat[]{ 
                                new PointFloat(0, 50),  
                                new PointFloat(25, 0), 
                                new PointFloat(50, 50)};
            PolygonElement roundJoinPolygon = new PolygonElement(polygonPoints);
            // Set polygon style
            roundJoinPolygon.LineStyle.LineWidth = 5;
            roundJoinPolygon.LineStyle.LineJoinStyle = LineJoinStyle.RoundJoin;
            roundJoinPolygon.ForeColor = RgbColor.Green;
            roundJoinPolygon.BackColor = RgbColor.Blue;
            pdfDocument.AddElement(roundJoinPolygon, 20, true, false, 0, true, false);

            // Add a polygon with bevel join line style
            polygonPoints = new PointFloat[]{ 
                                new PointFloat(0, 50),  
                                new PointFloat(25, 0), 
                                new PointFloat(50, 50)};
            PolygonElement bevelJoinPolygon = new PolygonElement(polygonPoints);
            // Set polygon style
            bevelJoinPolygon.LineStyle.LineWidth = 5;
            bevelJoinPolygon.LineStyle.LineJoinStyle = LineJoinStyle.BevelJoin;
            bevelJoinPolygon.ForeColor = RgbColor.Green;
            bevelJoinPolygon.BackColor = RgbColor.Blue;
            pdfDocument.AddElement(bevelJoinPolygon, 20, true, false, 0, true, false);


            // Add a Graphics Path Element

            // Add section title
            titleTextElement = new TextElement(0, 0, "Path Elements", titleFont);
            titleTextElement.ForeColor = RgbColor.Black;
            pdfDocument.AddElement(titleTextElement, 5, false, 10, true);

            // Create the path 
            PathElement graphicsPath = new PathElement(new PointFloat(0, 0));
            // Add line and Bezier curve segments
            graphicsPath.AddLineSegment(new PointFloat(50, 50));
            graphicsPath.AddBezierCurveSegment(new PointFloat(100, 0), new PointFloat(200, 100), new PointFloat(250, 50));
            graphicsPath.AddLineSegment(new PointFloat(300, 0));
            // Close path
            graphicsPath.ClosePath = true;
            // Set path style
            graphicsPath.LineStyle.LineWidth = 3;
            graphicsPath.LineStyle.LineJoinStyle = LineJoinStyle.MiterJoin;
            graphicsPath.LineStyle.LineCapStyle = LineCapStyle.RoundCap;
            graphicsPath.ForeColor = RgbColor.Green;
            //graphicsPath.BackColor = Color.Green;
            graphicsPath.Gradient = new GradientColor(GradientDirection.Vertical, RgbColor.LightGreen, RgbColor.Blue);
            // Add element to document
            pdfDocument.AddElement(graphicsPath, 5, false, 10, true);


            // Add Circle Elements

            // Add section title
            titleTextElement = new TextElement(0, 0, "Circle Elements", titleFont);
            titleTextElement.ForeColor = RgbColor.Black;
            pdfDocument.AddElement(titleTextElement, 5, false, 10, true);

            // Add a Circle Element with default settings
            CircleElement circleElement = new CircleElement(30, 30, 30);
            pdfDocument.AddElement(circleElement, 10);

            // Add dotted circle element
            CircleElement dottedCircleElement = new CircleElement(30, 30, 30);
            dottedCircleElement.ForeColor = RgbColor.Green;
            dottedCircleElement.LineStyle.LineDashStyle = LineDashStyle.Dot;
            pdfDocument.AddElement(dottedCircleElement, 10, true, false, 0, true, false);

            // Add a disc
            CircleElement discElement = new CircleElement(30, 30, 30);
            discElement.ForeColor = RgbColor.Green;
            discElement.BackColor = RgbColor.LightGray;
            pdfDocument.AddElement(discElement, 10, true, false, 0, true, false);

            // Add disc with bold border
            CircleElement discWithBoldBorder = new CircleElement(30, 30, 30);
            discWithBoldBorder.LineStyle.LineWidth = 5;
            discWithBoldBorder.BackColor = RgbColor.Coral;
            discWithBoldBorder.ForeColor = RgbColor.Blue;
            pdfDocument.AddElement(discWithBoldBorder, 10, true, false, 0, true, false);

            // Add colored disc with bold border
            for (int i = 30; i > 0; i = i - 3)
            {
                CircleElement coloredDisc = new CircleElement(30, 30, i);
                coloredDisc.LineStyle.LineWidth = 3;
                switch ((i / 3) % 7)
                {
                    case 0:
                        coloredDisc.BackColor = RgbColor.Red;
                        break;
                    case 1:
                        coloredDisc.BackColor = RgbColor.Orange;
                        break;
                    case 2:
                        coloredDisc.BackColor = RgbColor.Yellow;
                        break;
                    case 3:
                        coloredDisc.BackColor = RgbColor.Green;
                        break;
                    case 4:
                        coloredDisc.BackColor = RgbColor.Blue;
                        break;
                    case 5:
                        coloredDisc.BackColor = RgbColor.Indigo;
                        break;
                    case 6:
                        coloredDisc.BackColor = RgbColor.Violet;
                        break;
                    default:
                        break;
                }
                if (i == 30)
                    pdfDocument.AddElement(coloredDisc, 10, true, false, 0, true, false);
                else
                    pdfDocument.AddElement(coloredDisc, 3, true, true, 3, true, false);
            }

            // Add a doughnut
            CircleElement exteriorNoBorderDisc = new CircleElement(30, 30, 30);
            exteriorNoBorderDisc.BackColor = RgbColor.Coral;
            pdfDocument.AddElement(exteriorNoBorderDisc, 40, true, false, -30, true, false);

            CircleElement interiorNoBorderDisc = new CircleElement(30, 30, 15);
            interiorNoBorderDisc.BackColor = RgbColor.White;
            pdfDocument.AddElement(interiorNoBorderDisc, 15, true, true, 15, true, false);

            // Add a simple disc
            CircleElement simpleDisc = new CircleElement(30, 30, 30);
            simpleDisc.BackColor = RgbColor.Green;
            pdfDocument.AddElement(simpleDisc, 25, true, false, -15, true, false);


            // Add Ellipse Elements

            // Add section title
            titleTextElement = new TextElement(0, 0, "Ellipse Elements", titleFont);
            titleTextElement.ForeColor = RgbColor.Black;
            pdfDocument.AddElement(titleTextElement, 5, false, 10, true);

            // Add an Ellipse Element with default settings
            EllipseElement ellipseElement = new EllipseElement(50, 30, 50, 30);
            pdfDocument.AddElement(ellipseElement, 5, false, 10, true);

            // Add an Ellipse Element with background color and line color
            EllipseElement ellipseWithBackgroundAndBorder = new EllipseElement(50, 30, 50, 30);
            ellipseWithBackgroundAndBorder.BackColor = RgbColor.LightGray;
            ellipseWithBackgroundAndBorder.ForeColor = RgbColor.Green;
            pdfDocument.AddElement(ellipseWithBackgroundAndBorder, 10, true, false, 0, true, false);

            // Create an ellipse from multiple Ellipse Arc Elements
            EllipseArcElement ellipseArcElement1 = new EllipseArcElement(0, 0, 100, 60, 0, 100);
            ellipseArcElement1.ForeColor = RgbColor.Coral;
            ellipseArcElement1.LineStyle.LineWidth = 3;
            pdfDocument.AddElement(ellipseArcElement1, 10, true, false, 0, true, false);

            EllipseArcElement ellipseArcElement2 = new EllipseArcElement(0, 0, 100, 60, 100, 100);
            ellipseArcElement2.ForeColor = RgbColor.Blue;
            ellipseArcElement2.LineStyle.LineWidth = 3;
            pdfDocument.AddElement(ellipseArcElement2, 0, true, true, 0, true, false);

            EllipseArcElement ellipseArcElement3 = new EllipseArcElement(0, 0, 100, 60, 180, 100);
            ellipseArcElement3.ForeColor = RgbColor.Green;
            ellipseArcElement3.LineStyle.LineWidth = 3;
            pdfDocument.AddElement(ellipseArcElement3, 0, true, true, 0, true, false);

            EllipseArcElement ellipseArcElement4 = new EllipseArcElement(0, 0, 100, 60, 270, 100);
            ellipseArcElement4.ForeColor = RgbColor.Violet;
            ellipseArcElement4.LineStyle.LineWidth = 3;
            pdfDocument.AddElement(ellipseArcElement4, 0, true, true, 0, true, false);

            // Create an ellipse from multiple Ellipse Slice Elements
            EllipseSliceElement ellipseSliceElement1 = new EllipseSliceElement(0, 0, 100, 60, 0, 90);
            ellipseSliceElement1.BackColor = RgbColor.Coral;
            pdfDocument.AddElement(ellipseSliceElement1, 10, true, false, 0, true, false);

            EllipseSliceElement ellipseSliceElement2 = new EllipseSliceElement(0, 0, 100, 60, 90, 90);
            ellipseSliceElement2.BackColor = RgbColor.Blue;
            pdfDocument.AddElement(ellipseSliceElement2, 0, true, true, 0, true, false);

            EllipseSliceElement ellipseSliceElement3 = new EllipseSliceElement(0, 0, 100, 60, 180, 90);
            ellipseSliceElement3.BackColor = RgbColor.Green;
            pdfDocument.AddElement(ellipseSliceElement3, 0, true, true, 0, true, false);


            EllipseSliceElement ellipseSliceElement4 = new EllipseSliceElement(0, 0, 100, 60, 270, 90);
            ellipseSliceElement4.BackColor = RgbColor.Violet;
            pdfDocument.AddElement(ellipseSliceElement4, 0, true, true, 0, true, false);

            // Add an Ellipse Element with background
            EllipseElement ellipseWithBackground = new EllipseElement(0, 0, 50, 30);
            ellipseWithBackground.BackColor = RgbColor.Green;
            pdfDocument.AddElement(ellipseWithBackground, 10, true, false, 0, true, false);


            // Add Rectangle Elements

            // Add section title
            titleTextElement = new TextElement(0, 0, "Rectangle Elements", titleFont);
            titleTextElement.ForeColor = RgbColor.Black;
            pdfDocument.AddElement(titleTextElement, 5, false, 10, true);

            // Add a Rectangle Element with default settings
            RectangleElement rectangleElement = new RectangleElement(0, 0, 100, 60);
            pdfDocument.AddElement(rectangleElement, 10);

            // Add a Rectangle Element with background color and dotted line
            RectangleElement rectangleElementWithDottedLine = new RectangleElement(0, 0, 100, 60);
            rectangleElementWithDottedLine.BackColor = RgbColor.LightGray;
            rectangleElementWithDottedLine.ForeColor = RgbColor.Green;
            rectangleElementWithDottedLine.LineStyle.LineDashStyle = LineDashStyle.Dot;
            pdfDocument.AddElement(rectangleElementWithDottedLine, 10, true, false, 0, true, false);

            // Add a Rectangle Element with background color without border
            RectangleElement rectangleElementWithoutBorder = new RectangleElement(0, 0, 100, 60);
            rectangleElementWithoutBorder.BackColor = RgbColor.Green;
            pdfDocument.AddElement(rectangleElementWithoutBorder, 10, true, false, 0, true, false);

            // Add a Rectangle Element with background color, bold border line and rounded corners
            RectangleElement rectangleElementWithRoundedCorners = new RectangleElement(0, 0, 100, 60);
            rectangleElementWithRoundedCorners.BackColor = RgbColor.Coral;
            rectangleElementWithRoundedCorners.ForeColor = RgbColor.Blue;
            rectangleElementWithRoundedCorners.LineStyle.LineWidth = 5;
            rectangleElementWithRoundedCorners.LineStyle.LineJoinStyle = LineJoinStyle.RoundJoin;
            pdfDocument.AddElement(rectangleElementWithRoundedCorners, 10, true, false, 0, true, false);


            // Add Polygon Elements

            // Add section title
            titleTextElement = new TextElement(0, 0, "Polygon Elements", titleFont);
            titleTextElement.ForeColor = RgbColor.Black;
            pdfDocument.AddElement(titleTextElement, 5, false, 10, true);

            PointFloat[] polygonElementPoints = new PointFloat[]{
                    new PointFloat(0, 50),
                    new PointFloat(50, 0),
                    new PointFloat(100, 50),
                    new PointFloat(50, 100)
                };

            // Add a Polygon Element with default settings
            PolygonElement polygonElement = new PolygonElement(polygonElementPoints);
            pdfDocument.AddElement(polygonElement, 10);

            polygonElementPoints = new PointFloat[]{
                    new PointFloat(0, 50),
                    new PointFloat(50, 0),
                    new PointFloat(100, 50),
                    new PointFloat(50, 100)
                };

            // Add a Polygon Element with background color and border
            polygonElement = new PolygonElement(polygonElementPoints);
            polygonElement.BackColor = RgbColor.LightGray;
            polygonElement.ForeColor = RgbColor.Green;
            polygonElement.LineStyle.LineDashStyle = LineDashStyle.Dot;
            pdfDocument.AddElement(polygonElement, 10, true, false, 0, true, false);

            polygonElementPoints = new PointFloat[]{
                    new PointFloat(0, 50),
                    new PointFloat(50, 0),
                    new PointFloat(100, 50),
                    new PointFloat(50, 100)
                };

            // Add a Polygon Element with background color
            polygonElement = new PolygonElement(polygonElementPoints);
            polygonElement.BackColor = RgbColor.Green;
            pdfDocument.AddElement(polygonElement, 10, true, false, 0, true, false);

            PointFloat[] polyFillPoints = new PointFloat[]{
                    new PointFloat(0, 50),
                    new PointFloat(50, 0),
                    new PointFloat(100, 50),
                    new PointFloat(50, 100)
                };

            // Add a Polygon Element with background color and rounded line joins
            PolygonElement polygonElementWithBackgruondColorAndBorder = new PolygonElement(polyFillPoints);
            polygonElementWithBackgruondColorAndBorder.ForeColor = RgbColor.Blue;
            polygonElementWithBackgruondColorAndBorder.BackColor = RgbColor.Coral;
            polygonElementWithBackgruondColorAndBorder.LineStyle.LineWidth = 5;
            polygonElementWithBackgruondColorAndBorder.LineStyle.LineCapStyle = LineCapStyle.RoundCap;
            polygonElementWithBackgruondColorAndBorder.LineStyle.LineJoinStyle = LineJoinStyle.RoundJoin;
            pdfDocument.AddElement(polygonElementWithBackgruondColorAndBorder, 10, true, false, 0, true, false);

            // Add Bezier Curve Elements

            // Add section title
            titleTextElement = new TextElement(0, 0, "Bezier Curve Elements", titleFont);
            titleTextElement.ForeColor = RgbColor.Black;
            pdfDocument.AddElement(titleTextElement, 5, false, 10, true);

            // Add a Bezier Curve Element with normal style

            BezierCurveElement bezierCurveElement = new BezierCurveElement(0, 50, 50, 0, 100, 100, 150, 50);
            bezierCurveElement.ForeColor = RgbColor.Blue;
            bezierCurveElement.LineStyle.LineWidth = 3;
            pdfDocument.AddElement(bezierCurveElement, 10);

            // Add a Bezier Curve Element with dotted line using the controlling points above

            bezierCurveElement = new BezierCurveElement(0, 50, 50, 0, 100, 100, 150, 50);
            bezierCurveElement.ForeColor = RgbColor.Green;
            bezierCurveElement.LineStyle.LineDashStyle = LineDashStyle.Dot;
            bezierCurveElement.LineStyle.LineWidth = 1;
            pdfDocument.AddElement(bezierCurveElement, 30, true, false, 0, true, false);


            // Mark the points controlling the Bezier curve
            CircleElement controlPoint1 = new CircleElement(0, 0, 10);
            controlPoint1.BackColor = RgbColor.Violet;
            controlPoint1.Opacity = 75;
            pdfDocument.AddElement(controlPoint1, -10, true, true, 40, true, false);

            CircleElement controlPoint2 = new CircleElement(0, 0, 10);
            controlPoint2.BackColor = RgbColor.Violet;
            pdfDocument.AddElement(controlPoint2, 50, true, true, -50, true, false);

            CircleElement controlPoint3 = new CircleElement(0, 0, 10);
            controlPoint3.BackColor = RgbColor.Violet;
            pdfDocument.AddElement(controlPoint3, 50, true, true, 100, true, false);

            CircleElement controlPoint4 = new CircleElement(0, 0, 10);
            controlPoint4.BackColor = RgbColor.Violet;
            pdfDocument.AddElement(controlPoint4, 50, true, true, -50, true, false);

            // Save the PDF document in a memory buffer
            byte[] outPdfBuffer = pdfDocument.Save();

            // Send the PDF as response to browser

            // Set response content type
            Response.AddHeader("Content-Type", "application/pdf");

            // Instruct the browser to open the PDF file as an attachment or inline
            Response.AddHeader("Content-Disposition", String.Format("attachment; filename=Graphic_Elements.pdf; size={0}", outPdfBuffer.Length.ToString()));

            // Write the PDF document buffer to HTTP response
            Response.BinaryWrite(outPdfBuffer);

            // End the HTTP response and stop the current page processing
            Response.End();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                sampleCodeLiteral.Text = System.IO.File.ReadAllText(Server.MapPath("~/DemoAppFiles/Input/Code_Samples/CSharp/AspNet/PDF_Creator/Graphic_Elements.html"));
                descriptionLiteral.Text = System.IO.File.ReadAllText(Server.MapPath("~/DemoAppFiles/Input/Descriptions/AspNet/PDF_Creator/Graphic_Elements.html"));

                Master.CollapseAll();
                Master.ExpandNode("PDF_Creator");
                Master.SelectNode("Graphic_Elements");
            }
        }

        protected void demoMenu_MenuItemClick(object sender, MenuEventArgs e)
        {
            switch (e.Item.Value)
            {
                case "Live_Demo":
                    demoMultiView.SetActiveView(liveDemoView);
                    break;
                case "Description":
                    demoMultiView.SetActiveView(descriptionView);
                    break;
                case "Sample_Code":
                    demoMultiView.SetActiveView(sampleCodeView);
                    break;
                default:
                    break;
            }
        }
    }
}