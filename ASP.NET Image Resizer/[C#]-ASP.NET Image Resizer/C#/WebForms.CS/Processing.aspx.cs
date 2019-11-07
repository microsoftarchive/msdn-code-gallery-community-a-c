using System;
using System.Drawing;
using System.Linq.Expressions;
using System.Web.UI.WebControls;
using GleamTech.ImageUltimate;
using GleamTech.ImageUltimate.AspNet;
using GleamTech.Util;

namespace GleamTech.ImageUltimateExamples.WebForms.CS
{
    public partial class ProcessingPage : System.Web.UI.Page
    {
        protected string ImagePath;
        protected Action<ImageWebTask> TaskAction;
        protected string CodeString;

        private static readonly Expression<Action<ImageWebTask>>[] TaskExpressions = {
            task => task.ResizeWidth(300, ResizeMode.Max),
            task => task.ResizeHeight(200, ResizeMode.Max),
            task => task.Resize(300, 300, ResizeMode.Max),
            task => task.ResizeWidth(50, ResizeMode.Percentage),
            task => task.Resize(50, 60, ResizeMode.Percentage),
            task => task.Resize(300, 300, ResizeMode.Stretch),
            task => task.LiquidResize(75, 100, ResizeMode.Percentage),
            task => task.Crop(0, 0, 150, 150),
            task => task.TrimBorders(Color.Black, 10),
            task => task.Rotate(45, Color.Transparent),
            task => task.Rotate(-45, Color.Transparent),
            task => task.FlipHorizontal(),
            task => task.FlipVertical(),
            task => task.Brightness(20),
            task => task.Brightness(-20),
            task => task.Contrast(20),
            task => task.Contrast(-20),
            task => task.BrightnessContrast(20, 20),
            task => task.Enhance(),
            task => task.Blur(1),
            task => task.Sharpen(1),
            task => task.Format(ImageWebSafeFormat.Png),
            task => task.FileName("CustomNameForSEO")
        };

        protected void Page_Load(object sender, EventArgs e)
        {
            ImagePath = exampleFileSelector.SelectedFile;

            if (!IsPostBack)
                PopulateTaskSelector();

            var expression = TaskExpressions[int.Parse(TaskSelector.SelectedValue)];
            var lambda = expression.Compile();

            TaskAction = task =>
            {
                task.ResizeWidth(400);
                lambda(task);
            };

            CodeString = string.Format(
                "<%=this.ImageTag(\"{0}\", {1})%>",
                exampleFileSelector.SelectedFile.FileName,
                ExpressionStringBuilder.ToString(expression)
            );
        }

        private void PopulateTaskSelector()
        {
            for (var i = 0; i < TaskExpressions.Length; i++)
            {
                TaskSelector.Items.Add(
                    new ListItem(
                        ExpressionStringBuilder.ToString(TaskExpressions[i]), 
                        i.ToString()
                    )
                );
            }
        }
    }
}