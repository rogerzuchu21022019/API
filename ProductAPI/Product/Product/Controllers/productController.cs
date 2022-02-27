using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Product.Controllers
{
    [ApiController]

    public class productController : ControllerBase
    {
        public static List<Product> productList = new List<Product>();


        //fun getAllInformationProduct

        [HttpGet("rogerzuchu")]
        public IActionResult getAllInformationProduct()
        {
            return Ok(productList);
        }

        //[Route("rogerzuchu")]
        [HttpGet("rogerzuchu/{id}")]
        public IActionResult getInformationProductByID(string id){
            try
            {
                var productID = productList.SingleOrDefault(product => product.productCode == Guid.Parse(id));
                if (productID == null)
                {
                    return NotFound();
                }
                return Ok(productID);
            }
            catch
            {
                return BadRequest();
            }
        }



        // fun create new product
        [Route("rogerzuchu")]
        [HttpPost]
        public IActionResult createNewProduct(ProductVM product){
            Product product1 = new Product
            {
                productCode = Guid.NewGuid(),
                nameProduct = product.nameProduct,
                priceProduct = product.priceProduct
            };
            productList.Add(product1);
            return Ok(new
            {
                Success=true,Data = productList
            });
        }



    }
}