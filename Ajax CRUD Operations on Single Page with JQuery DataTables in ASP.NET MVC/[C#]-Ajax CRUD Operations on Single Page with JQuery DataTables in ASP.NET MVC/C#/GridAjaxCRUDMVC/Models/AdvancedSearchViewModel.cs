using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace GridAjaxCRUDMVC.Models
{
    public class AdvancedSearchViewModel
    {
        [Display(Name = "Facility-Site")]
        public Guid FacilitySite { get; set; }

        [Display(Name = "Main-Location (Building)")]
        public string Building { get; set; }

        public string Manufacturer { get; set; }

        public string Status { get; set; }

        public SelectList FacilitySiteList { get; set; }
        public SelectList BuildingList { get; set; }
        public SelectList ManufacturerList { get; set; }
        public SelectList StatusList { get; set; }

    }
}
