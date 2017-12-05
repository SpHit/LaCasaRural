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
        [Display(Name = "Data d'entrada")]
        public DateTime DataEntrada { get; set; }
        [Display(Name = "Data de sortida")]
        public DateTime? DataSortida { get; set; }
        
        [Display(Name = "Llogater")]
        public int IdLlogater { get; set; }
        public virtual Llogater Llogater { get; set; }
    }
}