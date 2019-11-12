using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ASPCoreAngular2Shopping.Data
{
    public class ItemContext : DbContext
	{
		public ItemContext(DbContextOptions<ItemContext> options)
			: base(options) { }
		public ItemContext() { }
		public DbSet<ItemDetails> ItemDetails { get; set; }
	}
}
