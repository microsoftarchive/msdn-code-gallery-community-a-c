using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThumbnailPagination.Models
{
    public class ThumbnailModel
    {
        public string ThumbnailLabel { get; set; }
        public string ThumbnailTabId { get; set; }
        public int ThumbnailTabNo { get; set; }
        public string Thumbnail_Aria_Controls { get; set; }
        public string Thumbnail_Href { get; set; }
        public string Thumbnail_ItemPosition { get; set; }

        public List<ThumbnailDetails> ThumbnailDetailsList { get; set; }
    }
}