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

namespace POC_Presentation_MVC.Controllers
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
        public JsonResult GetDataTable(jQueryDataTableParamModel param)
        {
            ContainerDTO<ProductDTO> productContainerDto = productServiceClient.findAllPaged(param.start, param.length);
            List<ProductModel> data = productContainerDto.list.Select(productDto => MVCModelToDTOUtil.ToProductModelMap(productDto)).ToList();
            jQueryDataTableData<ProductModel> dataTableresponse = new jQueryDataTableData<ProductModel>(param.draw, productContainerDto.total, data);
            return Json(dataTableresponse, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CreateModal()
        {
            return PartialView("_Create");
        }

        [HttpPost]
        public JsonResult CreateAjax(ProductModel product)
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

        [HttpPost]
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
                        return View();
                    }
                }
                return View(product);
            }
            catch(Exception e)
            {
                return View();
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
        public ActionResult ReadModal(int? id)
        {
            ProductModel productModel = getProductModelById(id);
            if (productModel == null)
            {
                //TODO: display error
            }
            return PartialView("_Read", productModel);
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

        [HttpGet]
        public ActionResult UpdateModal(int? id)
        {
            ProductModel productModel = getProductModelById(id);
            if (productModel == null)
            {
                //TODO: display error
            }
            return PartialView("_Update", productModel);
        }

        [HttpPost]
        public JsonResult UpdateAjax(ProductModel product)
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

        [HttpPost]
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

        [HttpGet]
        public ActionResult DeleteModal(int? id)
        {
            ProductModel productModel = getProductModelById(id);
            if (productModel == null)
            {
                //TODO: display error
            }
            return PartialView("_Delete", productModel);
        }

        [HttpPost]
        public JsonResult DeleteAjax(int id)
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

        [HttpPost]
        public ActionResult Delete(ProductModel product)
        {
            try
            {
                if (ModelState.IsValid)
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
                return View(product);
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