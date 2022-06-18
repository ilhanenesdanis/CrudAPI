using Manager.Entity;
using Manager.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrudController : Controller
    {
        private readonly ICategoryManager _categoryManager;
        private readonly IProductManager _productManager;

        public CrudController(IProductManager productManager, ICategoryManager categoryManager)
        {
            _productManager = productManager;
            _categoryManager = categoryManager;
        }
        #region Tüm Ürünleri Listeler
        [HttpGet]
        [Route("GetAllProducts")]
        public JsonResult GetAllProducts()
        {
            var result = _productManager.GetAllProducts();
            return Json(result);
        }
        #endregion
        #region Tüm Kategorileri Listeler
        [HttpGet]
        [Route("GetAllCategory")]
        public JsonResult GetAllCategory()
        {
            var result = _categoryManager.GetAllCategories();
            return Json(result);
        }
        #endregion
        #region Ürünleri Kategori Adları ile listeler
        [HttpGet]
        [Route("GetProductCategorys")]
        public JsonResult GetProductsByCategory()
        {
            var result = _productManager.ProductsCategories();
            return Json(result);
        }
        #endregion
        #region Yeni Kategori Ekler
        [HttpPost]
        [Route("AddNewCategory")]
        public JsonResult AddCategory(Category category)
        {
            _categoryManager.AddCategory(category);
            if(category.Id > 0)
            {
                return Json("işlem Başarılı");
            }
            return Json("İşlem Başarısız");
        }
        #endregion
        #region Yeni Ürün Ekler
        [HttpPost]
        [Route("AddNewProduct")]
        public JsonResult AddNewProducs(Products products)
        {
            _productManager.AddProducts(products);
            if(products.Id > 0)
            {
                return Json("İşlem Başarılı");
            }
            return Json("İşlem Başarısız");
        }
        #endregion
        #region Ürünü Günceller
        [HttpPut]
        [Route("UpdateProducts")]
        public JsonResult UpdateProducts(Products products)
        {
            _productManager.UpdateProduct(products);
            return Json("İşlem Başarılı");
        }
        #endregion
        #region Ürünü Siler
        [HttpDelete]
        [Route("DeleteProducts")]
        public JsonResult DeleteProduct(Products products)
        {
            _productManager.RemoveProducts(products);
            return Json("İşlem Başarılı");
        }
        #endregion
        #region Kategoriyi Günceller
        [HttpPut]
        [Route("UpdateCategory")]
        public JsonResult UpdateCategory(Category category)
        {
            _categoryManager.UpdateCategory(category);
            return Json("İşlem Başarılı");
        }
        #endregion
        #region Kategoriyi Siler
        [HttpDelete]
        [Route("DeleteCategory")]
        public JsonResult DeleteCategory(Category category)
        {
            _categoryManager.RemoveCategory(category);
            return Json("İşlem Başarılı");
        }
        #endregion
    }
}
