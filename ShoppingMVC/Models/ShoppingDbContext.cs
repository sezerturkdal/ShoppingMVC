using System;
using Microsoft.EntityFrameworkCore;

namespace ShoppingMVC.Models
{
	public class ShoppingDbContext : DbContext
	{
		public ShoppingDbContext(DbContextOptions<ShoppingDbContext> options) : base(options)
		{
				
		}

		public DbSet<Product> Products { get; set; }
	}
}

