using GTR_Assign.Interface.Manager;
using GTR_Assign.Manager;
using GTR_Assign.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GTR_Assign.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class UserController : ControllerBase
    {
        //EshopDbContext _bdContext;
        IUserManager _userManager;

        public UserController(IUserManager userManager)
        {
            //_bdContext = bdContext;
            _userManager = userManager;
        }

        [HttpGet]
        public List<User> GetUsers()
        {
            var users = _userManager.GetAll().ToList();
            return users;
        }

        [HttpPost]
        public IActionResult Add(User user)
        {
            try
            {
                // product.CreatedDate = DateTime.Now;
                bool isSaved = _userManager.Add(user);
                //_dbContext.Posts.Add(product);

                if (isSaved)
                {
                    return Created("Created..", user);
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
        public IActionResult Edit(User user)
        {
            try
            {
                if (user.Id == 0)
                {
                    return BadRequest("Id is missing.");
                }
                bool isUpdate = _userManager.Update(user);
                if (isUpdate)
                {
                    return Ok(user);
                }
                return BadRequest("user updated failed.");
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
                var user = _userManager.GetById(id);
                if (user == null)
                {
                    return BadRequest("Data not found");
                }
                bool isDelete = _userManager.Delete(user);
                if (isDelete)
                {
                    return Ok("User has been deleted.");
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
