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
        [Display(Name = "Nom del llogater")]
        public string NomLlogater { get; set; }
        [Display(Name = "Cognoms del llogater")]
        public string CognomLlogater { get; set; }
        [Display(Name = "Codi Postal")]
        public int CodiPostal { get; set; }
        [Display(Name = "NIF")]
        public string NIF { get; set; }

        public virtual List<Reserva> Reserves { get; set; } = new List<Reserva>();
    }
}