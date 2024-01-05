using AppFX.API.Models;
using AppFX.API.Repository;
using Microsoft.AspNetCore.Mvc;

namespace AppFX.API.Controllers
    {
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IUsersRepository _usersRepo;

        public UsersController(IUsersRepository userRepo)
        {
            _usersRepo = userRepo;
        }
        
        [HttpGet]
        public IQueryable Get()
        {
            return _usersRepo.GetUsers();
        }

       
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Users user)
        {
            if (user == null)
                return BadRequest(ModelState);
            if (_usersRepo.UserExists(user.Username))
            {
                ModelState.AddModelError("", "User already Exist");
                return StatusCode(500, ModelState);
            }

            if (!_usersRepo.CreateUser(user))
            {
                ModelState.AddModelError("", $"Something went wrong while saving user record of {user.Username }");
                return StatusCode(500, ModelState);
            }

            return Ok(user);

        }

      
        [HttpPut("{userId:int}")]
        public IActionResult Update(int userId, [FromBody] Users user)
        {
            if (user == null || userId != user.IDUser)
                return BadRequest(ModelState);

            if (!_usersRepo.UpdateUser(user))
            {
                ModelState.AddModelError("", $"Something went wrong while updating user : {user.Username}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
       

        [HttpDelete("{userId:int}")]
        public IActionResult Delete(int userId)
        {
            if (!_usersRepo.UserExists(userId))
            {
                return NotFound();
            }

            var userobj = _usersRepo.GetUser(userId);

            if (!_usersRepo.DeleteUser(userobj))
            {
                ModelState.AddModelError("", $"Something went wrong while deleting user : {userobj.Username}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

    }
}
