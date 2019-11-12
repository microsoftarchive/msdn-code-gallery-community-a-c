using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShanuWebAPIFileM.Models
{
	public class UploadFIle
	{
		public string FilePath { get; set; }
		public string FileName { get; set; }
		public long FileLength { get; set; }
	}
}