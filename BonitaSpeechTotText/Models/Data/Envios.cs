using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BonitaSpeechTotText.Models.Data
{
    public class Envios
    {
        public int Id { get; set; }
        public int IdPieza { get; set; }
        public string Guia { get; set; }
        public string NombreDestinatario { get; set; }
        public string DireccionDestinatario { get; set; }
        public string CiudadDestinatario { get; set; }
        public string PaisOrigen { get; set; }
        public string PaisDestino { get; set; }
        public double ValorDeclarado { get; set; }
        public double PesoFisico { get; set; }
        public string Telefono { get; set; }
        public string PosicionArancela { get; set; }
        public string Producto { get; set; }
        public string TipoServicio { get; set; }
        public string EstadoFisico { get; set; }
        public string NumeroReserva { get; set; }
        public string NombreRemitente { get; set; }
        public string CiudadRemitente { get; set; }
        public string DireccionRemitente { get; set; }     
        public string PropuestaValor { get; set; } 
        public DateTime? FechaCreacion { get; set; }      
    
      
    }
}