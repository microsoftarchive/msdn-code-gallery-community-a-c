using Spire.Doc;
using Spire.Doc.Documents;
using Spire.Doc.Fields;

namespace AddShape
{
    class Program
    {
        static void Main(string[] args)
        {
            Document doc = new Document();
            Section sec = doc.AddSection();
            Paragraph para1 = sec.AddParagraph();

            ShapeObject shape1 = para1.AppendShape(50, 50, ShapeType.Donut);
            ShapeObject shape2 = para1.AppendShape(50, 50, ShapeType.Cube);
            shape2.Left = 100;
            ShapeObject Shape3 = para1.AppendShape(50, 50, ShapeType.Diamond);
            Shape3.Left = 200;
            ShapeObject shape4 = para1.AppendShape(50, 50, ShapeType.SmileyFace);
            shape4.Top = 100;
            ShapeObject shape5 = para1.AppendShape(50, 50, ShapeType.Moon);
            shape5.Top = 100;
            shape5.Left = 100;
            ShapeObject Shape6 = para1.AppendShape(30, 50, ShapeType.LeftArrow);
            Shape6.Top = 100;
            Shape6.Left = 200;

            doc.SaveToFile("AddShape.docx", FileFormat.Docx);
            System.Diagnostics.Process.Start("AddShape.docx");
        }
    }
}
