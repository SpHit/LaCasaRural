using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaCasaRural.Models
{
    public class Reserva
    {
        public int IdReserva { get; set; }
        public DateTime DataEntrada { get; set; }
        
        public int IdLlogater { get; set; }
        public virtual Llogater Llogater { get; set; }
    }
}