using Domain.ChirpStack;
using Newtonsoft.Json;
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
    public class Organization_Service
    {
        private readonly IConfiguration _configuration;

        private readonly logs_Service _logs;
        //private Configurations _configurations= new();

        public Organization_Service(IConfiguration configuration, logs_Service logs)
        {
            _configuration = configuration;
            _logs = logs;
        }

        public Organization_Service()
        {
            
        }
        
        public Organization Nueva_Organizacion(string organizacion_nombre, string pDname, bool haveGateways, int maxDevices, int maxGateway)
        {
            Organization _organizacion = new Organization();
            _organizacion.canHaveGateways = haveGateways;
            _organizacion.displayName = pDname;
            _organizacion.maxDeviceCount = maxDevices;
            _organizacion.maxGatewayCount = maxGateway;
            _organizacion.name = organizacion_nombre;

            return _organizacion;
        }
        
        public string Existe_Organizacion(string organizacionNombre)
        {
            return String.Empty;
        }

        public JSM_Organization Guardar_Organizacion(string organizacion_nombre, string pDisplayName, bool pCanHaveGateways, int pMaxDevice, int pMaxGateway)
        {
            // Sistema de logs
            System.Diagnostics.StackTrace stackTrace = new System.Diagnostics.StackTrace(true);
            System.Diagnostics.StackFrame stackFrame = new System.Diagnostics.StackFrame();
            string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
            string methodName = stackFrame.GetMethod().Name;

            JSM_Organization _JSM_Organization_resultado = new JSM_Organization();
            int statCode = _JSM_Organization_resultado.statusCode;

            // ToDo: Validar si Existe en Chirpstack 
            // ToDo: Validar si existe en Chevaca Server
            try
            {
                JSM_Organization _JSM_Organization = new JSM_Organization();
                _JSM_Organization.organization.name = organizacion_nombre;
                _JSM_Organization.organization.displayName = pDisplayName;
                _JSM_Organization.organization.canHaveGateways = pCanHaveGateways;
                _JSM_Organization.organization.maxDeviceCount = pMaxDevice;
                _JSM_Organization.organization.maxGatewayCount = pMaxGateway;

                HttpClient cli = new HttpClient();
                string token = "Bearer " + _configuration.GetSection("ApiToken").Value;
                cli.DefaultRequestHeaders.Add("Authorization", token);

                string link = _configuration.GetSection("UrlWebApi").Value + "/organizations";
                Uri _URL = new Uri(link);
                if (_URL != null)
                {
                    Task<HttpResponseMessage> _HttpResponseMessage = cli.PostAsJsonAsync(_URL, _JSM_Organization);
                    if (_HttpResponseMessage != null)
                    {
                        _HttpResponseMessage.Wait();

                        if (_HttpResponseMessage.Result.IsSuccessStatusCode)
                        {
                            Task<string> _HttpResponseMessage_result = _HttpResponseMessage.Result.Content.ReadAsStringAsync();
                            if (_HttpResponseMessage_result != null)
                            {
                                _HttpResponseMessage_result.Wait();

                                string _JSON = _HttpResponseMessage_result.Result;
                                if (!string.IsNullOrWhiteSpace(_JSON))
                                {
                                    _JSM_Organization_resultado = JsonConvert.DeserializeObject<JSM_Organization>(_JSON);
                                    if (_JSM_Organization_resultado != null)
                                    {
                                        statCode = (int)_HttpResponseMessage.Result.StatusCode;
                                        _JSM_Organization_resultado.answerContent = String.Empty;
                                    }
                                }
                            }
                        }
                        else
                        {
                            _JSM_Organization_resultado.statusCode = (int)_HttpResponseMessage.Result.StatusCode;
                            _JSM_Organization_resultado.answerContent = _HttpResponseMessage.Result.ToString();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                _JSM_Organization_resultado.answerContent = e.Message;
                _JSM_Organization_resultado.statusCode = 500;
                _logs.Log_AgregarExcepcion("Excepcion. Trycatch. ERROR:", className, methodName, e.Message);
            }
            return _JSM_Organization_resultado;
        }

        public string ObtenerPorNombre_Organizacion(string organizacion_nombre)
        {
            // Sistema de logs
            System.Diagnostics.StackTrace stackTrace = new System.Diagnostics.StackTrace(true);
            System.Diagnostics.StackFrame stackFrame = new System.Diagnostics.StackFrame();
            string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
            string methodName = stackFrame.GetMethod().Name;

            string _organizacion_resultado = String.Empty;
            try
            {
                HttpClient _HttpClient = new HttpClient();
                Uri _URL = new Uri(_configuration.GetSection("ApiLink").Value + "/organizations" + "?limit=1000");
                if (_URL != null)
                {
                    _HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _configuration.GetSection("ApiToken").Value);
                    Task<HttpResponseMessage> _HttpResponseMessage = _HttpClient.GetAsync(_URL);
                    if (_HttpResponseMessage != null)
                    {
                        _HttpResponseMessage.Wait();
                        if (_HttpResponseMessage.Result.IsSuccessStatusCode)
                        {
                            Task<string> _HttpResponseMessage_result = _HttpResponseMessage.Result.Content.ReadAsStringAsync();
                            if (_HttpResponseMessage_result != null)
                            {
                                _HttpResponseMessage_result.Wait();
                                string _JSON = _HttpResponseMessage_result.Result;
                                if (!string.IsNullOrWhiteSpace(_JSON))
                                {
                                    JSM_Organization _JSM_ServiceProfile = JsonConvert.DeserializeObject<JSM_Organization>(_JSON);
                                    if (_JSM_ServiceProfile != null)
                                    {
                                        foreach (Organization _organization in _JSM_ServiceProfile.result)
                                        {
                                            if (_organization.name.Equals(organizacion_nombre))
                                            {
                                                _organizacion_resultado = _organization.name;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                _organizacion_resultado = e.Message;
                _logs.Log_AgregarExcepcion("Excepcion. Trycatch. ERROR:", className, methodName, e.Message);
            }

            return _organizacion_resultado;
        }

        public string ObtenerPorID_Organizacion(int organizacionID)
        {
            // Sistema de logs
            System.Diagnostics.StackTrace stackTrace = new System.Diagnostics.StackTrace(true);
            System.Diagnostics.StackFrame stackFrame = new System.Diagnostics.StackFrame();
            string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
            string methodName = stackFrame.GetMethod().Name;

            string _organizacion_resultado = String.Empty;
            try
            {
                Uri _URL = new Uri(_configuration.GetSection("ApiLink").Value + "/organizations/" + organizacionID);
                if (_URL != null)
                {
                    string token = "Bearer" + _configuration.GetSection("ApiToken").Value;
                    HttpClient _HttpClient = new HttpClient();
                    _HttpClient.DefaultRequestHeaders.Add("Authentication", token);
                    Task<HttpResponseMessage> _HttpResponseMessage = _HttpClient.GetAsync(_URL);
                    if (_HttpResponseMessage != null)
                    {
                        _HttpResponseMessage.Wait();
                        if (_HttpResponseMessage.Result.IsSuccessStatusCode)
                        {
                            Task<string> _HttpResponseMessage_result = _HttpResponseMessage.Result.Content.ReadAsStringAsync();
                            if (_HttpResponseMessage_result != null)
                            {
                                _HttpResponseMessage_result.Wait();
                                _organizacion_resultado = _HttpResponseMessage_result.Result;
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                _organizacion_resultado = e.Message;
                _logs.Log_AgregarExcepcion("Excepcion. Trycatch. ERROR:", className, methodName, e.Message);
            }
            return _organizacion_resultado;
        }

        public JSM_Organization Borrar_Organizacion(int organizacionID)
        {
            // Sistema de logs
            System.Diagnostics.StackTrace stackTrace = new System.Diagnostics.StackTrace(true);
            System.Diagnostics.StackFrame stackFrame = new System.Diagnostics.StackFrame();
            string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
            string methodName = stackFrame.GetMethod().Name;

            JSM_Organization _organizacion_resultado = new JSM_Organization();
            try
            {
                Uri _URL = new Uri(_configuration.GetSection("ApiLink").Value + "/organizations/" + organizacionID);
                if (_URL != null)
                {
                    HttpClient _HttpClient = new HttpClient();
                    _HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _configuration.GetSection("ApiToken").Value);
                    Task<HttpResponseMessage> _HttpResponseMessage = _HttpClient.DeleteAsync(_URL);
                    if (_HttpResponseMessage != null)
                    {
                        _HttpResponseMessage.Wait();
                        if (_HttpResponseMessage.Result.IsSuccessStatusCode)
                        {
                            _organizacion_resultado.statusCode = (int)_HttpResponseMessage.Result.StatusCode;
                            _organizacion_resultado.id = organizacionID;
                        }
                        else
                        {
                            _organizacion_resultado.statusCode = (int)_HttpResponseMessage.Result.StatusCode;
                            _organizacion_resultado.answerContent = _HttpResponseMessage.Result.ReasonPhrase;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                _organizacion_resultado.answerContent = e.Message;
                _organizacion_resultado.statusCode = 500;
                _logs.Log_AgregarExcepcion("Excepcion. Trycatch. ERROR:", className, methodName, e.Message);
            }
            return _organizacion_resultado;
        }
    }
}