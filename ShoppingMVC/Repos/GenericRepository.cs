using System;
using Microsoft.EntityFrameworkCore;
using ShoppingMVC.Interfaces;
using ShoppingMVC.Models;

namespace ShoppingMVC.Repos
{
	public class GenericRepository<T>:IGenericRepository<T> where T : class
	{
        protected ShoppingDbContext _dbContext;
        internal DbSet<T> _DbSet { get; set; }

		public GenericRepository(ShoppingDbContext dbContext)
		{
            _dbContext = dbContext;
            _DbSet = _dbContext.Set<T>();
		}

        public virtual Task<bool> AddEntity(T entity)
        {
            throw new NotImplementedException();

        }

        public virtual Task<bool> DeleteEntity(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual Task<List<T>> GetAllAsync()
        {
            return _DbSet.ToListAsync();
        }

        public virtual Task<T> GetAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public virtual Task<bool> UpdateEntity(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual Task<bool> ChangeEntityStatus(int id)
        {
            throw new NotImplementedException();
        }

    }
}

