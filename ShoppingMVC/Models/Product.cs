using System;
using System.ComponentModel.DataAnnotations;
using ShoppingMVC.Interfaces;

namespace ShoppingMVC.Models
{
	public class Product : BaseEntity
	{
		[Key]
		public int Id { get; set; }
		[Required]
		[MaxLength(100)]
		public string Name { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
		public double Price { get; set; }
	}
}

