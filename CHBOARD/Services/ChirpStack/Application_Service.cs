using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Services.Chevaca;
using Services.Models;

namespace Services.ChirpStack
{
    public class Application_Service
    {
        private readonly IConfiguration _configuration;
        private readonly logs_Service _logs;
        //private Configurations _configurations = new();

        public Application_Service(IConfiguration configuration, logs_Service logs)
        {
            _configuration = configuration;
            _logs = logs;
        }

        public string Agregar_Application(string aplicacion_nombre, int aplicacionID, string aplicacion_descripcion, Guid aplicacion_serviceProfileID)
        {
            // Sistema de logs
            System.Diagnostics.StackTrace stackTrace = new System.Diagnostics.StackTrace(true);
            System.Diagnostics.StackFrame stackFrame = new System.Diagnostics.StackFrame();
            string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
            string methodName = stackFrame.GetMethod().Name;

            string _aplicacion_resultado = String.Empty;
            try
            {
                HttpClient _HttpClient = new HttpClient();
                Uri _URL = new Uri(_configuration.GetSection("UrlWebApi").Value + "/applications");
                if (_URL != null)
                {
                    _HttpClient.DefaultRequestHeaders.Authorization = 
                        new AuthenticationHeaderValue("Bearer", _configuration.GetConnectionString("ApiToken"));
                    
                    JSM_Application _JSM_Application = new JSM_Application();
                    _JSM_Application.application.name = aplicacion_nombre;
                    _JSM_Application.application.organizationID = aplicacionID;
                    _JSM_Application.application.description = aplicacion_descripcion;
                    _JSM_Application.application.serviceProfileId = aplicacion_serviceProfileID;
                    Task<HttpResponseMessage> _HttpResponseMessage = _HttpClient.PostAsJsonAsync<JSM_Application>(_URL, _JSM_Application);
                    if (_HttpResponseMessage != null)
                    {
                        if (_HttpResponseMessage.Result.IsSuccessStatusCode)
                        {

                        }
                    }
                }
            }
            
            catch (Exception e)
            {
                _aplicacion_resultado = e.Message;
                _logs.Log_AgregarExcepcion("Excepcion. Trycatch. ERROR:", className, methodName, e.Message);
            }
            return _aplicacion_resultado;
        }
    }
}