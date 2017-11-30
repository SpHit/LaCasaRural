using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LaCasaRural.Models
{
    public class Context: DbContext
    {
        public DbSet<Llogater> Llogaters { get; set; }
        public DbSet<Reserva> Reserves { get; set; }
    }
}