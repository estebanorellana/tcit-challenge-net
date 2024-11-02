using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using web.Models;

namespace web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<Services.Persona> personas = new Services.Persona().List();
            ViewBag.Persona = personas;
            return View();
        }

        [HttpPost]
        public string Agregar(string nombre, string descripcion)
        {
            return new Services.Persona().Add(new Services.Persona() { Nombre = nombre, Descripcion = descripcion });
        }

        [HttpPost]
        public string Eliminar(int id)
        {
            return new Services.Persona().Delete(id);
        }
    }
}