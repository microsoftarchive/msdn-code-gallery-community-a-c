using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SharePointMvc.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            using (var sp = new SharePointContext())
            {
                var categories = sp.Categories.OrderBy(c => c.Name);
                return View(categories);
            }
        }

        // GET: /discussion/{category}
        [Route("discussion/{category}")]
        public ActionResult Discussion(string category)
        {
            using (var sp = new SharePointContext())
            {
                var discussionList = sp.DiscussionList.Where(d => d.Category.Name == category);
                return View(discussionList);
            }
        }
    }
}