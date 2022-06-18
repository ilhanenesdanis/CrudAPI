using Manager.DTO;
using Manager.Entity;
using Manager.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Service
{
    public class ProductManager : IProductManager
    {
        private readonly Context _context;

        public ProductManager(Context context)
        {
            _context = context;
        }

        public void AddProducts(Products products)
        {
            _context.Products.Add(products);
            _context.SaveChanges();
        }

        public List<Products> GetAllProducts()
        {
            return _context.Products.ToList();
        }

        public Products GetProducts(int id)
        {
           return _context.Products.FirstOrDefault(p => p.Id == id);
        }

        public List<ProductsCategory> ProductsCategories()
        {
            var result = (from p in _context.Products.ToList()
                          join c in _context.Categories on p.CategoryId equals c.Id
                          select new ProductsCategory
                          {
                              CategoryName = c.Name,
                              Id = p.Id,
                              ProductName = p.ProductName,
                              QuantityPerUnit = p.QuantityPerUnit,
                              UnitsInPrice = p.UnitsInPrice,
                              UnitsInStock = p.UnitsInStock,
                          }).ToList();
            return result;
        }

        public void RemoveProducts(Products products)
        {
            _context.Products.Remove(products);
            _context.SaveChanges();
        }

        public void UpdateProduct(Products products)
        {
            _context.Products.Update(products);
            _context.SaveChanges();
        }
    }
}
