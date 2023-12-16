using Entities.Concrete;
using Entities.DTOs;
using AutoMapper;

namespace WebAPI.Profiles
{
    public class CategoryProfile:Profile
    {
        public CategoryProfile()
        {
            CreateMap<AddCategoryDto, Category>();
            CreateMap<Category, CategoryDto>();
        }    
    }
}
