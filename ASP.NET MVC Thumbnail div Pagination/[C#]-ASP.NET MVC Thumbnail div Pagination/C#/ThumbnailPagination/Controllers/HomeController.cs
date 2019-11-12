using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThumbnailPagination.Models;

namespace ThumbnailPagination.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // Tab Data
            ThumbnailViewModel model = new ThumbnailViewModel();
            model.ThumbnailModelList = new List<ThumbnailModel>();

            // Test Details Data 
            List<ThumbnailDetails> _detaisllist = new List<ThumbnailDetails>();
            int count = 10;
            for (int i = 1; i <= count; i++)
            {
                ThumbnailDetails obj = new ThumbnailDetails();
                obj.Details1 = "Details- Main" + i;
                obj.Details2 = "Details- Main-Sub" + i;
                _detaisllist.Add(obj);
            }

            // batch your List data for tab view i want batch by 2 you can set your value

            var listOfBatches = _detaisllist.Batch(2);

            int tabNo = 1;

            foreach (var batchItem in listOfBatches)
            {
                // Generating tab
                ThumbnailModel obj = new ThumbnailModel();
                obj.ThumbnailLabel = "Lebel" + tabNo;
                obj.ThumbnailTabId = "tab" + tabNo;
                obj.ThumbnailTabNo = tabNo;
                obj.Thumbnail_Aria_Controls = "tab" + tabNo;
                obj.Thumbnail_Href = "#tab" + tabNo;

                // batch details

                obj.ThumbnailDetailsList = new List<ThumbnailDetails>();

                foreach (var item in batchItem)
                {
                    ThumbnailDetails detailsObj = new ThumbnailDetails();
                    detailsObj = item;
                    obj.ThumbnailDetailsList.Add(detailsObj);
                }

                model.ThumbnailModelList.Add(obj);

                tabNo++;
            }

            // Getting first tab data
            var first = model.ThumbnailModelList.FirstOrDefault();
            
            // Getting first tab data
            var last = model.ThumbnailModelList.LastOrDefault();

            foreach (var item in model.ThumbnailModelList)
            {
                if (item.ThumbnailTabNo == first.ThumbnailTabNo)
                {
                    item.Thumbnail_ItemPosition = "first";
                }

                if (item.ThumbnailTabNo == last.ThumbnailTabNo)
                {
                    item.Thumbnail_ItemPosition = "last";
                }

            }

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}