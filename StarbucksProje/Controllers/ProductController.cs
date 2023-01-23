﻿using BusinessLayer.Concrete;
using BusinessLayer.Validaitons;
using DataAccessLayer.ConCreate.EntityFramework;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Options;
using StarbucksProje.Models;

namespace StarbucksProje.Controllers
{
    public class ProductController : Controller
    {
        ProductManager pm = new ProductManager(new EfProductRepository());
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        public IActionResult Index()
        {
            var products=pm.productList();
            return View(products);
        }
        [HttpGet]
        public IActionResult AddProduct()
        {
            CategoryProductModel model= new CategoryProductModel();
            model.categoryModel=cm.categoryList();
            model.productModel = new Product();
            return View(model);
        }
        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            ProductValidator validations = new ProductValidator();
            var result = validations.Validate(product);
            if (result.IsValid)
            {
                pm.productInsert(product);
                return RedirectToAction("Index");
            }
            else
            {
                CategoryProductModel model = new CategoryProductModel();
                model.categoryModel = cm.categoryList();
                model.productModel = product;
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(model);
            }
        }
        public IActionResult DeleteProduct(int id)
        {
            var product = pm.productGetById(id);
            product.productDeleted = true;
            pm.productUpdate(product);
            return RedirectToAction("Index");
        }
        public IActionResult UpdateProduct(int id)
        {
            CategoryProductModel model = new CategoryProductModel();
            model.categoryModel = cm.categoryList();
            model.productModel = pm.productGetById(id);
            return View(model);
        }
        [HttpPost]
        public IActionResult UpdateProduct(Product product)
        {
            ProductValidator validations = new ProductValidator();
            var result = validations.Validate(product);
            if (result.IsValid)
            {
                pm.productUpdate(product);
                return RedirectToAction("Index");
            }
            else
            {
                CategoryProductModel model = new CategoryProductModel();
                model.categoryModel = cm.categoryList();
                model.productModel = product;
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(model);
            }
        }
    }
}
