using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BonitaSpeechTotText.Models
{
    public abstract class ResponseHelperBase
    {
        public bool Response { get; set; }
        public string Message { get; set; }
        public string Function { get; set; }
        public string Others { get; set; }
        public string OthersExt { get; set; }
        public Dictionary<string, string> Validations { get; set; }

        public void SetValidations(Dictionary<string, string> vals)
        {
            if (vals != null && vals.Count > 0)
            {
                Validations = vals;
                PrepareResponse(false, "La validación no ha sido superada");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="r"></param>
        /// <param name="m"></param>
        /// <param name="p"></param>     

        protected void PrepareResponse(bool r, string m = "", string others = "", string v = "")
        {
            Response = r;


            if (r)
            {
                Others = others;
                OthersExt = v;
                Message = m;
            }
            else
            {
                Message = (m == "" ? "Ocurrió un error inesperado" : m);
            }
        }

        public ResponseHelperBase()
        {
            PrepareResponse(false);
        }
    }

    public class ResponseHelper : ResponseHelperBase
    {
        public dynamic Result { get; set; }

        public ResponseHelper SetResponse(bool r, string m = "", string others = "", string v = "")
        {
            PrepareResponse(r, m, others, v);
            return this;
        }
    }

    public class ResponseHelper<T> : ResponseHelperBase where T : class
    {
        public T Result { get; set; }

        public ResponseHelper<T> SetResponse(bool r, string m = "")
        {
            PrepareResponse(r, m);
            return this;
        }
    }
}