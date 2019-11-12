using System.Web.Http;
using MsdrRu.CodeDiff.DiffAlgorithm;
using MsdrRu.CodeDiff.DiffVisualization;
using MsdrRu.CodeDiff.Web.AspNet461.Models;

namespace MsdrRu.CodeDiff.Web.AspNet461.Api
{
    public class VersionControlController : ApiController
    {
        [HttpPost]
        public IHttpActionResult CompareSource(CodeForCompare codeForCompare)
        {
            var diff = new Diff();
            var items = diff.DiffText(codeForCompare.Version1, codeForCompare.Version2);
            var parsed = LineParser.Parse(items, codeForCompare.Version1, codeForCompare.Version2);

            System.Threading.Thread.Sleep(1000);

            return Ok(HtmlVisualizer.Visualize(parsed));
        }
    }
}
