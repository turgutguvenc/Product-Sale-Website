using AutoMapper;
using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Entities.ResponseModels.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet("getallcatories")]
        public async Task<ActionResult<DataResult<List<Category>>>> GetAllCategories()
        {
            var result = await _categoryService.GetAllCategoriesAsync();
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DataResult<Category>>> GetSingleCategory(int id)
        {
            var result = await _categoryService.GetCategoryByIdAsync(id);
            if(result.Success)
            {
                return Ok(result);  
            }
            return NotFound(result.Message);
        }
        [HttpPost("addnewcategory")]
        public async Task<ActionResult<Result>> CreateCategory(AddCategoryDto addCategoryDto)
        {
            var finalCategory = _mapper.Map<Category>(addCategoryDto);
            var result = await _categoryService.AddCategoryAsync(finalCategory);
            if (result.Success)
            {
                var createdFinalCategory = _mapper.Map<CategoryDto>(finalCategory);
                return Ok(createdFinalCategory);
            }
            return BadRequest(result.Message);
        }
        [HttpPut("update")]
        public async Task<ActionResult<Result>> UpdateCategory(Category category)
        {
            var result = await _categoryService.UpdateCategoryAsync(category);  
            if(result.Success)
            {
                return Ok(result);
            }
            return NotFound(result.Message);
        }
        [HttpDelete("delete")]
        public async Task<ActionResult<Result>> DeleteCategory(Category category)
        {
            var result = await _categoryService.DeleteCategoryAsync(category);
            if(result.Success)
            {
                return Ok(result);
            }
            return NotFound(result.Message);
        }
    }
}
