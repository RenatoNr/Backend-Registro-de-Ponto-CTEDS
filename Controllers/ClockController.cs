using Microsoft.AspNetCore.Mvc;
using Registro_de_Ponto_CTEDS.Interfaces;
using Registro_de_Ponto_CTEDS.Models;
using Registro_de_Ponto_CTEDS.Repositories;

namespace Registro_de_Ponto_CTEDS.Controllers
{

    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ClockController : Controller
    {
        private IClock _clockRepository;

        public ClockController(IClock clock)
        {
            _clockRepository = clock;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var clocks = _clockRepository.GetAll();
                return Ok(clocks);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

        }

        [HttpGet]
        [Route("GetByEmployee")]
        public IActionResult GetByEmployee(int employeeId)
        {
            try
            {
                var clock = _clockRepository.GetClocksEmployee(employeeId);
                if (clock != null)
                {
                    return Ok(clock);
                }
                return NotFound();
            }
            catch (Exception e)
            {

                return BadRequest(e);
            }
        }

        [HttpGet]
        [Route("GetTodayClock")]
        public IActionResult GetTodayClock(int employeeId)
        {
            try
            {
                var clocks = _clockRepository.GetTodayClock(employeeId);
                if (clocks !=null)
                {
                    return Ok(clocks);
                }
                return NotFound();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Post(Clock clock)
        {
            try
            {
                _clockRepository.Create(clock);
                return Ok("Registro efetuado com sucesso.");
            }
            catch (Exception e)
            {

                return BadRequest(e);
            }

        }
        [HttpPost]
        [Route("UpdateTime")]
        public IActionResult Update(int Id, int update)
        {
            try
            {
                _clockRepository.UpdateTime(Id, update);
                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest(e);
            }

        }

        //Soma horas trabalhadas de um objeto clock
        [HttpPost]
        [Route("GetSumWorkTime")]
        public IActionResult GetTime(int id)
        {
            try
            {
                var result = _clockRepository.SumWorkTime(id);
                return Ok(result);

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("WorkDay")]

        public IActionResult WorkDay(int Id)
        {
            try
            {
                var result = _clockRepository.GetMissWorkDay();

                return Ok(result);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
            
        }
    }
}
