using POC_Common;
using POC_Presentation_MVC.Models;
using POC_Presentation_MVC.ProductServiceReference;
using POC_Presentation_MVC.Utils;
using POC_Presentation_MVC.Utils.DataTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace POC_Presentation_MVC.Areas.PureMVC.Controllers
{
    public class ProductController : Controller
    {
        private ProductServiceClient productServiceClient = new ProductServiceClient();
        
        public ActionResult Index()
        {
            var listProductDto = productServiceClient.findAll();
            List<ProductModel> model = listProductDto.Select(productDto => MVCModelToDTOUtil.ToProductModelMap(productDto)).ToList();
            return View("Index", model);
        }
        
        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductModel product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ProductDTO productDTO = MVCModelToDTOUtil.ToProductDTOMap(product);
                    bool result = productServiceClient.create(productDTO);
                    if (result)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        //TODO: error
                        return View("Create");
                    }
                }
                return View("Create", product);
            }
            catch(Exception e)
            {
                return View("Create");
            }
        }

        [HttpGet]
        public ActionResult Read(int? id)
        {
            ProductModel productModel = getProductModelById(id);
            if (productModel == null)
            {
                //TODO: display error
            }
            return View(productModel);
        }
        
        [HttpGet]
        public ActionResult Update(int? id)
        {
            ProductModel productModel = getProductModelById(id);
            if (productModel == null)
            {
                //TODO: display error
            }
            return View(productModel);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(ProductModel product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ProductDTO productDTO = MVCModelToDTOUtil.ToProductDTOMap(product);
                    bool result = productServiceClient.update(productDTO);
                    if (result)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        //TODO: error
                        return View();
                    }

                }
                return View(product);
            }
            catch (Exception e)
            {
                return View();
            }

        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            ProductModel productModel = getProductModelById(id);
            if (productModel == null)
            {
                //TODO: display error
            }
            return View(productModel);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ProductModel product)
        {
            try
            {
                
                bool result = productServiceClient.delete(product.Id);
                if (result)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    //TODO: error
                    return View();
                }
            }
            catch (Exception e)
            {
                return View();
            }
        }

        private ProductModel getProductModelById(int? id)
        {
            if (!id.HasValue)
            {
                return null;
            }
            ProductDTO productDto = productServiceClient.findById(id.Value);
            if (productDto == null)
            {
                return null;
            }
            return MVCModelToDTOUtil.ToProductModelMap(productDto);
        }
    }
}