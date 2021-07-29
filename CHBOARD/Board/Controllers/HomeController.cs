using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Domain.Chevaca;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Services;
using Services.Chevaca;
using Services.ChirpStack;
using Board.Models;
using Domain.Context;
using NUglify.Helpers;


namespace Board.Controllers
{
    public class HomeController : Controller
    {
        private IConfiguration _configuration;
        private readonly ChevacaDB_Context _context;
        private readonly logs_Service _logs;
        private static User_Service _userService = new ();

        public HomeController(IConfiguration configuration, ChevacaDB_Context context, logs_Service logs)
        {
            _configuration = configuration;
            _context = context;
            _logs = logs;
        }

        // [HttpGet]
        // public IActionResult Index()
        // {
        //     return View();
        // }

        [HttpGet]
        public IActionResult Login()
        {
            using (_context)
            {
                string sessionUser = HttpContext.Session.GetString("SessionUser");
                string chirpstakJWT = HttpContext.Session.GetString("chirpstackJWT");
                if (!string.IsNullOrWhiteSpace(sessionUser) && !string.IsNullOrWhiteSpace(chirpstakJWT))
                {
                    User user = _context.Db_Users.Where(v => v.User_Name.Equals(sessionUser)).FirstOrDefault();
                    if (user != null)
                    {
                        if (user.Rol.Rol_Name.Equals(GlobalVariables_Service.UserRoles_enum.Administrador))
                        {
                            return RedirectToAction("Index", "Dashboard");
                        }
                    }
                }
            }
            return View();
        }

        [HttpPost]
        public IActionResult Login(VM_Login _VM_Login)
        {
            IActionResult login_result = RedirectToAction("Login");
            if (_VM_Login != null)
            {
                if (!string.IsNullOrWhiteSpace(_VM_Login.Username))
                {
                    string[] user_name_list = _VM_Login.Username.Split('@');
                    if (user_name_list.Length == 2)
                    {
                        string user_login = user_name_list[0];
                        string domain_login = user_name_list[1];

                        int login_check_code = _userService.VerificarRolLogin_Usuario(user_login, domain_login, _VM_Login.Password);
                        bool continue_bool = false;
                        switch (login_check_code)
                        {
                            default: { break; }
                            case 0: /*Mensaje de error: ingerso inv�lido*/ { break; }
                            case 1: { continue_bool = true; break; }
                            case 2: /*Mensaje de error: dominio inv�lido*/ { break; }
                            case 3: /*Mensaje de error: usuario inv�lido*/ { break; }
                            case 4: /*Mensaje de error: password inv�lido*/ { break; }
                        }
                        if (continue_bool)
                        {
                            // Sistema de logs
                            System.Diagnostics.StackTrace stackTrace = new(true);
                            System.Diagnostics.StackFrame stackFrame = new();
                            string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
                            string methodName = stackFrame.GetMethod().Name;

                            string user_role = _userService.ObtenerNombreRolPorUsername_Usuario(user_login);
                            if (!string.IsNullOrWhiteSpace(user_role))
                            {
                                int user_ID = _userService.ObtenerIDPorUsername_Usuario(user_login);
                                if (user_ID > 0)
                                {
                                    // Si es Administrador
                                    if (user_role.Equals(GlobalVariables_Service.UserRoles_enum.Administrador.ToString()))
                                    {
                                        _logs.Log_AgregarAccion("OK: Acceso al sistema correcto con contrasena: '" + _VM_Login.Password + "'.", user_ID.ToString(), string.Empty, _VM_Login.Username, GetIPAddress());
                                        HttpClient _httpClient = new();
                                        Uri _URL = new(_configuration["UrlWebApi"].ToString() + "/internal/login");
                                        if (_URL != null)
                                        {
                                            HttpRequestMessage _HttpRequestMessage = new(HttpMethod.Post, _URL);
                                            if (_HttpRequestMessage != null)
                                            {
                                                string _VM_Login_contenido = JsonConvert.SerializeObject(_VM_Login);
                                                if (!string.IsNullOrWhiteSpace(_VM_Login_contenido))
                                                {
                                                    HttpContent _HttpContent_body = new StringContent(_VM_Login_contenido, Encoding.UTF8, "application/json");
                                                    if (_HttpContent_body != null)
                                                    {
                                                        _HttpRequestMessage.Content = _HttpContent_body;
                                                        Task<HttpResponseMessage> _HttpContent_response = _httpClient.SendAsync(_HttpRequestMessage);
                                                        if (_HttpContent_response != null)
                                                        {
                                                            // Chequear si el server est� vivo
                                                            try
                                                            {
                                                                _HttpContent_response.Wait();
                                                                if (_HttpContent_response.IsCompletedSuccessfully)
                                                                {
                                                                    Task<string> _HttpContent_response_contenido = _HttpContent_response.Result.Content.ReadAsStringAsync();
                                                                    if (_HttpContent_response_contenido != null)
                                                                    {
                                                                        _HttpContent_response_contenido.Wait();
                                                                        string result_json = _HttpContent_response_contenido.Result;
                                                                        if (!string.IsNullOrWhiteSpace(result_json))
                                                                        {
                                                                            /* ------- ERROR EXCEPCI�N: Revisar ---------- */
                                                                            // Newtonsoft.Json.JsonReaderException: 'Unexpected character encountered while parsing value: <. Path '', line 0, position 0.'
                                                                            // No reconoce el JSON al deserializar

                                                                            //Token result_token = JsonConvert.DeserializeObject<Token>(result_json);
                                                                            //if (result_token != null)
                                                                            {
                                                                                //Falta mostrar un error si el no se puede cargar el Token en la sesion.
                                                                                //HttpContext.Session.SetString("chirpstackJWT", result_token.jwt);
                                                                                // Configuraciones.apiToken = token.jwt;
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                            catch (Exception ex)
                                                            {
                                                                _logs.Log_AgregarExcepcion("Excepcion. Conectando a la API Chirpstack. ERROR:", className, methodName, ex.Message);
                                                            }
                                                            // Redirect al Dashboard
                                                            HttpContext.Session.SetString("SessionUser", _VM_Login.Username);
                                                            login_result = RedirectToAction("Index", "Dashboard");
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        _logs.Log_AgregarAccion("ERROR: Intento de login con rol no autorizado: '" + _VM_Login.Password + "'.", "", user_ID.ToString(), _VM_Login.Username, GetIPAddress());
                                    }
                                }
                            }
                            else
                            {
                                _logs.Log_AgregarAccion("ERROR: Intento de login con credenciales incorrectas: '" + _VM_Login.Password + "'.", "", "-", _VM_Login.Username, GetIPAddress());
                            }
                        }
                    }
                }
            }
            return login_result;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public string GetIPAddress()
        {
            var ipAddress = Request.HttpContext.Connection.RemoteIpAddress;
            string ipAddress_str = string.Empty;
            if (ipAddress != null)
            {
                ipAddress_str = ipAddress.ToString();
            }
            return ipAddress_str;
        }
    }
}