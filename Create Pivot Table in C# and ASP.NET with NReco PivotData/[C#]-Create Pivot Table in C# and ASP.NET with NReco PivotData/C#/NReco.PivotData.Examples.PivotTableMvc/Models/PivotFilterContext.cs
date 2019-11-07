using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NReco.PivotData.Examples.PivotTableMvc.Models {
	
	public class PivotFilterContext {

		public IEnumerable<SelectListItem> FilterYearItems { get; set; }
		public int FilterYear { get; set; }
	}
}