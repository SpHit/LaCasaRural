using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LaCasaRural.Models
{
    public class Reserva
    {
        [Key]
        public int IdReserva { get; set; }
        public DateTime DataEntrada { get; set; }
        public DateTime? DataSortida { get; set; }

        public int IdLlogater { get; set; }
        public virtual Llogater Llogater { get; set; }
    }
}