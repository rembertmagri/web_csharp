﻿using POC_Common;
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

namespace POC_Presentation_MVC.Areas.AngularJS.Controllers
{
    public class ProductController : Controller
    {
        private ProductServiceClient productServiceClient = new ProductServiceClient();
        
        public ActionResult Index()
        {
            var listProductDto = productServiceClient.findAll();
            List<ProductModel> model = listProductDto.Select(productDto => MVCModelToDTOUtil.ToProductModelMap(productDto)).ToList();
            return View(model);
        }

        [HttpGet]
        public JsonResult List()
        {
            ContainerDTO<ProductDTO> productContainerDto = productServiceClient.findAllPaged(0, 100); //TODO; implement paging
            List<ProductModel> data = productContainerDto.list.Select(productDto => MVCModelToDTOUtil.ToProductModelMap(productDto)).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Table()
        {
            return PartialView("_Table");
        }

        [HttpGet]
        public JsonResult Find(int? id)
        {
            ProductModel productModel = getProductModelById(id);
            if (productModel == null)
            {
                //TODO: display error
            }
            return Json(productModel, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Read(int? id)
        {
            ProductModel productModel = getProductModelById(id);
            if (productModel == null)
            {
                //TODO: display error
            }
            return PartialView("_Read", productModel);
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool result = productServiceClient.delete(id);
                    if (result)
                    {
                        return Json("Ok");
                    }
                }
                return Json("Error");
            }
            catch (Exception e)
            {
                return Json("Error");
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            return PartialView("_Create");
        }

        [HttpPost]
        public JsonResult Create(ProductModel product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ProductDTO productDTO = MVCModelToDTOUtil.ToProductDTOMap(product);
                    bool result = productServiceClient.create(productDTO);
                    if (result)
                    {
                        return Json("Ok");
                    }

                }
                return Json("Error");
            }
            catch (Exception e)
            {
                return Json("Error");
            }

        }

        
        
        [HttpGet]
        public ActionResult Update(int? id)
        {
            ProductModel productModel = getProductModelById(id);
            if (productModel == null)
            {
                //TODO: display error
            }
            return PartialView("_Update", productModel);
        }

        [HttpPost]
        public JsonResult Update(ProductModel product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ProductDTO productDTO = MVCModelToDTOUtil.ToProductDTOMap(product);
                    bool result = productServiceClient.update(productDTO);
                    if (result)
                    {
                        return Json("Ok");
                    }
                }
                return Json("Error");
            }
            catch (Exception e)
            {
                return Json("Error");
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
            return PartialView("_Delete", productModel);
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