using System;
using System.Collections.Generic;
using System.Data.Entity;
using mvcAlbum.Models;
using System.Data.Entity.ModelConfiguration.Conventions; 


namespace mvcAlbum.Models
{
    public class ImageContext : DbContext
    {


        public DbSet<Category> Categories { get; set; }
  
        public DbSet<Image> Images { get; set; } 

        protected override void OnModelCreating(DbModelBuilder modelBuilder) 
        { 
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>(); 
        } 
    } 

    }
