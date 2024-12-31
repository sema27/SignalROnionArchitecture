using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalROnionArchitecture.Application.Dtos.CategoryDto;
using SignalROnionArchitecture.Application.Services;
using SignalROnionArchitecture.Core.Entities;

namespace SignalROnionArchitecture.Presentation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult CategoryList()
        {
            var categories = _categoryService.TGetListAll();
            var result = _mapper.Map<List<ResultCategoryDto>>(categories);
            return Ok(result);
        }

        [HttpGet("CategoryCount")]
        public IActionResult CategoryCount()
        {
            var count = _categoryService.TCategoryCount();
            return Ok(count);
        }

        [HttpGet("ActiveCategoryCount")]
        public IActionResult ActiveCategoryCount()
        {
            var activeCount = _categoryService.TActiveCategoryCount();
            return Ok(activeCount);
        }

        [HttpGet("PassiveCategoryCount")]
        public IActionResult PassiveCategoryCount()
        {
            var passiveCount = _categoryService.TPassiveCategoryCount();
            return Ok(passiveCount);
        }

        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryDto createCategoryDto)
        {
            createCategoryDto.CategoryStatus = true;

            var category = _mapper.Map<Category>(createCategoryDto);
            _categoryService.TAdd(category);
            return Ok("Kategori başarıyla eklendi.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var category = _categoryService.TGetByID(id);
            if (category == null)
                return NotFound("Kategori bulunamadı.");

            _categoryService.TDelete(category);
            return Ok("Kategori başarıyla silindi.");
        }

        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            var category = _categoryService.TGetByID(id);
            if (category == null)
                return NotFound("Kategori bulunamadı.");

            var result = _mapper.Map<ResultCategoryDto>(category);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            var category = _categoryService.TGetByID(updateCategoryDto.CategoryID);
            if (category == null)
                return NotFound("Kategori bulunamadı.");

            var updatedCategory = _mapper.Map(updateCategoryDto, category);
            _categoryService.TUpdate(updatedCategory);
            return Ok("Kategori başarıyla güncellendi.");
        }
    }
}
