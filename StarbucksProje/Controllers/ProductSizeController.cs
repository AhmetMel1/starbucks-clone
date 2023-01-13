﻿using BusinessLayer.Concrete;
using BusinessLayer.Validaitons;
using DataAccessLayer.ConCreate.EntityFramework;
using EntityLayer;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using StarbucksProje.Models;

namespace StarbucksProje.Controllers
{
    public class ProductSizeController : Controller
    {
        ProductSizeManager psm=new ProductSizeManager(new EfProductSizeRepository());
        ProductManager pm=new ProductManager(new EfProductRepository());
        SizeManager sm=new SizeManager(new EfSizeRepository());
        public IActionResult ListProductSize()
        {
            var pruductSizes=psm.productSizeList();
            return View(pruductSizes);
        }
        [HttpGet]
        public IActionResult AddProductSize()
        {
            ProductSizeModel model=new ProductSizeModel();
            model.productModel=pm.productList();
            model.sizeModel = sm.sizeList();
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
                return RedirectToAction("ListProductSize");
            }
            else
            {
                ProductSizeModel model = new ProductSizeModel();
                model.productModel = pm.productList();
                model.sizeModel = sm.sizeList();
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
            return RedirectToAction("ListProductSize");
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
                return RedirectToAction("ListProductSize");
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
