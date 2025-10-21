using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using UD7Ej1.Models;
using UD7Ej1.Models.Data;
using UD7Ej1.Models.Entities;

namespace UD7Ej1.Controllers
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
            Persona p1 = new Persona();
            int hora = DateTime.Now.Hour;
            var fecha = DateTime.Now;
            string msg = "";

            if (hora < 12)
            {
                msg = "buenos Dias";
                
            } else if (hora >= 12)
            {
                msg = "buenas Tardes";
                
            } else if(hora >= 19)
            {
                msg = "buenas Noches";
                
            }
            ViewData["msg"] = msg;
            ViewBag.date = fecha;
            p1.nombre = "Fran";
            p1.edad = 19;
                return View(p1);
        }

        public IActionResult Lista()
        {


            //litado de las personas
            var repo = new repoPersonas();

            return View(repo.listado);
        }

        public IActionResult Detalle2()
        {
            var repo = new repoPersonas();
            return View(repo.listado[2]);
        }

        public IActionResult EditarPersona()
        {
            //litado de las personas
            var repoPers = new repoPersonas();

            //listado de los departamentos
            var repoDepa = new repoDepa();


            //persona seleccionada al azar
            Persona personaRandom;

            //random
            Random rand = new Random();

            //id random
            int idRandom = rand.Next(0, repoPers.listado.Count);

            //capturar la parsona con ese id
            personaRandom = repoPers.listado.First(persona => persona.id == idRandom);

            ViewBag.listaDepa = repoDepa.listado;

            return View(personaRandom);
        }







        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
