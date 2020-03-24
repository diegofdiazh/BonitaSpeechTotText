using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BonitaSpeechTotText.Models.Data
{
    public class Turno
    {
        public int Id { get; set; }
        public int TotalPiezas { get; set; }
        public int IdCamion { get; set; }
        public DateTime? FechaCreacion { get; set; }

    }
}