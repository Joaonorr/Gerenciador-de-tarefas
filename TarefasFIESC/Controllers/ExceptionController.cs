using Microsoft.AspNetCore.Mvc;

namespace TarefasFIESC.Controllers;

public class ExceptionController : Controller
{
    public IActionResult ComportamentoInesperado()
    {
        return View();
    }
}
