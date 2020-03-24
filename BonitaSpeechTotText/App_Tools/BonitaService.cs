using BonitaSpeechTotText.Models.Data;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;

namespace BonitaSpeechTotText.App_Tools
{
    public class BonitaService
    {
        string urlBase = "http://localhost:8080/bonita/";
        string Token = null;
        string Tokenname = "X-Bonita-API-Token";
        string JSESSIONIDvalue = null;
        string JSESSIONID = "JSESSIONID";
        string IdProcess = null;
        string HumanTaskId = null;
        public bool Loginservice(string username, string password)
        {
            var uri = new Uri(urlBase + "loginservice");
            CookieContainer cookies = new CookieContainer();
            var client = new RestClient(uri);
            client.CookieContainer = new System.Net.CookieContainer();
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddParameter("username", username);
            request.AddParameter("password", password);
            IRestResponse response = client.Execute(request);
            var cookiescontent = client.CookieContainer.GetCookies(uri);

            foreach (Cookie cookie in cookiescontent)
            {
                if (cookie.Name == JSESSIONID)
                {
                    JSESSIONIDvalue = cookie.Value;
                }
                if (cookie.Name == Tokenname)
                {
                    Token = cookie.Value;
                }
            }
            return true;
        }

        public void Listaprocess()
        {
            var client = new RestClient("http://localhost:8080/bonita/API/bpm/process?p=0");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddCookie(Tokenname, Token);
            request.AddCookie(JSESSIONID, JSESSIONIDvalue);
            IRestResponse response = client.Execute(request);
            if (response.IsSuccessful)
            {
                var objResponse1 = JsonConvert.DeserializeObject<List<resulProcess>>(response.Content);
                foreach (var item in objResponse1)
                {
                    IdProcess = item.id;
                }
            }
        }


        public void GetTareaCamion()
        {
            var client = new RestClient("http://localhost:8080/bonita/API/bpm/humanTask?p=0");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);            
            request.AddCookie(Tokenname, Token);
            request.AddCookie(JSESSIONID, JSESSIONIDvalue);
            IRestResponse response = client.Execute(request);
            if (response.IsSuccessful)
            {
                var objResponse1 = JsonConvert.DeserializeObject<List<resulProcess>>(response.Content);
                foreach (var item in objResponse1)
                {
                    HumanTaskId = item.id;
                }
            }
        }
        
        public void CrearCamion(Camion camion)
        {
            var client = new RestClient("http://localhost:8080/bonita/API/bpm/userTask/"+HumanTaskId+"/execution?assign=true");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddCookie(Tokenname, Token);
            request.AddCookie(JSESSIONID, JSESSIONIDvalue);
            request.AddHeader(Tokenname, Token);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("text/plain", "{\n\t\n\t\"camionInput\": {\n\t\t\t\"Id\": \""+camion.Id+"\",\n\t\t\t\"Placa\": \""+camion.Placas+"\",\n\t\t\t\"NombreConductor\": \""+camion.NombreConductor+"\",\n\t\t\t\"Liberar\": 0\n\t\t\n\t}\n\n}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
     
        }
    }

    public class resulProcess
    {
        [JsonProperty("displayDescription")]
        public string displayDescription { get; set; }
        [JsonProperty("deploymentDate")]
        public string deploymentDate { get; set; }
        [JsonProperty("displayName")]
        public string displayName { get; set; }
        [JsonProperty("name")]
        public string name { get; set; }
        [JsonProperty("description")]
        public string description { get; set; }
        [JsonProperty("deployedBy")]
        public string deployedBy { get; set; }
        [JsonProperty("id")]
        public string id { get; set; }
        [JsonProperty("activationState")]
        public string activationState { get; set; }
        [JsonProperty("version")]
        public string version { get; set; }
        [JsonProperty("configurationState")]
        public string configurationState { get; set; }
        [JsonProperty("last_update_date")]
        public string last_update_date { get; set; }
        [JsonProperty("actorinitiatorid")]
        public string actorinitiatorid { get; set; }

    }

}