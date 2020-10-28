using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EdgarAparicio.PastesCatalina.Business.Entity.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace PastesCatalina.Controllers
{
    [Authorize]  //Solo los usuarios autenticados podran hacer uso de esta funcionalidad
    public class AdminController : Controller
    {
        private readonly UserManager<IdentityUser> userManagerRepositorio;

        public AdminController(UserManager<IdentityUser> userManager) //Inyeccion de dependencias
        {
            this.userManagerRepositorio = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        //Metodo para recuperar todos los usuarios
        public IActionResult UserManagment()
        {
            var usuarios = userManagerRepositorio.Users;
            return View(usuarios);
        }

        public IActionResult AgregarUsuario()
        {
            return View();
        }

        public async Task<IActionResult> AgregarUsuario(AgregarUsuarioViewModel agregarUsuarioViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(agregarUsuarioViewModel);
            }
            var usuario = new IdentityUser()
            {
                UserName = agregarUsuarioViewModel.UserName,
                Email = agregarUsuarioViewModel.Email
            };

            IdentityResult resultado = await userManagerRepositorio.CreateAsync(usuario, agregarUsuarioViewModel.Password);

            if (resultado.Succeeded)
            {
                return RedirectToAction("UserManagment", userManagerRepositorio.Users);
            }

            foreach(IdentityError error in resultado.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View(agregarUsuarioViewModel);
        }

        public async Task<IActionResult> EditarUsuario(string id)
        {
            var usuario = await userManagerRepositorio.FindByIdAsync(id);

            if(usuario == null)
            {
                return RedirectToAction("UserManagment", userManagerRepositorio.Users);
            }
            return View(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> EditarUsuario(string id, string UserName, string Email)
        {
            var usuario = await userManagerRepositorio.FindByIdAsync(id);
            if(usuario != null)
            {
                usuario.UserName = UserName;
                usuario.Email = Email;

                var resultado = await userManagerRepositorio.UpdateAsync(usuario);

                if (resultado.Succeeded)
                {
                    return RedirectToAction("UserManagment", userManagerRepositorio.Users);
                }

                ModelState.AddModelError("", "Usuario no actualizado, algo salio mal");

                return View(usuario);
            
            }

            return RedirectToAction("UserManagment", userManagerRepositorio.Users);
        }

        [HttpPost]
        public async Task<IActionResult> EliminarUsuario(string idUsuario)
        {
            IdentityUser usuario = await userManagerRepositorio.FindByIdAsync(idUsuario);

            if(usuario != null)
            {
                IdentityResult resultado = await userManagerRepositorio.DeleteAsync(usuario);
                if (resultado.Succeeded)
                {
                    return RedirectToAction("UserManagment");
                }
                else
                {
                    ModelState.AddModelError("", "Algo salio mal mientra se eleiminaba el usuario");
                }
            }
            else
            {
                ModelState.AddModelError("", "El usaurio no pudo ser encotrado");
            }

            return View("UserManagment", userManagerRepositorio.Users);
        }
    }
}
