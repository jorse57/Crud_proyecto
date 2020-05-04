using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRUD_Proyecto.Models.DAL;
using CRUD_Proyecto.Models.Entities;
using CRUD_Proyecto.Clases;

namespace CRUD_Proyecto.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly DB_Context_P _context;

        public UsuarioController(DB_Context_P context)
        {
            _context = context;
        }


        

        // GET: Usuario

        public async Task<IActionResult> Index()
        {

            await using (_context)
            {
                IEnumerable<UsuarioDetalle> listaUsuarioDetalles =
                                                                    (from Usuario in _context.Usuarios
                                                                     join cargo in _context.CargoUsuarios
                                                                     on Usuario.Cargo equals
                                                                     cargo.IdCargo
                                                                     select new UsuarioDetalle
                                                                     {
                                                                         IdUsuario = Usuario.IdUsuario,
                                                                         Nombre = Usuario.Nombre,
                                                                         Cargo = cargo.Cargo,
                                                                         Telefono = Usuario.Telefono,
                                                                         Documento = Usuario.Documento

                                                                     }).ToList();



                return View(listaUsuarioDetalles);
            }
        }


        // GET: Usuario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.IdUsuario == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // GET: Usuario/Create
        public async Task<IActionResult> CrearEditar(int id = 0)
        {
            



            if (id == 0)
                return View(new Usuario());
            else
                return View(_context.Usuarios.Find(id));

        }


        // POST: Usuario/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CrearEditar([Bind("IdUsuario,Nombre,Documento,Cargo,Telefono")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                if (usuario.IdUsuario == 0)
                    _context.Add(usuario);
                else
                    _context.Update(usuario);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }

      
        // GET: Usuario/Delete/5
        public async Task<IActionResult> Eliminar(int? id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

       
        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.IdUsuario == id);
        }
    }
}
