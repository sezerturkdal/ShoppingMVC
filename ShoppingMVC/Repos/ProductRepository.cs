using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ShoppingMVC.Interfaces;
using ShoppingMVC.Models;

namespace ShoppingMVC.Repos
{
	public class ProductRepository:GenericRepository<Product>,IProductRepository
	{
		public ProductRepository(ShoppingDbContext dbContext):base(dbContext)
		{
		}

        public override Task<List<Product>> GetAllAsync()
        {
            return base.GetAllAsync();
        }

        public override async Task<Product> GetAsync(int? id)
        {
            var entity = await _DbSet.FirstOrDefaultAsync(item => item.Id == id);
            return entity;
        }

        public override async Task<bool> AddEntity(Product entity)
        {
            try
            {
                entity.CreatedBy = 1;
                entity.CreatedDate = DateTime.Now;
                entity.IsActive = true;
                await _DbSet.AddAsync(entity);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override async Task<bool> UpdateEntity(Product entity)
        {
            try
            {
                var existData = GetAsync(entity.Id).Result;
                if (existData != null)
                {
                    existData.Name = entity.Name;
                    existData.Price = entity.Price;
                    existData.Description = entity.Description;
                    existData.UpdatedDate = DateTime.Now;
                    existData.UpdatedBy = 1;
                    existData.PhotoURL = entity.PhotoURL == null ? existData.PhotoURL : entity.PhotoURL;

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override async Task<bool> DeleteEntity(Product entity)
        {
            try
            {
                var exist = GetAsync(entity.Id).Result;
                if (exist != null)
                {
                    exist.IsDeleted = true;
                    exist.UpdatedDate = DateTime.Now;
                    exist.UpdatedBy = 1;

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override async Task<bool> ChangeEntityStatus(int id)
        {
            try
            {
                var exist = GetAsync(id).Result;
                if (exist != null)
                {
                    exist.IsActive = !exist.IsActive;
                    exist.UpdatedDate = DateTime.Now;
                    exist.UpdatedBy = 1;

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}

