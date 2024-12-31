using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalROnionArchitecture.Application.Dtos.ProductDto;
using SignalROnionArchitecture.Application.Services;
using SignalROnionArchitecture.Core.Entities;
using SignalROnionArchitecture.Infrastructure;

namespace SignalROnionArchitecture.Presentation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public ProductController(IProductService productService, IMapper mapper, ApplicationDbContext context)
        {
            _productService = productService;
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public IActionResult ProductList()
        {
            var products = _productService.TGetListAll();
            var result = _mapper.Map<List<ResultProductDto>>(products);
            return Ok(result);
        }

        [HttpGet("ProductCount")]
        public IActionResult ProductCount()
        {
            var count = _productService.TProductCount();
            return Ok(count);
        }

        [HttpGet("ProductListWithCategory")]
        public IActionResult ProductListWithCategory()
        {
            var values = _context.Products.Include(x => x.Category)
                .Select(y => new ResultProductWithCategory
                {
                    Description = y.Description,
                    ImageUrl = y.ImageUrl,
                    Price = y.Price,
                    ProductID = y.ProductID,
                    ProductName = y.ProductName,
                    ProductStatus = y.ProductStatus,
                    CategoryName = y.Category.CategoryName
                }).ToList();

            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto createProductDto)
        {
            var product = _mapper.Map<Product>(createProductDto);
            _productService.TAdd(product);
            return Ok("Ürün bilgisi eklendi.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = _productService.TGetByID(id);
            if (product == null)
                return NotFound("Ürün bulunamadı.");

            _productService.TDelete(product);
            return Ok("Ürün bilgisi silindi.");
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var product = _productService.TGetByID(id);
            if (product == null)
                return NotFound("Ürün bulunamadı.");

            var result = _mapper.Map<GetProductDto>(product);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDto updateProductDto)
        {
            var product = _mapper.Map<Product>(updateProductDto);
            var existingProduct = _productService.TGetByID(product.ProductID);
            if (existingProduct == null)
                return NotFound("Ürün bulunamadı.");

            _productService.TUpdate(product);
            return Ok("Ürün bilgisi güncellendi.");
        }

        [HttpGet("GetLast9Products")]
        public IActionResult GetLast9Products()
        {
            var products = _productService.TGetLast9Products();
            return Ok(products);
        }
    }
}
