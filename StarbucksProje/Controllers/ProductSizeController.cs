using BusinessLayer.Concrete;
using BusinessLayer.Validaitons;
using DataAccessLayer.ConCreate;
using DataAccessLayer.ConCreate.EntityFramework;
using EntityLayer;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using StarbucksProje.Models;
using StarbucksProje.PagedList;

namespace StarbucksProje.Controllers
{
    public class ProductSizeController : Controller
    {
        ProductSizeManager psm=new ProductSizeManager(new EfProductSizeRepository());
        ProductManager pm=new ProductManager(new EfProductRepository());
        SizeManager sm=new SizeManager(new EfSizeRepository());
        public IActionResult Index(int page = 1, string searchText = "")
        {
            int pageSize = 3;
            Context c = new Context();
            Pager pager;
            List<ProductSize> data;
            var itemCounts = 0;
            if (searchText != "" && searchText != null)
            {
                data = c.ProductSizes.Where(productSize => productSize.product.productName.Contains(searchText) || productSize.size.sizeName.Contains(searchText)).Skip((page - 1) * pageSize).Take(pageSize).ToList();
                itemCounts = c.ProductSizes.Where(productSize => productSize.product.productName.Contains(searchText) || productSize.size.sizeName.Contains(searchText)).ToList().Count;
            }
            else
            {
                data = c.ProductSizes.Skip((page - 1) * pageSize).Take(pageSize).ToList();
                itemCounts = c.ProductSizes.ToList().Count;
            }

            pager = new Pager(pageSize, itemCounts, page);

            ViewBag.pager = pager;
            ViewBag.actionName = "product-size-list";
            ViewBag.contrName = "ProductSize";
            ViewBag.searchText = searchText;
            return View(data);
        }
        [HttpGet]
        public IActionResult AddProductSize()
        {
            ProductSizeModel model=new ProductSizeModel();
            model.productModel=pm.productList();
            model.sizeModel = sm.sizeList();
            model.productSizeModel = new ProductSize();
            return View(model);
        }

        [HttpPost]
        public IActionResult AddProductSize(ProductSize productSize)
        {
            ProductSizeValidator validations = new ProductSizeValidator();
            var result = validations.Validate(productSize);
            if (result.IsValid)
            {
                psm.productSizeUpdate(productSize);
                return RedirectToAction("Index");
            }
            else
            {
                ProductSizeModel model = new ProductSizeModel();
                model.productModel = pm.productList();
                model.sizeModel = sm.sizeList();
                model.productSizeModel = productSize;
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(model);
            }
        }
        public IActionResult DeleteProductSize(int id)
        {
            ProductSize productSize = psm.productSizeGetById(id);
            productSize.productSizeDeleted = true;
            psm.productSizeUpdate(productSize);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateProductSize(int id)
        {
            ProductSizeModel model = new ProductSizeModel();
            model.productModel = pm.productList();
            model.sizeModel = sm.sizeList();
            model.productSizeModel=psm.productSizeGetById(id);
            return View(model);
        }
        [HttpPost]
        public IActionResult UpdateProductSize(ProductSize productSize)
        {
            ProductSizeValidator validations = new ProductSizeValidator();
            var result = validations.Validate(productSize);
            if (result.IsValid)
            {
                psm.productSizeUpdate(productSize);
                return RedirectToAction("Index");
            }
            else
            {
                ProductSizeModel model = new ProductSizeModel();
                model.productModel = pm.productList();
                model.sizeModel = sm.sizeList();
                model.productSizeModel = productSize;
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(model);
            }
        }
    }
}
