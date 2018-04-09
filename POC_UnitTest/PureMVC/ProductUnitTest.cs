using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using POC_Presentation_MVC.Areas.PureMVC.Controllers;
using System.Web.Mvc;
using POC_Presentation_MVC.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace POC_UnitTest
{
    [TestClass]
    public class ProductUnitTest
    {
        [TestMethod]
        public void Index_Get_AsksForIndexView()
        {
            // Arrange
            var controller = new ProductController();
            // Act
            ViewResult result = controller.Index() as ViewResult;
            // Assert
            Assert.AreEqual("Index", result.ViewName);
        }

        [TestMethod]
        public void Index_Get_CheckModel()
        {
            // Arrange
            var controller = new ProductController();
            // Act
            ViewResult result = controller.Index() as ViewResult;
            // Assert
            var model = result.ViewData.Model as List<ProductModel>;
            Assert.IsNotNull(model);
        }

        [TestMethod]
        public void Create_Get_AsksForIndexView()
        {
            // Arrange
            var controller = new ProductController();
            // Act
            ViewResult result = controller.Create() as ViewResult;
            // Assert
            Assert.AreEqual("Create", result.ViewName);
        }

        [TestMethod]
        public void Create_Post_InsertNewProductModelStateError()
        {
            // Arrange
            var controller = new ProductController();
            ProductModel product = new ProductModel();
            controller.ModelState.AddModelError("key", "error");
            // Act
            ViewResult result = controller.Create(product) as ViewResult;
            // Assert
            Assert.AreEqual("Create", result.ViewName);
        }

        [TestMethod]
        public void Create_Post_InsertNewProductMissingName()
        {
            // Arrange
            ProductModel product = new ProductModel()
            {
                //Name="",
                Price=1,
                Quantity=1
            };
            var validationResults = new List<ValidationResult>();
            // Act
            Validator.TryValidateObject(product, new ValidationContext(product), validationResults, true);
            // Assert
            Assert.AreEqual(1, validationResults.Count);
            Assert.IsTrue(validationResults[0].ErrorMessage.Contains("Name"));
        }
    }
}
