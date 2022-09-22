using Microsoft.AspNetCore.Mvc;

namespace Registro_de_Ponto_CTEDS.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
