using GTR_Assign.Context;
using GTR_Assign.Interface.Manager;
using GTR_Assign.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Identity.Client;
using System.Net;

namespace GTR_Assign.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        //EshopDbContext _bdContext;
        IProductManager _productManager;

        public ProductController(IProductManager productManager)
        {
            //_bdContext = bdContext;
            _productManager = productManager;
        }
        [HttpGet]
        public List<Product> GetProducts()
        {
            var products = _productManager.GetAll().ToList();
            return products;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var posts = _productManager.GetAll().OrderBy(c => c.Name).ToList();
                return Ok (posts);



            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            
        }
        [HttpGet("id")]
        public IActionResult GetByeId(int id)
        {
            try
            {
                var products = _productManager.GetById(id);
                if (products == null)
                {
                    return Ok("Data not found");
                }
                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("text")]
        public IActionResult SearchProduct(string text)
        {
            try
            {
                var posts = _productManager.SearchProduct(text);
                return Ok(posts);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPost]
        public IActionResult Add(Product product)
        {
            try
            {
               // product.CreatedDate = DateTime.Now;
                bool isSaved = _productManager.Add(product);
                //_dbContext.Posts.Add(product);
                
                if (isSaved)
                {
                    return Created("Created..", product);
                    //return Ok(product);
                }
                return BadRequest("Post save failed.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut]
        public IActionResult Edit(Product product)
        {
            try
            {
                if (product.Id == 0)
                {
                    return BadRequest("Id is missing.");
                }
                bool isUpdate = _productManager.Update(product);
                if (isUpdate)
                {
                    return Ok(product);
                }
                return BadRequest("Post updated failed.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("id")]
        public IActionResult Delete(int id)
        {
            try
            {
                var product = _productManager.GetById(id);
                if (product == null)
                {
                    return BadRequest("Data not found");
                }
                bool isDelete = _productManager.Delete(product);
                if (isDelete)
                {
                    return Ok("Post has been deleted.");
                }
                return BadRequest("Post deletd failed.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }





    }
}
