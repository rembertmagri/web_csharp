using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using POC_Common;
using POC_Common.DataTables;
using POC_WebAPI.Models;
using POC_WebAPI.Utils;
using ProductServiceReference;

namespace POC_WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {

        private IProductService productServiceClient;

        public ProductController(IProductService productServiceClient)
        {
            this.productServiceClient = productServiceClient;
        }

        // GET api/product
        [HttpGet]
        public IActionResult Get()
        {
            ProductDTO[] listProductDto = productServiceClient.findAllAsync().GetAwaiter().GetResult();
            List<ProductModel> model = listProductDto.Select(productDto => MVCModelToDTOUtil.ToProductModelMap(productDto)).ToList();
            return Ok(model);
        }

        // GET api/product/5
        [HttpGet("{id}", Name = "GetProduct")]
        public IActionResult Get(int id)
        {
            return getProductModelById(id);
        }

        // POST api/product
        [HttpPost]
        public IActionResult Post([FromForm]ProductModel product)
        {
            ProductDTO productDTO = MVCModelToDTOUtil.ToProductDTOMap(product);
            bool result = productServiceClient.createAsync(productDTO).GetAwaiter().GetResult();
            if (!result)
            {
                return BadRequest();
            }
            return CreatedAtRoute("GetProduct", new { id = product.Id }, product);
            
        }

        // PUT api/product/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromForm]ProductModel product)
        {
            ProductDTO productDTO = MVCModelToDTOUtil.ToProductDTOMap(product);
            bool result = productServiceClient.updateAsync(productDTO).GetAwaiter().GetResult();
            if (!result)
            {
                return BadRequest();
            }
            return NoContent();
        }

        // DELETE api/product/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            bool result = productServiceClient.deleteAsync(id).GetAwaiter().GetResult();
            if (!result)
            {
                return BadRequest();
            }
            return NoContent();
        }

        private IActionResult getProductModelById(int id)
        {
            ProductDTO productDto = productServiceClient.findByIdAsync(id).GetAwaiter().GetResult();
            if (productDto == null)
            {
                return NotFound();
            }
            return Ok(MVCModelToDTOUtil.ToProductModelMap(productDto));
        }

        #region datatableMethod

        // GET api/product/getdatatable?draw=1&columns...
        [Route("GetDataTable")]
        [HttpGet]
        public IActionResult GetDataTable([FromQuery]jQueryDataTableParamModel param)
        {
            ContainerDTO<ProductDTO> productContainerDto = productServiceClient.findAllPagedAsync(param.start, param.length).GetAwaiter().GetResult();
            List<ProductModel> data = productContainerDto.list.Select(productDto => MVCModelToDTOUtil.ToProductModelMap(productDto)).ToList();
            jQueryDataTableData<ProductModel> dataTableResponse = new jQueryDataTableData<ProductModel>(param.draw, productContainerDto.total, data);
            return Ok(dataTableResponse);
        }

        #endregion
    }
}
