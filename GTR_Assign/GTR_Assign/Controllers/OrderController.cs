using GTR_Assign.Interface.Manager;
using GTR_Assign.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GTR_Assign.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    
    public class OrderController : ControllerBase
    {
        //EshopDbContext _bdContext;
        IOrderManager _orderManager;

        public OrderController(IOrderManager orderManager)
        {
            //_bdContext = bdContext;
            _orderManager = orderManager;
        }
        [HttpGet]
        public List<Order> GetOrders()
        {
            var orders = _orderManager.GetAll().ToList();
            return orders;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var orders = _orderManager.GetAll().OrderBy(c => c.Id).ToList();
                return Ok(orders);



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
                var orders = _orderManager.GetById(id);
                if (orders == null)
                {
                    return Ok("Data not found");
                }
                return Ok(orders);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }



        [HttpPost]
        public IActionResult Add(Order order)
        {
            try
            {
                // product.CreatedDate = DateTime.Now;
                bool isSaved = _orderManager.Add(order);
                //_dbContext.Posts.Add(product);

                if (isSaved)
                {
                    return Created("Created..", order);
                    //return Ok(product);
                }
                return BadRequest("Order save failed.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut]
        public IActionResult Edit(Order order)
        {
            try
            {
                if (order.Id == 0)
                {
                    return BadRequest("Id is missing.");
                }
                bool isUpdate = _orderManager.Update(order);
                if (isUpdate)
                {
                    return Ok(order);
                }
                return BadRequest("order updated failed.");
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
                var order = _orderManager.GetById(id);
                if (order == null)
                {
                    return BadRequest("Data not found");
                }
                bool isDelete = _orderManager.Delete(order);
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

    
