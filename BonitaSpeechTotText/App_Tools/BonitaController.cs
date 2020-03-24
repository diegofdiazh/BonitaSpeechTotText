using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BonitaSpeechTotText.App_Tools
{
    public class BonitaController : Controller
    {
        protected static BonitaService BonitaService = new BonitaService();

        protected string IdProccess()
        {            
            BonitaService.Listaprocess();
            return null;
        }
      
    }
}