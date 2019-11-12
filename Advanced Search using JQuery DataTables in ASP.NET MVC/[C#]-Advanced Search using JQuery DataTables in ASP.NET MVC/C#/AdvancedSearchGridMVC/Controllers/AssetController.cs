using System;
using GridAdvancedSearchMVC.Models;
using System.Linq;
using System.Linq.Dynamic;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using DataTables.Mvc;
using System.Collections.Generic;

namespace GridAdvancedSearchMVC.Controllers
{
    public class AssetController : Controller
    {

        private ApplicationDbContext _dbContext;

        public ApplicationDbContext DbContext
        {
            get
            {
                return _dbContext ?? HttpContext.GetOwinContext().Get<ApplicationDbContext>();
            }
            private set
            {
                _dbContext = value;
            }

        }

        public AssetController()
        {

        }

        public AssetController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: Asset
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Get([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel, AdvancedSearchViewModel searchViewModel)
        {
            IQueryable<Asset> query = DbContext.Assets;
            var totalCount = query.Count();

            // searching and sorting
            query = SearchAssets(requestModel, searchViewModel, query);
            var filteredCount = query.Count();

            // Paging
            query = query.Skip(requestModel.Start).Take(requestModel.Length);



            var data = query.Select(asset => new
            {
                AssetID = asset.AssetID,
                BarCode = asset.Barcode,
                Manufacturer = asset.Manufacturer,
                ModelNumber = asset.ModelNumber,
                Building = asset.Building,
                RoomNo = asset.RoomNo,
                Quantity = asset.Quantity
            }).ToList();

            return Json(new DataTablesResponse(requestModel.Draw, data, filteredCount, totalCount), JsonRequestBehavior.AllowGet);

        }


        private IQueryable<Asset> SearchAssets(IDataTablesRequest requestModel, AdvancedSearchViewModel searchViewModel, IQueryable<Asset> query)
        {

            // Apply filters
            if (requestModel.Search.Value != string.Empty)
            {
                var value = requestModel.Search.Value.Trim();
                query = query.Where(p => p.Barcode.Contains(value) ||
                                         p.Manufacturer.Contains(value) ||
                                         p.ModelNumber.Contains(value) ||
                                         p.Building.Contains(value)
                                   );
            }

            /***** Advanced Search ******/
            if (searchViewModel.FacilitySite != Guid.Empty)
                query = query.Where(x => x.FacilitySiteID == searchViewModel.FacilitySite);

            if (searchViewModel.Building != null)
                query = query.Where(x => x.Building == searchViewModel.Building);

            if (searchViewModel.Manufacturer != null)
                query = query.Where(x => x.Manufacturer == searchViewModel.Manufacturer);

            if (searchViewModel.Status != null)
            {
                bool Issued = bool.Parse(searchViewModel.Status);
                query = query.Where(x => x.Issued == Issued);
            }

            /***** Advanced Search ******/

            var filteredCount = query.Count();

            // Sort
            var sortedColumns = requestModel.Columns.GetSortedColumns();
            var orderByString = String.Empty;

            foreach (var column in sortedColumns)
            {
                orderByString += orderByString != String.Empty ? "," : "";
                orderByString += (column.Data) + (column.SortDirection == Column.OrderDirection.Ascendant ? " asc" : " desc");
            }

            query = query.OrderBy(orderByString == string.Empty ? "BarCode asc" : orderByString);

            return query;

        }

        [HttpGet]
        public ActionResult AdvancedSearch()
        {
            var advancedSearchViewModel = new AdvancedSearchViewModel();

            advancedSearchViewModel.FacilitySiteList = new SelectList(DbContext.FacilitySites
                                                                    .Where(facilitySite => facilitySite.IsActive && !facilitySite.IsDeleted)
                                                                    .Select(x => new { x.FacilitySiteID, x.FacilityName }),
                                                                      "FacilitySiteID",
                                                                      "FacilityName");

            advancedSearchViewModel.BuildingList = new SelectList(DbContext.Assets
                                                                           .GroupBy(x => x.Building)
                                                                           .Where(x => x.Key != null && !x.Key.Equals(string.Empty))
                                                                           .Select(x => new { Building = x.Key }),
                                                                  "Building",
                                                                  "Building");

            advancedSearchViewModel.ManufacturerList = new SelectList(DbContext.Assets
                                                                               .GroupBy(x => x.Manufacturer)
                                                                               .Where(x => x.Key != null && !x.Key.Equals(string.Empty))
                                                                               .Select(x => new { Manufacturer = x.Key }),
                                                                      "Manufacturer",
                                                                      "Manufacturer");

            advancedSearchViewModel.StatusList = new SelectList(new List<SelectListItem>
            {
                                                                  new SelectListItem { Text="Issued",Value=bool.TrueString},
                                                                  new SelectListItem { Text="Not Issued",Value = bool.FalseString}
                                                                  },
                                                                  "Value",
                                                                  "Text"
                                                                );

            return View("_AdvancedSearchPartial", advancedSearchViewModel);
        }

    }
}