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

        [HttpPost, DisableRequestSizeLimit]
        public IActionResult Post(Employee employee)
        {
            try
            {

                _employeeRepository.Create(employee);
                return Ok("Funcionário criado com sucesso!");
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
                if (result != null)
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

        [HttpGet]
        public IActionResult ListEmployees()
        {
            try
            {
                var employees = _employeeRepository.GetEmployees();
                return Ok(employees);
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
                var result = _employeeRepository.Login(cpf, password);
                return Ok(result);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }


    }
}
