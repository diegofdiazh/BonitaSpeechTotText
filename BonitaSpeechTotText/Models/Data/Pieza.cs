using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BonitaSpeechTotText.Models.Data
{
    public class Pieza
    {
        public int Id { get; set; }
        public string Guia { get; set; }
        public string Manifesto { get; set; }
        public string TipoPieza { get; set; }
        public string TipoServicio { get; set; }
        public int CantidadEnvios { get; set; }
        public string Aerolinea { get; set; }
        public string PaisOrigen { get; set; }
        public double Peso { get; set; }
        public bool Consolidada { get; set; }    
        public DateTime? FechaDespacho { get; set; }
    }
}