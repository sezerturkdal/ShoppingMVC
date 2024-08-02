using System;
using ShoppingMVC.Controllers;
using ShoppingMVC.Interfaces;
using ShoppingMVC.Models;

namespace ShoppingMVC.Repos
{
	public class UnitOfWorkRepository:IUnitOfWork
	{
		
        public IProductRepository productRepository { get; private set; }
        private readonly ShoppingDbContext _dbContext;

        public UnitOfWorkRepository(ShoppingDbContext dbContext)
		{
            _dbContext = dbContext;
            productRepository = new ProductRepository(dbContext);
		}

        public async Task CompleteAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}

