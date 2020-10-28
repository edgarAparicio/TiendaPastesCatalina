using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EdgarAparicio.PastesCatalina.Business.Entity;
using EdgarAparicio.PastesCatalina.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PastesCatalina.Controllers
{
    [Authorize]
    public class ComentariosHome : Controller
    {
        private readonly IComentarios comentariosRepositorio;

        public ComentariosHome(IComentarios comentariosRepositorio)
        {
            this.comentariosRepositorio = comentariosRepositorio;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Index(Comentarios comentarios)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            comentariosRepositorio.EnviarComentarios(comentarios);
            return RedirectToAction("ComentariosEnviados");
        }

        public ActionResult ComentariosEnviados()
        {
            return View();
        }
    }
}
