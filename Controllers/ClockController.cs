using Microsoft.AspNetCore.Mvc;

namespace Registro_de_Ponto_CTEDS.Controllers
{
    public class ClockController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
