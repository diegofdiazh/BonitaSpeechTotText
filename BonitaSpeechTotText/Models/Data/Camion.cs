using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BonitaSpeechTotText.Models.Data
{
    public class Camion
    {
        public int Id { get; set; }
        public string Placas { get; set; }
        public string NombreConductor { get; set; }
        public bool Liberar { get; set; }
        public bool AperturarBodega { get; set; }
        public DateTime? FechaDespacho { get; set; }
        public DateTime? FechaCierre { get; set; }
    }
}