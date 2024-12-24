using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using proyIII.Models;
using proyIII.Data;
using proyIII.Data.Migrations;

namespace proyIII.Controllers
{
    public class ContactoController : Controller
    {
        private readonly ILogger<ContactoController> _logger;
        private readonly ApplicationDbContext _context;

        public ContactoController(ILogger<ContactoController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]  // Protección contra ataques CSRF
        public IActionResult EnviarMensaje(Contacto objcontacto)
        {
            _logger.LogDebug("Ingreso a Enviar Mensaje");

            // Verifica que el modelo es válido
            if (ModelState.IsValid)
            {
                // Agrega el nuevo contacto a la base de datos
                _context.Add(objcontacto);
                _context.SaveChanges();  // Guarda los cambios en la base de datos

                // Mensaje de éxito
                ViewData["Message"] = "¡El mensaje ha sido registrado correctamente!";
            }
            else
            {
                // Si el modelo no es válido, muestra un mensaje de error
                ViewData["Message"] = "Hubo un error al registrar el contacto.";
            }

            // Retorna la vista con el mensaje
            return View("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}