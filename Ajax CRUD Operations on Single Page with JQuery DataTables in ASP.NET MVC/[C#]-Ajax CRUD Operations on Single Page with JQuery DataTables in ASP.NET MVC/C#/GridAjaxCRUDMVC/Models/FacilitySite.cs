using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace GridAjaxCRUDMVC.Models
{
    public class FacilitySite
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public System.Guid FacilitySiteID { get; set; }
        [Display(Name = "Facility-Site")]
        public string FacilityName { get; set; }
        public bool IsActive { get; set; }
        public System.Guid CreatedBy { get; set; }
        [Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedAt { get; set; }
        public System.Guid? ModifiedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
