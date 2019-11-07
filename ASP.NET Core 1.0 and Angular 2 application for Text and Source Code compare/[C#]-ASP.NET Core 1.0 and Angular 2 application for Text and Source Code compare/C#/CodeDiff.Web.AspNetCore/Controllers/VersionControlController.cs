using Microsoft.AspNetCore.Mvc;
using MsdrRu.CodeDiff.DiffAlgorithm;
using MsdrRu.CodeDiff.DiffVisualization;
using MsdrRu.CodeDiff.Web.AspNetCore.Models;

namespace MsdrRu.CodeDiff.Web.AspNetCore.Controllers
{
    [Route("api/[controller]")]
    public class VersionControlController : Controller
    {
        // GET: api/values
        [HttpGet]
        public DiffHtmlVisualizationResult CompareSource(CodeForCompare codeForCompare)
        {
            var diff = new Diff();
            var items = diff.DiffText(codeForCompare.Version1, codeForCompare.Version2);
            var parsed = LineParser.Parse(items, codeForCompare.Version1, codeForCompare.Version2);

            System.Threading.Thread.Sleep(1000);

            return HtmlVisualizer.Visualize(parsed);
        }
    }
}
