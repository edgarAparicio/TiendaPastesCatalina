using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EdgarAparicio.PastesCatalina.Business.Entity;
using EdgarAparicio.PastesCatalina.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PastesCatalina.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPaste pastesRepositorio;
      
        private readonly ITipoSabor tipoSaborRepositorio;

        [BindProperty]
        public Paste Paste { get; set; }
        public IEnumerable<SelectListItem> TipoSaborSelectList { get; set; }

        
        public HomeController(IPaste paste, ITipoSabor tipoSabor)
        {
            this.pastesRepositorio = paste;
           
            this.tipoSaborRepositorio = tipoSabor;
        }
        public IActionResult Index()
        {
            var listaPastes = pastesRepositorio.ObtenerListaPastes();
            return View(listaPastes);
        }

        public ActionResult Detalle(int idPaste)
        {
            var paste = pastesRepositorio.ObtenerPastePorId(idPaste);
            if(paste == null)
            {
                return NotFound();
            }

            return View(paste);
        }

        public ActionResult Eliminar(int? idPaste)
        {
            if (idPaste.HasValue)
            {
                Paste = pastesRepositorio.ObtenerPastePorId(idPaste.Value);
            }
            else
            {
                Paste = new Paste();
            }
            return View(Paste);
        }
        [HttpPost]
        public ActionResult Eliminar(int idPaste)
        {
            Paste = pastesRepositorio.EliminarPaste(idPaste);
            pastesRepositorio.Commit();
            return RedirectToAction("Index");
        }

        public ActionResult Editar(int? idPaste)
        {

            if (idPaste.HasValue)
            {
                Paste = pastesRepositorio.ObtenerPastePorId(idPaste.Value);
                
            }
            else
            {
                Paste = new Paste();
            }

            return View(Paste);
        }

        [HttpPost]

        public ActionResult Editar()
        {
            if (!ModelState.IsValid)
            {

                //TipoSaborSelectList = htmlHelper.GetEnumSelectList<TipoSabor>();
                return View();
            }
            pastesRepositorio.ActualizarPaste(Paste);
            pastesRepositorio.Commit();
            return RedirectToAction("Index");

        }

        public ActionResult Crear()
        {
            ViewBag.TipoSabor = new SelectList(tipoSaborRepositorio.ObtenerListaTipoSabor(), "Id", "Nombre");
            return View();
        }
        [HttpPost]
        public ActionResult Crear(Paste pasteNuevo)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.TipoSabor = new SelectList(tipoSaborRepositorio.ObtenerListaTipoSabor(), "Id", "Nombre");
                return View();
            }
            pastesRepositorio.CrearPaste(pasteNuevo);
            pastesRepositorio.Commit();
            return RedirectToAction("Index");
        }

    }
}
