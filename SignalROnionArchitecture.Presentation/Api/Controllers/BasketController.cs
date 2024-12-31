using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalROnionArchitecture.Application.Dtos.BasketDto;
using SignalROnionArchitecture.Application.Services;
using SignalROnionArchitecture.Core.Entities;
using SignalROnionArchitecture.Infrastructure;
using SignalROnionArchitecture.Presentation.Api.Models;

namespace SignalROnionArchitecture.Presentation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly ApplicationDbContext _context;

        public BasketController(IBasketService basketService, ApplicationDbContext context)
        {
            _basketService = basketService;
            _context = context;
        }

        [HttpGet]
        public IActionResult GetBasketByMenuTableID(int id)
        {
            var values = _basketService.TGetBasketByMenuTableNumber(id);
            return Ok(values);
        }

        [HttpGet("BasketListByMenuTableWithProductName")]
        public IActionResult BasketListByMenuTableWithProductName(int id)
        {
            var values = _context.Baskets.Include(x => x.Product)
                .Where(y => y.MenuTableID == id)
                .Select(z => new ResultBasketListWithProducts
                {
                    BasketID = z.BasketID,
                    Count = z.Count,
                    MenuTableID = z.MenuTableID,
                    Price = z.Price,
                    ProductID = z.ProductID,
                    TotalPrice = z.TotalPrice,
                    ProductName = z.Product.ProductName
                }).ToList();

            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateBasket(CreateBasketDto createBasketDto)
        {
            var productPrice = _context.Products
                .Where(x => x.ProductID == createBasketDto.ProductID)
                .Select(y => y.Price)
                .FirstOrDefault();

            if (productPrice == default)
                return BadRequest("Geçersiz ürün.");

            _basketService.TAdd(new Basket
            {
                ProductID = createBasketDto.ProductID,
                MenuTableID = createBasketDto.MenuTableID,
                Count = 1,
                Price = productPrice,
                TotalPrice = createBasketDto.TotalPrice
            });

            return Ok("Sepet başarıyla oluşturuldu.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBasket(int id)
        {
            var value = _basketService.TGetByID(id);

            if (value == null)
                return NotFound("Sepette böyle bir ürün bulunamadı.");

            _basketService.TDelete(value);
            return Ok("Sepetteki seçilen ürün silindi.");
        }
    }
}
