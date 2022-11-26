using Hotel.Entities.Models;
using Hotel.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.WebAPI.Controllers
{/// <summary>
 /// Users endpoints
 /// </summary>
    [ProducesResponseType(200)]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IRepository<User> _repository;

        /// <summary>
        /// Users controller
        /// </summary>
        public UsersController(IRepository<User> repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Get users
        /// </summary>
        [HttpGet]
        public IActionResult GetUsers()
        {
            var newUser = new User()
            {
                Name = "anatoly",
                Surname = "zagorovskt",
                Telephon_number = "+7129387419",
                Passport_serries_and_number = "1748 412874"
            };
            _repository.Save(newUser);
            newUser.Name = "Akiet";
            _repository.Save(newUser);
            var users = _repository.GetAll();
            return Ok(users);
        }
        /// <summary>
        /// Delete users
        /// </summary>
        /// <param name="user"></param>
        [HttpDelete]
        public IActionResult DeleteUsers(User user)
        {
            _repository.Delete(user);
            return Ok();
        }
        /// <summary>
        /// Post users
        /// </summary>
        /// <param name="user"></param>
        [HttpPost]
        public IActionResult PostUsers(User user)
        {
            var result = _repository.Save(user);
            return Ok(result);
        }

        /// <summary>
        /// Update users
        /// </summary>
        /// <param name="user"></param>
        [HttpPut]
        public IActionResult Updatesers(User user)
        {
            return PostUsers(user);
        }
    }
}
