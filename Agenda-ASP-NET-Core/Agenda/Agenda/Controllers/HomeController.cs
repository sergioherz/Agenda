using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Agenda.Models;
using MySql.Data.MySqlClient;

namespace Agenda.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Registrar()
        {
            //ViewData["Message"] = "Your application description page.";

            return View();
        }

        [HttpPost]
        public IActionResult Registrar(Contacto model)
        {
            model.Guardar();

            return Redirect("/Home/Consultar");
        }

        [HttpGet]
        public IActionResult Consultar()
        {
            List<Contacto> contactos = new Contacto().Consultar();
            return View(contactos);
        }

        [HttpGet]
        public IActionResult Eliminar(string id){
            Contacto c = new Contacto(id);
            c.Eliminar();

            return Redirect("/Home/Consultar");
        }


        [HttpGet]
        public IActionResult Editar(string id)
        {
            Contacto c = new Contacto();
            c.email = id;

            return View(c);
        }
        [HttpPost]
        public IActionResult actualizar(Contacto model)
        {
            model.Editar();

            return Redirect("/Home/Consultar");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
         return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
