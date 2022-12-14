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
        public IActionResult Get()
        {
            try
            {
                var users = _userRepository.GetAll();
                return Ok(users);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpGet]
        [Route("GetByCpf")]
        public IActionResult GetByCpf(string cpf)
        {
            try
            {
                var user = _userRepository.GetUser(cpf);
                if (user != null)
                {
                    return Ok(user);
                }
                return NotFound("Usuário não encontrado.");
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(User user)
        {
            try
            {
                _userRepository.Create(user);
                return Ok("Usuário criado com sucesso!");
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }

        [HttpDelete]
        public IActionResult Delete(string cpf)
        {
            try
            {
                _userRepository.DeleteUser(cpf);
                return Ok("Usuário excluído com sucesso.");
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(string cpf, string password)
        {
            try
            {
                var login = _userRepository.Login(cpf, password);
                return Ok(login);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
          
        }
    }
}
