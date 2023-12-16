using Entities.Concrete;
using Entities.DTOs;
using Entities.ResponseModels.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        Task<IDataResult<List<Category>>> GetAllCategoriesAsync();
        Task<IResult> AddCategoryAsync(Category category);
        Task<IResult> UpdateCategoryAsync(Category category);
        Task<IResult> DeleteCategoryAsync(Category category);
        Task<IDataResult<Category>> GetCategoryByIdAsync(int id);
    }
}
