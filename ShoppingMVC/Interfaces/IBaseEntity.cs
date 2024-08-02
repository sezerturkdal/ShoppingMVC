using System;
namespace ShoppingMVC.Interfaces
{
	public interface IBaseEntity
	{
		public bool IsActive { get; set; }
		public bool IsDeleted { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime? UpdatedDate { get; set; }
		public int CreatedBy { get; set; }
		public int? UpdatedBy { get; set; }
	}
}

