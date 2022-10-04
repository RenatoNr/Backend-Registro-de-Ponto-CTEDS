using Microsoft.AspNetCore.Mvc;
using Registro_de_Ponto_CTEDS.Interfaces;
using Registro_de_Ponto_CTEDS.Models;

namespace Registro_de_Ponto_CTEDS.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly IEmployee _employeeRepository;

        public EmployeeController(IEmployee employeeRepository)
        {
            _employeeRepository = employeeRepository;

        }

        [HttpPost]
        public IActionResult Post([FromForm] Employee employee, IFormFile photo)
        {
            try
            {
                _employeeRepository.Create(employee, photo);
                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest(e);
            }
        }
        [HttpGet]
        [Route("GetByCpf")]
        public IActionResult GetEmployee(string cpf)
        {
            try
            {
                var result = _employeeRepository.GetEmployeeByCpf(cpf);
                if(result != null)
                {
                    result.Password = "";
                    return Ok(result);
                }
                return BadRequest();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }


    }
}
