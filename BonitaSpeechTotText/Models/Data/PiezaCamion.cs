using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BonitaSpeechTotText.Models.Data
{
    public class PiezaCamion
    {
        public int Id { get; set; }
        public int CamionId { get; set; }
        public int PiezaId { get; set; }
        public string BodegaDestino { get; set; }
    }
}