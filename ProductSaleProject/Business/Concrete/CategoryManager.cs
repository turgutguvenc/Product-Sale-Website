using Business.Abstract;
using Business.ResponseModels.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.Constants.Messages;
using Entities.ResponseModels.Abstract;
using Entities.ResponseModels.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        public async Task<IResult> AddCategoryAsync(Category category)
        {
            if(category == null)
            {
                return new ErrorResult(ErrorMessages.EntityIsNotValid);
            }
            var result = await _categoryDal.AddAsync(category);
            if(result) {
                return new SuccessResult(SuccessMessages.EntityAdded);
            }
            return new ErrorResult(ErrorMessages.NoEntityFound);
        }

        public async Task<IResult> DeleteCategoryAsync(Category category)
        {
            if(category == null) 
            {
                return new ErrorResult(ErrorMessages.EntityIsNotValid);
            }
            var result = await _categoryDal.DeleteAsync(category);
            if(result)
            {
                return new SuccessResult(SuccessMessages.EntityDeleted);
            }
            return new ErrorResult(ErrorMessages.NoEntityFound);
        }

        public async Task<IDataResult<List<Category>>> GetAllCategoriesAsync()
        {
            var result = await _categoryDal.GetAll();
            if(result == null)
            {
                return new ErrorDataResult<List<Category>>(result, ErrorMessages.NoEntityFound);
            }
            return new SuccessDataResult<List<Category>>(result, SuccessMessages.EntityAllListed);   
        }

        public async Task<IDataResult<Category>> GetCategoryByIdAsync(int id)
        {
            var result = await _categoryDal.Get(c=> c.CategoryId == id);
            if(result == null)
            {
                new ErrorDataResult<Category>(result, ErrorMessages.NoEntityFound);
            }
            return new SuccessDataResult<Category>(result, SuccessMessages.EntityByEntityId);
        }

        public async Task<IResult> UpdateCategoryAsync(Category category)
        {
            if (category == null)
            {
                return new ErrorResult(ErrorMessages.EntityIsNotValid);
            }
            var result = await _categoryDal.UpdateAsync(category);
            if(result)
            {
                return new SuccessResult(SuccessMessages.EntityUpdated);
            }
            return new ErrorResult(ErrorMessages.NoEntityFound);
        }
    }
}
