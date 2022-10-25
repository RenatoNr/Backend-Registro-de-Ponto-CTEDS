using Microsoft.AspNetCore.Mvc;
using Registro_de_Ponto_CTEDS.Interfaces;
using Registro_de_Ponto_CTEDS.Repositories;

namespace Registro_de_Ponto_CTEDS.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class WorkDayController : Controller
    {
        private IWorkDay _workdayRepository;

        public WorkDayController(IWorkDay workDay)
        {
            _workdayRepository = workDay;
        }


        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var workDays = _workdayRepository.GetAll();
                return Ok(workDays);
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
                var workDay = _workdayRepository.GetWorkDaysEmployee(employeeId);
                if (workDay != null)
                {
                    return Ok(workDay);
                }
                return NotFound();
            }
            catch (Exception e)
            {

                return BadRequest(e);
            }
        }
    }
}
