using Microsoft.AspNetCore.Mvc;
using Registro_de_Ponto_CTEDS.Interfaces;
using Registro_de_Ponto_CTEDS.Models;
using Registro_de_Ponto_CTEDS.Repositories;

namespace Registro_de_Ponto_CTEDS.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private IUser _userRepository;

        public UserController(IUser user)
        {
            _userRepository = user;
        }

        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                var users = _userRepository.GetAll();
                return Ok(users);
            }
            catch (Exception)
            {
                return NotFound("Não existe usuários cadastrados.");
            }

        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            try
            {
                _userRepository.Create(user);
                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest(e);
            }

        }
    }
}
