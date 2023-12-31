﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PaymetAPI.Data;
using PaymetAPI.Models;

namespace PaymetAPI.Controllers
{
    [Route("api/Usuario")]
    [ApiController]
    public class UsuariosController : Controller
    {

        private readonly PaymetAPIContext _context;

        public UsuariosController(PaymetAPIContext context)
        {
            _context = context;
        }

        [HttpPost (Name = "Usuario Id")]
        public IActionResult AddUsuario(Usuario usuario)
        {
            _context.Add(usuario);
            _context.SaveChanges();
            return Ok();
        }

        [HttpGet("{id}", Name = "Usuario por Id")]
        public IActionResult RetornaPorId(int id)
        {
            var usuario = _context.Usuario.Find(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Usuario usuario, int id)
        {

            var Usuario = _context.Usuario.Find(id);

            Usuario.Nome = usuario.Nome;
            Usuario.Saldo = usuario.Saldo;
            Usuario.Limite = usuario.Limite;

            _context.Update(Usuario);
            _context.SaveChanges();


            return Ok(usuario);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var usuario = _context.Usuario.Find(id);

            if (usuario == null)
            {
                return NotFound();
            }

            _context.Usuario.Remove(usuario);
            _context.SaveChanges();

            return Ok(usuario.Nome + " removido");

        }
        
        private bool UsuarioExists(int id)
        {
          return (_context.Usuario?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
