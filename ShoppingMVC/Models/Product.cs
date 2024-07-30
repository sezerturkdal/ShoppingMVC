﻿using System;
using System.ComponentModel.DataAnnotations;

namespace ShoppingMVC.Models
{
	public class Product
	{
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }
		public string Description { get; set; }
		public float Price { get; set; }
	}
}

