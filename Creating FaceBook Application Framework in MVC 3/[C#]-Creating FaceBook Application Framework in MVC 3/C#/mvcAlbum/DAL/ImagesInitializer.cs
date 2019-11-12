using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using mvcAlbum.Models; 

namespace mvcAlbum.DAL
{
    public class ImageInitializer : DropCreateDatabaseIfModelChanges<ImageContext>
    {
        protected override void Seed(ImageContext context)
        {
            var Categorys = new List<Category>
            {
                new Category { Name = "CSI-1" },
                new Category { Name = "CSI-2" }
            };
            Categorys.ForEach(s => context.Categories.Add(s));
            context.SaveChanges();





            var Images = new List<Image>
            {
            new Image { CategoryID = 1, Description = "Image Description -1", ImageName = "Image-1", photo ="123"},
            new Image { CategoryID = 1, Description = "Image Description -3", ImageName = "Image-3", photo ="123"},
            new Image { CategoryID = 2, Description = "Image Description -2", ImageName = "Image-2", photo ="456"}
            };
            Images.ForEach(s => context.Images.Add(s));
            context.SaveChanges();



        }

    }
}