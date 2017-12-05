using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LaCasaRural.Models
{
    public class Llogater
    {
        [Key]
        public int IdLlogater { get; set; }
        [StringLength(200)]
        public string NomLlogater { get; set; }
        public string CognomLlogater { get; set; }
        public int CodiPostal { get; set; }
        public string NIF { get; set; }

        public virtual List<Reserva> Reserves { get; set; } = new List<Reserva>();
    }
}