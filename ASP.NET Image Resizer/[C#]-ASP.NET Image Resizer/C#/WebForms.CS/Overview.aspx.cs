using System;
using System.Collections.Generic;
using System.Web.UI;
using GleamTech.ImageUltimate;

namespace GleamTech.ImageUltimateExamples.WebForms.CS
{
    public partial class OverviewPage : Page
    {
        protected string ImagePath;
        protected Dictionary<string, object> ImageData = new Dictionary<string, object>();
        protected Dictionary<string, Tuple<string, string>> ImageExifMetadata = new Dictionary<string, Tuple<string, string>>();
        protected Dictionary<string, Tuple<string, string>> ImageIptcMetadata = new Dictionary<string, Tuple<string, string>>();

        protected void Page_Load(object sender, EventArgs e)
        {
            ImagePath = exampleFileSelector.SelectedFile;

            using (var imageInfo = new ImageInfo(ImagePath))
            {
                ImageData.Add("Format", imageInfo.Format);
                ImageData.Add("Width", imageInfo.Width);
                ImageData.Add("Height", imageInfo.Height);
                ImageData.Add("DpiX", imageInfo.DpiX);
                ImageData.Add("DpiY", imageInfo.DpiY);
                ImageData.Add("ColorSpace", imageInfo.ColorSpace);
                ImageData.Add("ColorType", imageInfo.ColorType);
                ImageData.Add("BitDepth", imageInfo.BitDepth);
                ImageData.Add("HasAlpha", imageInfo.HasAlpha);
                ImageData.Add("ChannelCount", imageInfo.ChannelCount);

                foreach (var entry in imageInfo.ExifDictionary)
                    ImageExifMetadata.Add(entry.Tag.ToString(), Tuple.Create(entry.Value, entry.Description));

                if (ImageExifMetadata.Count == 0)
                    ImageExifMetadata.Add("", Tuple.Create("", ""));

                foreach (var entry in imageInfo.IptcDictionary)
                    ImageIptcMetadata.Add(entry.Tag.ToString(), Tuple.Create(entry.Value, entry.Description));

                if (ImageIptcMetadata.Count == 0)
                    ImageIptcMetadata.Add("", Tuple.Create("", ""));
            }
        }
    }
}