using System;
using ShoppingMVC.Interfaces;

namespace ShoppingMVC.Models
{
	public class BaseEntity : IBaseEntity
    {
		public BaseEntity()
		{
		}

        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
    }
}

