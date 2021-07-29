using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Domain.ChirpStack;

using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Services.Models;

namespace Services.ChirpStack
{
    public class ServiceProfile_Service
    {
        private Configurations _configurations = new();

        public ServiceProfile Agregar_ServiceProfile(string serviceProfile_nombre, int organizacionID, int networkServiceID)
        {
            ServiceProfile _serviceProfile = new();
            _serviceProfile.id = Guid.NewGuid().ToString();
            _serviceProfile.name = serviceProfile_nombre;
            _serviceProfile.createdAt = DateTime.Now;
            _serviceProfile.updatedAt = DateTime.Now;
            _serviceProfile.organizationID = organizacionID;
            _serviceProfile.networkServerID = networkServiceID;
            return _serviceProfile;
        }

        public bool Existe_ServiceProfile(string serviceProfile)
        {
            bool _existe_ServiceProfile = false;
            if (!string.IsNullOrWhiteSpace(serviceProfile))
            {
                string token = "Bearer " + _configurations.API_token;
                if (!string.IsNullOrWhiteSpace(token))
                {
                    HttpClient _HttpClient = new HttpClient();
                    _HttpClient.DefaultRequestHeaders.Add("Authentication", token);
                    Uri _URL = new Uri(_configurations.API_link + "/service-profiles");
                    if (_URL != null)
                    {
                        Task<HttpResponseMessage> _HttpResponseMessage = _HttpClient.PostAsJsonAsync(_URL, _HttpClient);
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
                                        JSM_ServiceProfile _JSM_ServiceProfile = JsonConvert.DeserializeObject<JSM_ServiceProfile>(_JSON);
                                        if (_JSM_ServiceProfile != null)
                                        {
                                            if (_JSM_ServiceProfile.result != null)
                                            {
                                                if (_JSM_ServiceProfile.result.Count > 0)
                                                {
                                                    List<ServiceProfile> _lista_serviceProfile = _JSM_ServiceProfile.result;
                                                    _existe_ServiceProfile = _lista_serviceProfile.Exists(v => v.name.Equals(serviceProfile));

                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return _existe_ServiceProfile;
        }

        public JSM_ServiceProfile Guardar_ServiceProfile(string serviceProfile_nombre, int organizacionID, int networkServiceID)
        {
            JSM_ServiceProfile _serviceProfile = new JSM_ServiceProfile();
            _serviceProfile.serviceProfile.name = serviceProfile_nombre;
            _serviceProfile.serviceProfile.organizationID = organizacionID;
            _serviceProfile.serviceProfile.networkServerID = networkServiceID;

            Uri _URL = new Uri(_configurations.API_link + "/service-profiles");
            if (_URL != null)
            {
                HttpClient _HttpClient = new HttpClient();
                _HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _configurations.API_token);
                Task<HttpResponseMessage> _HttpResponseMessage = _HttpClient.PostAsJsonAsync(_URL, _serviceProfile);
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
                                _serviceProfile = JsonConvert.DeserializeObject<JSM_ServiceProfile>(_JSON);
                                if (_serviceProfile != null)
                                {
                                    _serviceProfile.statusCode = (int)_HttpResponseMessage.Result.StatusCode;
                                    _serviceProfile.answerContent = String.Empty;
                                }
                            }
                        }
                    }
                    else
                    {
                        _serviceProfile.statusCode = (int)_HttpResponseMessage.Result.StatusCode;
                        _serviceProfile.answerContent = _HttpResponseMessage.Result.ToString();
                    }
                }
            }
            return _serviceProfile;
        }

        public string Borrar_ServiceProfile(string serviceProfile)
        {
            string _resultado_borrado = String.Empty;
            HttpClient _HttpClient = new HttpClient();
            Uri _URL = new Uri(_configurations.API_link + "/service-profiles/" + serviceProfile);
            if (_URL != null)
            {
                _HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _configurations.API_token);
                Task<HttpResponseMessage> _HttpResponseMessage = _HttpClient.DeleteAsync(_URL);
                if (_HttpResponseMessage != null)
                {
                    _HttpResponseMessage.Wait();
                    _resultado_borrado = _HttpResponseMessage.Result.ToString();
                }
            }
            return _resultado_borrado;
        }

        public List<ServiceProfile> ObtenerPorID_ServiceProfile(int organizacionID)
        {
            List<ServiceProfile> _lista_ServiceProfile_resultado = new List<ServiceProfile>();
            HttpClient _HttpClient = new HttpClient();
            Uri _URL = new Uri(_configurations.API_link + "/service-profiles?limit=100000&organizationID=" + organizacionID);
            if (_URL != null)
            {
                _HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _configurations.API_token);
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
                                JSM_ServiceProfile _JSM_ServiceProfile = JsonConvert.DeserializeObject<JSM_ServiceProfile>(_JSON);
                                if (_JSM_ServiceProfile != null)
                                {
                                    _lista_ServiceProfile_resultado = _JSM_ServiceProfile.result; ;
                                }
                            }
                        }
                    }
                }
            }
            return _lista_ServiceProfile_resultado;
        }
    }
}