using ChartJs.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ChartJs.Controllers
{
    public class LineChartController : Controller
    {
        // GET: LineChart
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult LineChartData()
        {
            Chart _chart = new Chart();
            _chart.labels = new string[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "Novemeber", "December" };
            _chart.datasets = new List<Datasets>();
            List<Datasets> _dataSet = new List<Datasets>();
            _dataSet.Add(new Datasets()
            {
                label = "Current Year",
                data = new int[] { 28, 48, 40, 19, 86, 27, 90, 20, 45, 65, 34, 22 },
                borderColor = new string[] { "#800080" },
                borderWidth = "1"
            });
            _chart.datasets = _dataSet;
            return Json(_chart, JsonRequestBehavior.AllowGet);
        }
        public JsonResult MultiLineChartData()
        {
            Chart _chart = new Chart();
            _chart.labels = new string[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "Novemeber", "December" };
            _chart.datasets = new List<Datasets>();
            List<Datasets> _dataSet = new List<Datasets>();
            _dataSet.Add(new Datasets()
            {
                label = "Current Year",
                data = new int[] { 28, 48, 40, 19, 86, 27, 90, 20, 45, 65, 34, 22 },
                borderColor = new string[] { "rgba(75,192,192,1)" },
                backgroundColor = new string[] { "rgba(75,192,192,0.4)" },
                borderWidth = "1"
            });
            _dataSet.Add(new Datasets()
            {
                label = "Last Year",
                data = new int[] { 65, 59, 80, 81, 56, 55, 40, 55, 66, 77, 88, 34 },
                borderColor = new string[] { "rgba(75,192,192,1)" },
                backgroundColor = new string[] { "rgba(75,192,192,0.4)" },
                borderWidth = "1"
            });
            _chart.datasets = _dataSet;
            return Json(_chart, JsonRequestBehavior.AllowGet);
        }
    }
}