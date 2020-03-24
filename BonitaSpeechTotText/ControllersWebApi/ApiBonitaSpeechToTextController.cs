using BonitaSpeechTotText.Models;
using BonitaSpeechTotText.Models.Data;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using RoutePrefixAttribute = System.Web.Http.RoutePrefixAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using System.Data.Entity;

namespace BonitaSpeechTotText.ControllersWebApi
{


    public class ApiBonitaSpeechToTextController : ApiController
    {
        // GET: Api
        private ApplicationDbContext db = new ApplicationDbContext();
        private ApplicationUserManager _userManager;
        private ApplicationSignInManager _signInManager;

        public ApiBonitaSpeechToTextController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                //return _signInManager ?? Request.GetOwinContext().GetUserManager<ApplicationSignInManager>();
                return _signInManager ?? HttpContext.Current.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApiBonitaSpeechToTextController()
        {
            _userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(new ApplicationDbContext()));

        }

        [HttpPost]
        public ResponseHelper añadirPieza(string Guia, string Manifesto, string TipoPieza, int CantidadEnvios, string Aerolinea, string PaisOrigen, double Peso, string Servicio)
        {
            var response = new ResponseHelper();


            if (db.Piezas.FirstOrDefault(c => c.Guia == Guia) != null)
            {
                return response.SetResponse(false, "Ya existe la guia");
            }

            db.Piezas.Add(new Pieza { Guia = Guia, Manifesto = Manifesto, TipoPieza = TipoPieza, CantidadEnvios = CantidadEnvios, Aerolinea = Aerolinea, PaisOrigen = PaisOrigen, Peso = Peso, FechaDespacho = DateTime.Now, TipoServicio = Servicio });
            db.SaveChanges();
            return response.SetResponse(true, "Ingresado");
        }


        [HttpPost]
        public ResponseHelper PiezaCamion(string Guia, int Idcamion)
        {
            var response = new ResponseHelper();


            if (db.Piezas.FirstOrDefault(c => c.Guia == Guia) == null)
            {
                return response.SetResponse(false, "No existe la guia");
            }

            if (db.Camions.FirstOrDefault(c => c.Id == Idcamion) == null)
            {
                return response.SetResponse(false, "No existe el camion");
            }

            PiezaCamion piezaCamion = new PiezaCamion
            {
                CamionId = Idcamion,
                PiezaId = Int32.Parse(Guia)

            };
            db.PiezaCamions.Add(piezaCamion);
            db.SaveChanges();
            return response.SetResponse(true, "Ingresado");
        }
        [HttpPost]
        public ResponseHelper PiezaCamionCerrar(int Idcamion, string bodega)
        {
            var response = new ResponseHelper();
            var camions = db.Camions.FirstOrDefault(c => c.Id == Idcamion);
            if (camions == null)
            {
                return response.SetResponse(false, "No existe el camion");
            }

            var piezaCamion = db.PiezaCamions.FirstOrDefault(c => c.CamionId == Idcamion);
            if (piezaCamion == null)
            {
                return response.SetResponse(false, "No existe el camion");
            }
            piezaCamion.BodegaDestino = bodega;
            db.Entry(piezaCamion).State = EntityState.Modified;
            db.SaveChanges();
            return response.SetResponse(true, "Ingresado");
        }
        [HttpPost]
        public ResponseHelper AperturarCamionBodega(int IdcamionAperturar)
        {
            var response = new ResponseHelper();
            var camion = db.Camions.FirstOrDefault(c => c.Id == IdcamionAperturar);
            if (camion == null)
            {
                return response.SetResponse(false, "No existe el camion");
            }
            camion.AperturarBodega = true;
            db.Entry(camion).State = EntityState.Modified;
            db.SaveChanges();
            return response.SetResponse(true, "Ingresado");
        }
        [HttpPost]
        public ResponseHelper ConsolidarPieza(string Guia)
        {
            var response = new ResponseHelper();
            var pieza = db.Piezas.FirstOrDefault(c => c.Guia == Guia);
            if (pieza == null)
            {
                return response.SetResponse(false, "No existe la pieza");
            }
            pieza.Consolidada = true;
            db.Entry(pieza).State = EntityState.Modified;
            db.SaveChanges();
            return response.SetResponse(true, "Ingresado");
        }
        [HttpPost]
        public ResponseHelper LiberarCamion(int IdcamionCerrar)
        {
            var response = new ResponseHelper();
            var camion = db.Camions.FirstOrDefault(c => c.Id == IdcamionCerrar);
            if (camion == null)
            {
                return response.SetResponse(false, "No existe el camion");
            }
            camion.Liberar = true;
            db.Entry(camion).State = EntityState.Modified;
            db.SaveChanges();
            return response.SetResponse(true, "Ingresado");
        }
        [HttpPost]
        public ResponseHelper EntregarTurno(int IdcamionTurno)
        {
            var response = new ResponseHelper();
            var piezaCamion = db.PiezaCamions.Where(c => c.Id == IdcamionTurno).ToList();
            int totalEnvios = 0;
            foreach (var item in piezaCamion)
            {
                var pieza = db.Piezas.FirstOrDefault(c => c.Guia == item.PiezaId.ToString());
                if (pieza != null)
                {
                    totalEnvios += pieza.CantidadEnvios;
                }

            }

            Turno turno = new Turno
            {
                FechaCreacion = DateTime.Now,
                TotalPiezas = totalEnvios,
                IdCamion = IdcamionTurno
            };
            db.Turnos.Add(turno);
            db.SaveChanges();
            return response.SetResponse(true, "Ingresado");
        }
        [HttpPost]
        public ResponseHelper CrearEnvio(string GuiaPieza,string Guia, string NombreDestinatario,string DireccionDestinatario,string CiudadDestinatario,string PaisOrigen,string PaisDestino,
            double ValorDeclarado,double PesoFisico,string Telefono,string PosicionArancela, string Producto, string TipoServicio, string EstadoFisico,string NumeroReserva,string NombreRemitente
            ,string CiudadRemitente,string DireccionRemitente,string PropuestaValor)
        {
            var response = new ResponseHelper();
            int pieza = db.Piezas.FirstOrDefault(c => c.Guia == GuiaPieza).Id;
            var envios = db.Envios.FirstOrDefault(c => c.Guia == Guia);
            if (envios != null)
            {
                return response.SetResponse(false, "Ya existe el envio");
            }
            Envios enviosf = new Envios
            {
                CiudadDestinatario=CiudadDestinatario,
                PosicionArancela=PosicionArancela,
                CiudadRemitente=PosicionArancela,
                DireccionDestinatario=DireccionDestinatario,
                DireccionRemitente=DireccionRemitente,
                EstadoFisico=EstadoFisico,
                FechaCreacion=DateTime.Now,
                Guia=Guia,
                IdPieza= pieza,
                NombreDestinatario=NombreDestinatario,
                NombreRemitente=NombreRemitente,
                NumeroReserva=NumeroReserva,
                PaisDestino=PaisDestino,
                PaisOrigen=PaisOrigen,
                PesoFisico=PesoFisico,
                Producto=Producto,
                PropuestaValor=PropuestaValor,
                Telefono=Telefono,
                TipoServicio=TipoServicio,
                ValorDeclarado=ValorDeclarado
            };
            db.Envios.Add(enviosf);
            db.SaveChanges();
            return response.SetResponse(true, "Ingresado");
        }









    }
}
