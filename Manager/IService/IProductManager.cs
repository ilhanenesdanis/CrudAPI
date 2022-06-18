using Manager.DTO;
using Manager.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.IService
{
    public interface IProductManager
    {
        void AddProducts(Products products);
        void RemoveProducts(Products products);
        void UpdateProduct(Products products);
        Products GetProducts(int id);
        List<Products> GetAllProducts();
        List<ProductsCategory> ProductsCategories();
    }
}
