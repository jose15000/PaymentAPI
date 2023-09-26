using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaymetAPI.Data;
using PaymetAPI.Models;

namespace PaymetAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransacaosController : ControllerBase
    {
        private readonly PaymetAPIContext _context;

        public TransacaosController(PaymetAPIContext context)
        {
            _context = context;
        }

        [HttpPost(), Route("Credito")]
        public IActionResult Credito(int id, double valor)
        {
            var cliente = _context.Usuario.Find(id);

            if(cliente.Limite < valor)
            {
                return BadRequest("Saldo insuficiente");
            }

            cliente.Limite -= valor;

            _context.Usuario.Update(cliente);
            _context.SaveChanges();

            return Ok(cliente);
        }

        [HttpPost(), Route("Debito")]
        
        public IActionResult Debito(int id, double valor)
        {
            var cliente = _context.Usuario.Find(id);

            if (cliente.Saldo < valor)
            {
                return BadRequest("Saldo insuficiente");
            }

            cliente.Saldo -= valor;

            _context.Usuario.Update(cliente);
            _context.SaveChanges();

            return Ok(cliente);
        }



        [HttpPost(), Route("Transferencia")]
        public IActionResult Transferencia(int id, double valor)
        {
            var cliente_envia = _context.Usuario.Find(id);
            var cliente_recebe = _context.Usuario.Find(id);

            if(cliente_envia == null)
            {
                return NotFound("Cliente não encontrado!");
            }

            if (cliente_recebe == null)
            {
                return NotFound("Cliente não encontrado!");
            }

            var transferencia = cliente_envia.Saldo -= valor;
            var envia_dinheiro = cliente_recebe.Saldo += valor;

            _context.Update(cliente_recebe);
            _context.Update(cliente_envia);
            _context.SaveChanges();
            return Ok(cliente_envia);
        }

        [HttpGet(), Route("Saldo")]
        public IActionResult Saldo (int id)
        {
            var usuario_id = _context.Usuario.Find(id);
            return Ok(usuario_id);
        }


    }
}
