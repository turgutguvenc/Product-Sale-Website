using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCategoryDal : ICategoryDal
    {
        private readonly NorthwindDbContext _context;
        public EfCategoryDal(NorthwindDbContext context)
        {
                _context = context;
        }
        public async Task<bool> AddAsync(Category entity)
        {
            var result = await CheckCategoryExists(entity);
            if(result)
            {
                await _context.Categories.AddAsync(entity);
                await SaveChangesAsync();
            }           
            return result;
        }

        public async Task<bool> DeleteAsync(Category entity)
        {
            var result = await CheckCategoryExists(entity);
            if (result)
            {
               _context.Categories.Remove(entity);
               await SaveChangesAsync();
            }
            return result;
        }

        public async Task<Category> Get(Expression<Func<Category, bool>> filter)
        {
            return await _context.Categories.FirstOrDefaultAsync(filter);
        }

        public async Task<List<Category>> GetAll(Expression<Func<Category, bool>> filter = null)
        {
            if(filter == null)
            {
                return await _context.Categories.ToListAsync();
            }
            else
            {
               return await _context.Categories.Where(filter).ToListAsync();
            }
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()>=0);
        }

        public async Task<bool> UpdateAsync(Category entity)
        {
            var result = await _context.Categories.FirstOrDefaultAsync(c => c.CategoryId == entity.CategoryId);
            if (result != null)
            {
                result.CategoryName = entity.CategoryName;
                result.Description = entity.Description;
                await SaveChangesAsync();
            }
            return result != null;
        }

        public async Task<bool> CheckCategoryExists(Category category)
        {
            var result = await _context.Categories.FirstOrDefaultAsync(c => c.CategoryName == category.CategoryName);
            return result == null;
        }
    }
}
