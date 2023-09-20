using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PaymetAPI.Models;

namespace PaymetAPI.Data
{
    public class PaymetAPIContext : DbContext
    {
        public PaymetAPIContext (DbContextOptions<PaymetAPIContext> options)
            : base(options)
        {
        }

        public DbSet<PaymetAPI.Models.Usuario> Usuario { get; set; } = default!;
    }
}
