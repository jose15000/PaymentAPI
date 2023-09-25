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

        [HttpPost(Name = "Credito")]
        public IActionResult Credito(Transacao transacao)
        {
            var valor = transacao.Valor;

            _context.Transacao.Add(transacao);

            return Ok();
        }
    }
}
