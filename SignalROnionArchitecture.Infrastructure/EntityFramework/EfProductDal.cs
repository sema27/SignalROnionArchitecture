using Microsoft.EntityFrameworkCore;
using SignalROnionArchitecture.Application;
using SignalROnionArchitecture.Core.Entities;
using SignalROnionArchitecture.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalROnionArchitecture.Infrastructure.EntityFramework
{
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        private readonly ApplicationDbContext _context;

        public EfProductDal(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public List<Product> GetLast9Products()
        {
            var values = _context.Products.Take(9).ToList();
            return values;
        }

        public List<Product> GetProductsWithCategories()
        {
            var values = _context.Products.Include(x => x.Category).ToList();
            return values;
        }

        public decimal ProductAvgPriceByHamburger()
        {
            return _context.Products.Where(x => x.CategoryID == (_context.Categories.Where(y => y.CategoryName == "Hamburger").Select(z => z.CategoryID).FirstOrDefault())).Average(w => w.Price);
        }

        public int ProductCount()
        {
            return _context.Products.Count();
        }

        public int ProductCountByCategoryNameDrink()
        {
            return _context.Products.Where(x => x.CategoryID == (_context.Categories.Where(y => y.CategoryName == "İçecek").Select(z => z.CategoryID).FirstOrDefault())).Count();
        }

        public int ProductCountByCategoryNameHamburger()
        {
            return _context.Products.Where(x => x.CategoryID == (_context.Categories.Where(y => y.CategoryName == "Hamburger").Select(z => z.CategoryID).FirstOrDefault())).Count();
        }

        public string ProductNameByMaxPrice()
        {
            return _context.Products.Where(x => x.Price == (_context.Products.Max(y => y.Price))).Select(z => z.ProductName).FirstOrDefault();
        }

        public string ProductNameByMinPrice()
        {
            return _context.Products.Where(x => x.Price == (_context.Products.Min(y => y.Price))).Select(z => z.ProductName).FirstOrDefault();
        }

        public decimal ProductPriceAvg()
        {
            return _context.Products.Average(x => x.Price);
        }

        public decimal ProductPriceBySteakBurger()
        {
            return _context.Products.Where(x => x.ProductName == "Steak Burger").Select(y => y.Price).FirstOrDefault();
        }

        public decimal TotalPriceByDrinkCategory()
        {
            int id = _context.Categories.Where(x => x.CategoryName == "İçecek").Select(y => y.CategoryID).FirstOrDefault();
            return _context.Products.Where(x => x.CategoryID == id).Sum(y => y.Price);
        }

        public decimal TotalPriceBySaladCategory()
        {
            int id = _context.Categories.Where(x => x.CategoryName == "Salata").Select(y => y.CategoryID).FirstOrDefault();
            return _context.Products.Where(x => x.CategoryID == id).Sum(y => y.Price);
        }
    }
}