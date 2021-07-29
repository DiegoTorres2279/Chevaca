using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using Domain.ChirpStack;

using System.Text.Json;
using Domain.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Services.Chevaca;
using Services.Models;

namespace Services.ChirpStack
{
    public class NetworkServer_Service
    {
        private readonly ChevacaDB_Context _context;
        private readonly IConfiguration _configuration;
        private readonly logs_Service _logs;
        // private Configurations _configurations = new();

        public NetworkServer_Service(ChevacaDB_Context context, IConfiguration configuration, logs_Service logs)
        {
            _context = context;
            _configuration = configuration;
            _logs = logs;
        }

        public NetworkServer_Service()
        {
            
        }

        public NetworkServer Agregar_NetworkServer(string network_nombre, string pAddress)
        {
            NetworkServer _NetworkServer = new NetworkServer();
            _NetworkServer.name = network_nombre;
            _NetworkServer.server = pAddress;
            _NetworkServer.createdAt = DateTime.Today;
            _NetworkServer.updatedAt = DateTime.Today;
            return _NetworkServer;
        }

        public string Existe_NetworkServer(string network_nombre, string pAddress)
        {
            // Sistema de logs
            System.Diagnostics.StackTrace stackTrace = new System.Diagnostics.StackTrace(true);
            System.Diagnostics.StackFrame stackFrame = new System.Diagnostics.StackFrame();
            string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
            string methodName = stackFrame.GetMethod().Name;

            string _existe_NetworkServer = String.Empty;
            try
            {
                HttpClient _HttpClient = new HttpClient();
                Uri _URL = new Uri(_configuration.GetSection("ApiLink").Value + "/network-servers?limit=1000000");
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
                                    JSM_NetworkServer _JSM_NetworkServer = JsonConvert.DeserializeObject<JSM_NetworkServer>(_JSON);
                                    if (_JSM_NetworkServer != null)
                                    {
                                        foreach (NetworkServer _NetworkServer in _JSM_NetworkServer.result)
                                        {
                                            if (_NetworkServer.name.Equals(network_nombre) || _NetworkServer.server.Equals(pAddress))
                                            {
                                                _existe_NetworkServer = JsonConvert.SerializeObject(_NetworkServer);
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
                _existe_NetworkServer = e.Message;
                _logs.Log_AgregarExcepcion("Excepcion. Trycatch. ERROR:", className, methodName, e.Message);
            }
            return _existe_NetworkServer;
        }

        public string Guardar_NetworkServer(string network_nombre, string pAddress)
        {
            // Sistema de logs
            System.Diagnostics.StackTrace stackTrace = new System.Diagnostics.StackTrace(true);
            System.Diagnostics.StackFrame stackFrame = new System.Diagnostics.StackFrame();
            string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
            string methodName = stackFrame.GetMethod().Name;

            string _guardar_NetworkServer = String.Empty;
            try
            {
                JSM_NetworkServer _JSM_NetworkServer = new JSM_NetworkServer();
                _JSM_NetworkServer.networkServer.name = network_nombre;
                _JSM_NetworkServer.networkServer.server = pAddress;
                HttpClient _HttpClient = new HttpClient();
                Uri _URL = new Uri(_configuration.GetSection("UrlWebApi").Value + "/network-servers");
                if (_URL != null)
                {
                    _HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _configuration.GetSection("ApiToken").Value);
                    Task<HttpResponseMessage> _HttpResponseMessage = _HttpClient.PostAsJsonAsync(_URL, _JSM_NetworkServer);
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
                                    JSM_NetworkServer nsDadoDeAlta = JsonConvert.DeserializeObject<JSM_NetworkServer>(_JSON);
                                    if (nsDadoDeAlta != null)
                                    {
                                        _guardar_NetworkServer = nsDadoDeAlta.id.ToString();
                                    }
                                }
                            }
                            else
                            {
                                _guardar_NetworkServer = _HttpResponseMessage.Result.ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                _guardar_NetworkServer = e.Message;
                _logs.Log_AgregarExcepcion("Excepcion. Trycatch. ERROR:", className, methodName, e.Message);
            }
            return _guardar_NetworkServer;
        }

        public List<NetworkServer> Obtener_NetworkServer()
        {
            List<NetworkServer> _lista_networkServer_resultado = new List<NetworkServer>();
            JSM_NetworkServer _JSM_NetworkServer = new JSM_NetworkServer();
            Uri _URL = new Uri(_configuration.GetSection("ApiLink").Value + "/network-servers" + "?limit=1000000");
            if (_URL != null)
            {
                HttpRequestMessage _HttpRequestMessage = new HttpRequestMessage(HttpMethod.Get, _URL);
                if (_HttpRequestMessage != null)
                {
                    string token = "Bearer " + _configuration.GetSection("ApiToken").Value;
                    HttpClient _HttpClient = new HttpClient();
                    _HttpClient.DefaultRequestHeaders.Add("Authorization", token);
                    Task<HttpResponseMessage> _HttpResponseMessage = _HttpClient.SendAsync(_HttpRequestMessage);
                    if (_HttpResponseMessage != null)
                    {
                        _HttpResponseMessage.Wait();
                        if (_HttpResponseMessage.Result.IsSuccessStatusCode)
                        {
                            Task<string> _HttpResponseMessage_result = _HttpResponseMessage.Result.Content.ReadAsStringAsync();
                            if (_HttpResponseMessage_result != null)
                            {
                                _HttpResponseMessage_result.Wait();
                                string json = _HttpResponseMessage_result.Result;

                                var formater = new JsonSerializerSettings()
                                {
                                    TypeNameHandling = TypeNameHandling.Auto
                                };

                                //    networkServers = JsonSerializer.Deserialize<List<JSM_NetworkServer>>(json);
                                _JSM_NetworkServer = JsonConvert.DeserializeObject<JSM_NetworkServer>(json, formater);

                                if (_JSM_NetworkServer != null)
                                {
                                    _lista_networkServer_resultado = _JSM_NetworkServer.result;
                                }
                            }
                        }
                    }
                }
            }
            return _JSM_NetworkServer.result;
        }
    }
}