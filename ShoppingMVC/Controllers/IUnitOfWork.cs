using System;
using ShoppingMVC.Interfaces;

namespace ShoppingMVC.Controllers
{
	public interface IUnitOfWork
	{
		IProductRepository productRepository { get; }
		Task CompleteAsync();
	}
}

