using System;
using System.Collections.Generic;
using Domain.Chevaca;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Chevaca;
using Services.ChirpStack;
using Microsoft.Extensions.Configuration;
using Board.Models;
using Domain.ChirpStack;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using NUglify.Helpers;
using Services.Models;
using System.Linq;
using Microsoft.Data.SqlClient;
using System.Data;
using Domain.Chapi;
using Domain.Context;
using Services;

namespace Board.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ChevacaDB_Context _context;
        private readonly logs_Service _logs;

        private readonly IConfiguration _configuration;
        private readonly User_Service _userService;

        public DashboardController(ChevacaDB_Context context, logs_Service logs,IConfiguration configuration, User_Service userService)
        {
            _context = context;
            _logs = logs;
            _configuration = configuration;
            _userService = userService;
        }
        private static NetworkServer_Service _NetworkServer_Service = new();
        private static ServiceProfile_Service _ServiceProfile_Service = new();
        private static Organization_Service _Organization_Service = new();
        private static Ranch_Service _ranchService = new();

        #region Service Profile

        [HttpGet]
        public IActionResult ServiceProfile()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ServiceProfile(VM_EstOrg_CampoApp _VM_EstOrg_CampoApp)
        {
            if (_VM_EstOrg_CampoApp != null)
            {
                string usuario_logueado_str = HttpContext.Session.GetString("SessionUser");
                if (!string.IsNullOrWhiteSpace(usuario_logueado_str))
                {
                    // Es Administrador
                    if (_userService.EsAdministrador_Usuario(usuario_logueado_str))
                    {
                        //Pablo: Busca el service profile por nombre cuando el mismo tiene un id
                        JSM_ServiceProfile _resultado = null;
                        bool _existeServiceProfile = _ServiceProfile_Service.Existe_ServiceProfile(_VM_EstOrg_CampoApp.EstanciaOrgName);
                        if (!_existeServiceProfile)
                        {
                            _resultado = _ServiceProfile_Service.Guardar_ServiceProfile(_VM_EstOrg_CampoApp.ChirpstackSPName, _VM_EstOrg_CampoApp.OrgID, _VM_EstOrg_CampoApp.ChirpstackNsId);
                            if (_resultado != null)
                            {
                                if (_resultado.statusCode == 200)
                                {
                                    TempData["guardarServiceProfileEnChirpstackAPI"] = _resultado.answerContent;
                                }
                                else
                                {
                                    _resultado.answerContent = "Ya existe un Service Profile con ese nombre";
                                    TempData["guardarServiceProfileEnChirpstackAPI"] = _resultado;
                                }
                                if (_resultado.statusCode != 200)
                                {
                                    return View(_VM_EstOrg_CampoApp);
                                }
                                else
                                {
                                    return View();
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                return RedirectToAction("Page_500");
            }
            return RedirectToAction("Login", "Home");
        }

        [AcceptVerbs("Get", "Post")]
        [AllowAnonymous]
        public JsonResult ValidarExistenciaServiceProfile(string serviceProfile_nombre)
        {
            bool _existeServiceProfile = false;
            if (!string.IsNullOrWhiteSpace(serviceProfile_nombre))
            {
                //Pabo: Agregar error si spName es null o esta vacio
                _existeServiceProfile = _ServiceProfile_Service.Existe_ServiceProfile(serviceProfile_nombre);
            }
            return Json(!_existeServiceProfile);
        }

        #endregion

        #region Network Server

        [HttpGet]
        public IActionResult NetworkServer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult FormAddNetworkServer(VM_NetworkServer _VM_NetworkServer)
        {
            // Sistema de logs
            System.Diagnostics.StackTrace stackTrace = new(true);
            System.Diagnostics.StackFrame stackFrame = new();
            string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
            string methodName = stackFrame.GetMethod().Name;

            IActionResult resultado = RedirectToAction("NetworkServer");
            if (_VM_NetworkServer != null)
            {
                string network_service_ID_str = _NetworkServer_Service.Guardar_NetworkServer(_VM_NetworkServer.name, _VM_NetworkServer.address);
                if (!string.IsNullOrWhiteSpace(network_service_ID_str))
                {
                    int network_service_ID = 0;
                    if (!int.TryParse(network_service_ID_str, out network_service_ID))
                    {
                        network_service_ID = 0;
                        _logs.Log_AgregarExcepcion("Excepcion. Parse int. ERROR:", className, methodName, network_service_ID_str);
                    }
                    if (network_service_ID > 0)
                    {
                        TempData["mensaje"] = "NS con id " + network_service_ID + " agregado con Exito";
                        return RedirectToAction("NetworkServer");
                    }
                    else
                    {
                        TempData["mensaje"] = "Hubo un problema en el proceso: " + network_service_ID_str;
                        return RedirectToAction("NetworkServer");
                    }
                }
            }
            return resultado;
        }

        public JsonResult ValidarNSenChirpStack(string name, string address)
        {
            object resultado = null;
            string nsExist = _NetworkServer_Service.Existe_NetworkServer(name, address);
            if (!string.IsNullOrWhiteSpace(nsExist))
            {
                resultado = new
                {
                    result = nsExist
                };
            }
            return Json(resultado);
        }

        #endregion

        #region Estancia / Organization / SP

        [HttpGet]
        public JsonResult Filtrarestancias(int estanciaID, string estanciaNombre)
        {
            List<Ranch> orgs = _ranchService.Obtener_Estancia(estanciaID, estanciaNombre);
            return Json(orgs);
        }

        [HttpGet]
        public JsonResult ValidarOrganizationEnChirpstack(string organizacionNombre)
        {
            //Pablo: Validar si name llega vacia o null
            string validarOrganizacion = _Organization_Service.ObtenerPorNombre_Organizacion(organizacionNombre);

            object obj = new
            {
                result = validarOrganizacion
            };

            JsonResult json = Json(obj);

            return json;
        }

        [HttpPost]
        public JsonResult ValidarExistenciaEstancia(string rut)
        {
            //Pablo: Validar si el rut llega vacio o null
            string existeOrg = _ranchService.ObtenerPorRUT_Estancia(rut);

            object obj = new
            {
                result = existeOrg
            };

            JsonResult json = Json(obj);

            return json;
        }

        //En este metodo crearemos tanto la organization en chirpstack y la estancia en nuestra BD
        //El hecho de que estos metodos devuelvan un string es una practica que uso mucho,
        //ya que si el metodo registra algun tipo de fallo lo devuelvo en la respuesta y si el
        //metodo vuelve vacio signigica que es correcto.



        //Formulario para agregar Estancia, Organizacion y Service Profile
        [HttpPost]
        public IActionResult FormEstOrgSP(VM_EstanciaOrg_SP pVmEstOrg)
        {
            if (pVmEstOrg != null)
            {
                //validar datos y si dan error redireccionar a una pantalla de error critico
                //agregar seguridad
                string chevacaServer = "Chevaca Server";
                string chirpstackServer = "Chirpstack Server";
                bool rolbackExitoso = true;
                bool rolbackDefectuoso = false;

                VM_Ranch vmEst = pVmEstOrg.vmEstOrg;
                VM_ServiceProfile vmSP = pVmEstOrg.vmSP;

                JSM_Organization resultCreacionOrg = _Organization_Service.Guardar_Organizacion(vmEst.Name, vmEst.DisplayName, vmEst.CanHaveGateways, vmEst.MaxDevice, vmEst.MaxGateway);

                if (resultCreacionOrg != null && resultCreacionOrg.id != 0 && resultCreacionOrg.answerContent == "")
                {
                    JSM_ServiceProfile resultSpEnChirpstackApi =
                        _ServiceProfile_Service.Guardar_ServiceProfile(vmSP.Name, resultCreacionOrg.id,
                            vmSP.networkServerID);

                    if (resultSpEnChirpstackApi.statusCode == 200)
                    {
                        DatabaseCommunication resultNuevaEstancia = _ranchService.Guardar_Estancia(resultCreacionOrg.id, vmEst.rut, vmEst.Name, vmEst.DisplayName, vmEst.CanHaveGateways, vmEst.MaxGateway, vmEst.MaxDevice);
                        if (resultNuevaEstancia.Result)
                        {
                            vmEst.OrgId = resultCreacionOrg.id;
                            vmEst.Land_ID = resultNuevaEstancia.ObjectId;
                            TempData["NuevaEstanciaOrg"] = JsonConvert.SerializeObject(pVmEstOrg);

                            return RedirectToAction("ReportEstanciaOrg");
                        }
                        else
                        {
                            //Al eliminar la Organizacion tambien se elimina el SP creado previamente
                            JSM_Organization resultEliminarOrg =
                                _Organization_Service.Borrar_Organizacion(resultCreacionOrg.id);

                            if (resultEliminarOrg.statusCode == 200)
                            {
                                ErrorEnCreacion("Estancia", resultNuevaEstancia.ErrorMessage, chevacaServer, rolbackExitoso);
                            }
                            else
                            {
                                //Corregir => Aqui significa que hubo un doble error
                                ErrorEnCreacion("Estancia", resultNuevaEstancia.ErrorMessage, chevacaServer, rolbackDefectuoso);
                            }
                        }
                    }
                    else
                    {
                        JSM_Organization resultEliminarOrg =
                            _Organization_Service.Borrar_Organizacion(resultCreacionOrg.id);
                        if (resultEliminarOrg.statusCode == 200)
                        {
                            ErrorEnCreacion("Estancia", resultEliminarOrg.answerContent, chevacaServer, rolbackExitoso);
                        }
                        else
                        {
                            ErrorEnCreacion("Estancia", resultEliminarOrg.answerContent, chevacaServer, rolbackDefectuoso);
                        }
                    }
                }
                else
                {
                    ErrorEnCreacion("Organizacion", resultCreacionOrg.answerContent, chirpstackServer, rolbackExitoso);
                }
            }

            TempData["errorInterno"] = "Error Desconocido, comuniquese con el Administrador";
            return RedirectToAction("Page_500");
        }

        public IActionResult ListEstanciaOrg()
        {
            List<VM_Ranch> lands = new List<VM_Ranch>();
            return View(lands);
        }

        [HttpGet]
        public IActionResult ReportEstanciaOrg()
        {
            VM_EstanciaOrg_SP estanciaOrg = new();

            var formater = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Auto
            };

            if (TempData["NuevaEstanciaOrg"] != null)
            {
                estanciaOrg = JsonConvert.DeserializeObject<VM_EstanciaOrg_SP>(TempData["NuevaEstanciaOrg"].ToString());
                TempData["EstanciaID"] = estanciaOrg.vmEstOrg.Land_ID;
            }

            return View(estanciaOrg);
        }

        #endregion

        #region Estancia_Campo / Application

        [HttpGet]
        public JsonResult ServiceProfilesByOrgId(int organizacion_ID)
        {
            string result = String.Empty;
            if (organizacion_ID > 0)
            {
                List<ServiceProfile> _lista_serviceProfile = _ServiceProfile_Service.ObtenerPorID_ServiceProfile(organizacion_ID);
                return Json(_lista_serviceProfile);
            }
            return Json(result);
        }

        #endregion

        #region Caravana / Device

        [HttpPost]
        public IActionResult CaravanaDevice(VM_Ch_Device vmChDevice)
        {
            if (vmChDevice != null)
            {
                string devEui = vmChDevice.DevEui;
                string mgapId = vmChDevice.NumeroMinisterio;
                string ChAPPid = vmChDevice.ChAppId;
                string ChStProfileId = vmChDevice.ChStProfileId;
                DateTime fechaCreada = DateTime.Today;
                return View();
            }
            else
            {
                return RedirectToAction("Page_500");
            }

        }

        #endregion

        [HttpGet]
        public IActionResult Index()
        {
            // PASAR AL CONTROLADOR INDEX DE HOME *****************************************************
            string usuario_logueado_str = HttpContext.Session.GetString("SessionUser");
            if (!string.IsNullOrWhiteSpace(usuario_logueado_str))
            {
                if (_userService.EsAdministrador_Usuario(usuario_logueado_str))
                {
                    string username_usuario_logueado = _userService.ObtenerUsername_UsuarioLogueado();
                    string dominio_usuario_logueado = _userService.ObtenerDominio_UsuarioLogueado();
                    User user = _userService.ObtenerPorUsername_Usuario(username_usuario_logueado, dominio_usuario_logueado);
                    if (user != null)
                    {
                        //if (_user.PersonaId > 0)
                        //{
                        //    Personas _person = _Persona_Service.ObtenerPersona(_user.PersonaId);
                        //    if (_person != null)
                        //    {
                        //        VM_Admin _usuario_admin = new(_person.Nombre, _person.Apellido, _person.Email, _user.Image, _user.Role_ID);
                        //        return View(_usuario_admin);
                        //    }
                        //}
                    }
                }
            }
            return RedirectToAction("Login", "Home");
        }

        [HttpGet]
        public IActionResult AdministrationBoard()
        {
            return View();
        }

        #region Paginas de error

        [HttpGet]
        public IActionResult Page_500()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Page_403()
        {
            return View();
        }

        public IActionResult ErrorEnCreacion(string pElement, string pError, string pServer, bool rolbackResult)
        {
            TempData["errorInterno"] = "Hubo un error en la creaci�n del elemento " + pElement + " en el servidor" + pServer + ". El error es: " + pError + ". Debido a esto se ejecut� con �xito un rollback.";
            return RedirectToAction("Page_500");
        }

        #endregion

        #region Llamadas AJAX

        [HttpGet]
        public IActionResult Listadoestancias()
        {
            VM_List_Ranchs vmListRanchs = new();
            return View(vmListRanchs);
        }

        [HttpGet]
        public IActionResult GMaps_inicio()
        {
            VM_GMaps_inicio _VM_GMaps_inicio = new();
            return View(_VM_GMaps_inicio);
        }

        //Este metodo elimina las lands del sistema junto con las organizaciones en el servidor de chirpstack
        //Su funcionamiento es el siguiente, se crea un objeto DatabaseCommunication que a su vez tiene una lista de
        //DabataseDeleteestancias en el cual tenemos un atributo int llamado OperationResult el cual podra recibir
        //tres resultados, 0, 1 o 2.
        //El 0 siginifica que tanto la organizacion como la estancia fueron eliminadas con exito por lo que
        //en el objeto tendremos OrgEliminadaId y EstanciaEliminadaId.
        //Si OperationResult es 1 siginifica que hubo un error en la eliminacion de la organizacion por lo que
        //no paso a la eliminacion de la estancia por lo que la respuesta contendra info en OrgNoElimindaId
        //y en EstanciaNoEliminadaId
        //Si OperationResult es 2 significa que la organizacion se borro correctamente pero no asi la estancia
        //por lo que la respuesta contendra OrgEliminadaId y EstanciaNoEliminadaId.

        [HttpGet]
        public JsonResult BorrarestanciasBulk(string idx)
        {
            DatabaseCommunication _databaseCommunication = new();
            if (!string.IsNullOrWhiteSpace(idx))
            {
                int[] lista_id = JsonConvert.DeserializeObject<int[]>(idx);
                if (lista_id.Length > 0)
                {
                    foreach (int id in lista_id)
                    {
                        //DatabaseDeleteestancias _databaseDeleteestancias = new();
                        //lands _land = _Estancia_Service.ObtenerPorID_Estancia(id);
                        //if (_land != null)
                        //{
                        //    JSM_Organization _organizacion_eliminar = _Organization_Service.Borrar_Organizacion(_land.Organization_ID);
                        //    if (_organizacion_eliminar != null)
                        //    {
                        //        if (_organizacion_eliminar.statusCode == 200)
                        //        {
                        //            _databaseDeleteestancias.orgEliminadaId = _organizacion_eliminar.id;
                        //            _databaseCommunication = _Estancia_Service.Borrar_Estancia(id);
                        //            if (_databaseCommunication != null)
                        //            {
                        //                if (_databaseCommunication.Result)
                        //                {
                        //                    _databaseDeleteestancias.estanciaEliminadaId = _databaseCommunication.ObjectId;
                        //                    _databaseDeleteestancias.operationResult = 0;
                        //                    _databaseDeleteestancias.errorMessage = "";
                        //                    _databaseCommunication.listDeleted.Add(_databaseDeleteestancias);
                        //                }
                        //                else
                        //                {
                        //                    _databaseDeleteestancias.orgEliminadaId = _organizacion_eliminar.id;
                        //                    _databaseDeleteestancias.estanciaNoEliminadaId = _land.Land_ID;
                        //                    _databaseDeleteestancias.operationResult = 2;
                        //                    _databaseDeleteestancias.errorMessage = _databaseCommunication.ErrorMessage;
                        //                    _databaseCommunication.listDeleted.Add(_databaseDeleteestancias);
                        //                }
                        //            }
                        //        }
                        //        else
                        //        {
                        //            _databaseDeleteestancias.orgNoElimindaId = _land.Organization_ID;
                        //            _databaseDeleteestancias.estanciaNoEliminadaId = _land.Land_ID;
                        //            _databaseDeleteestancias.operationResult = 1;
                        //            _databaseDeleteestancias.errorMessage = _organizacion_eliminar.answerContent;
                        //            _databaseCommunication.listDeleted.Add(_databaseDeleteestancias);
                        //        }
                        //    }
                        //}
                    }
                }
            }
            return Json(_databaseCommunication);
        }

        /// <summary>
        /// Trae de la BD las parejas de nodo-animal, el cliente correspondiente y si el modo de consulta es completo o solo_nodos
        /// Modo Completo: se trae todos los datos.
        /// Modo Solo nodos: se trae solo los datos de los nodos, los demás van null. Esto facilita las pruebas, ya que no requiere que para cada nodo reportado existan los demas datos en la BD.
        /// El FLAG que determina el modo esta en el Appsetings.
        /// </summary>
        /// <param name="dummy"></param>
        /// <returns></returns>
        [HttpPost]        
        public Tuple<List<Tuple<Payload, animal_object>>, landlord_object, bool> GetNodosActivos(string dummy)
        {
            // TODO: Quitar datos de cliente, tiene que estar desde antes
            // Sistema de logs
            System.Diagnostics.StackTrace stackTrace = new(true);
            System.Diagnostics.StackFrame stackFrame = new();
            string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
            string methodName = stackFrame.GetMethod().Name;

            Tuple<List<Tuple<Payload, animal_object>>, landlord_object, bool> tuple_list_payload_animal_landlord = new(new(), new(), true);

            // Hago este pasaje de logs_API a log_Devices para tener mas control sobre los datos a futuro.
            List<Payload> _payload_list = new();
            using (ChapiDB_Context context = new())
            {
                //  "yyyy-MM-dd HH:mm:ss";
                DateTime now_withTolerance = GlobalVariables_Service.GetCurrentTime_Uruguay();
                now_withTolerance = now_withTolerance.AddSeconds(-GlobalVariables_Service.GetGMaps_TiempoTolerancia());

                string empty_dataint = "0"; // Registro Alt != 0, o sea, tiene GPS.
                try
                {
                    _payload_list = context.payloads.Where(v => !v.Alt.Equals(empty_dataint) && v.Datetime_Fin >= now_withTolerance).OrderByDescending(v => v.Datetime_Fin).DistinctBy(v => v.DeviceName).ToList();
                }
                catch (Exception ex)
                {
                    _logs.Log_AgregarExcepcion("Excepcion. Ejecutando IQueryable a BD. ERROR:", className, methodName, ex.Message);
                }
            }

            if (_payload_list.Count > 0)
            {
                // DATOS PAYLOAD
                bool isCompleteMode = GlobalVariables_Service.GetGMaps_isModoCompleto();
                if (isCompleteMode)
                {
                    using (_context)
                    {
                        landlord_object _landlord_object = new();
                        int _land_farm_ID = 0;
                        int index = 0;
                        List<Tuple<Payload, animal_object>> tuple_list_payload_animal = new();

                        foreach (Payload _payload in _payload_list)
                        {
                            index++;
                            //int? device_id = _payload.Device_ID;
                            string device_eui = _payload.DevEUI;
                            if (!device_eui.IsNullOrWhiteSpace())
                            {
                                Ch_Device _chirpstack_nodos = _context.Db_Ch_Devices.Where(v => v.Ch_Dev_Eui == device_eui).FirstOrDefault();
                                if (_chirpstack_nodos != null)
                                {
                                    string Device_Eui = _chirpstack_nodos.Ch_Dev_Eui;
                                    Animal animal = _context.Db_Animals.Where(v => v.Ch_Device.Ch_Dev_Eui == Device_Eui).FirstOrDefault();
                                    if (animal != null)
                                    {
                                        animal_object _animal_object = new();
                                        // Si es el primer animal toma los datos del cliente, que es unico para todos los animales del campo.
                                        if (index == 1)
                                        {
                                            _land_farm_ID = animal.Land.Land_ID;
                                        }

                                        // DATOS ANIMAL
                                        int codigo_animal = animal.Code_Animal;
                                        if (codigo_animal > 0)
                                        {
                                            int animal_ID = animal.Animal_ID;
                                            _animal_object.Animal_ID = animal_ID;
                                            _animal_object.Animal_code= codigo_animal;
                                            _animal_object.Gender_MF= animal.Gender_MF;
                                            _animal_object.Category = animal.Gender_MF; //
                                            _animal_object.Breed = animal.Gender_MF; //
                                            _animal_object.MGAP_Tag = animal.Mgap_Tag.MGAP_Tag_ID; //

                                            string tipo_animal_str = GlobalVariables_Service.Animals_enum.Vaca.ToString();

                                            //1. Vaca
                                            //2. Oveja
                                            //3. Caballo
                                            switch (codigo_animal)
                                            {
                                                case 1:
                                                    {
                                                        Animal_Cow cow = _context.Db_Animal_Cows.Where(v => v.Animal.Animal_ID == animal_ID).FirstOrDefault();
                                                        if (cow != null)
                                                        {
                                                            _animal_object.Subanimal_ID = cow.Animal_Cow_ID;
                                                            tipo_animal_str = GlobalVariables_Service.Animals_enum.Vaca.ToString();
                                                        }
                                                        break;
                                                    }
                                                case 2:
                                                    {
                                                        Animal_Sheep sheep = _context.Db_Animal_Sheeps.Where(v => v.Animal.Animal_ID == animal_ID).FirstOrDefault();
                                                        if (sheep != null)
                                                        {
                                                            _animal_object.Subanimal_ID = sheep.Animal_Sheep_ID;
                                                            tipo_animal_str = GlobalVariables_Service.Animals_enum.Oveja.ToString();
                                                        }
                                                        break;
                                                    }
                                                case 3:
                                                    {
                                                        Animal_Horse horse = _context.Db_Animal_Horses.Where(v => v.Animal.Animal_ID == animal_ID).FirstOrDefault();
                                                        if (horse != null)
                                                        {
                                                            _animal_object.Subanimal_ID = horse.Animal_Horse_ID;
                                                            tipo_animal_str = GlobalVariables_Service.Animals_enum.Caballo.ToString();
                                                        }
                                                        break;
                                                    }
                                            }
                                            _animal_object.Animal_type = tipo_animal_str;
                                            if (animal.Date_Born != null)
                                            {
                                                _animal_object.Age = ((DateTime.Now.Year - animal.Date_Born.Value.Year) * 12) + " meses.";
                                            }
                                            tuple_list_payload_animal.Add(new(_payload, _animal_object));
                                        } // switch
                                    } // animal
                                }
                            }
                        } // foreach

                        // DATOS CLIENTE
                        if (_land_farm_ID > 0)
                        {
                            Land _campo = _context.Db_Lands.Where(v => v.Land_ID == _land_farm_ID).FirstOrDefault();
                            if (_campo != null)
                            {
                                Ranch ranch = _context.Db_Ranchs.Where(v => v.Ranch_ID == _campo.Ranch.Ranch_ID).FirstOrDefault();
                                if (ranch != null)
                                {
                                    Person _dueno = _context.Db_Employees.Where(v => ranch.haveOwnerById(v.Person_ID)).FirstOrDefault();
                                    if (_dueno != null)
                                    {
                                        _landlord_object.Owner_ID = _dueno.Person_ID;
                                        _landlord_object.Land_ID = ranch.Ranch_ID;
                                        _landlord_object.Land_farm_ID = _campo.Land_ID;
                                        _landlord_object.Land_name = ranch.Company_Name;
                                        _landlord_object.Land_farm_name = _campo.Land_Name;
                                        _landlord_object.Client_fullname = _dueno.Full_Name;
                                    }
                                }
                            }
                        }
                        // Cargo los datos
                        tuple_list_payload_animal_landlord = new(tuple_list_payload_animal, _landlord_object, isCompleteMode);
                    } // context
                }
                else
                { // isModoCompleto = false
                    List<Tuple<Payload, animal_object>> tuple_list_payload_animal = new();
                    foreach (Payload _payload in _payload_list)
                    {
                        tuple_list_payload_animal.Add(new Tuple<Payload, animal_object>(_payload, new animal_object()));
                    }
                    tuple_list_payload_animal_landlord = new(tuple_list_payload_animal, new landlord_object(), isCompleteMode);
                } // isModoCompleto false
            }
            return tuple_list_payload_animal_landlord;
        }

        [HttpPost]
        public Payload[] GetNodos_Recorrido(string nodo_nombre, int cantidad_ultimos_minutos_int)
        {
            List<Payload> _payload_list = new();
            if (!string.IsNullOrWhiteSpace(nodo_nombre) && cantidad_ultimos_minutos_int > 0)
            {
                // Sistema de logs
                System.Diagnostics.StackTrace stackTrace = new(true);
                System.Diagnostics.StackFrame stackFrame = new();
                string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
                string methodName = stackFrame.GetMethod().Name;

                // Hago este pasaje de logs_API a log_Devices para tener mas control sobre los datos a futuro.
                using (ChapiDB_Context context = new())
                {
                    DateTime timeToQuery = GlobalVariables_Service.GetCurrentTime_Uruguay();
                    timeToQuery = timeToQuery.AddMinutes(-cantidad_ultimos_minutos_int);

                    string connection_string = Configurations.Get_ConnectionString_chboard();
                    if (string.IsNullOrWhiteSpace(connection_string))
                    {
                        // Por defecto conexión remota
                        connection_string = "Server=sql5063.site4now.net;Database=db_a4d7d8_chapidb;User Id=db_a4d7d8_chapidb_admin;Password=chevaca1234;";
                    }
                    using (var conn = new SqlConnection(connection_string))
                    using (var command = new SqlCommand("spGetNodosRecorrido_filtrado", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    })
                    {
                        command.Parameters.AddWithValue("@nodo_nombre", nodo_nombre);
                        command.Parameters.AddWithValue("@datetime_ultimosMinutos", timeToQuery);
                        conn.Open();
                        SqlDataReader reader = null;
                        try
                        {
                            reader = command.ExecuteReader();
                        }
                        catch (Exception ex)
                        {
                            _logs.Log_AgregarExcepcion("Excepcion. Ejecutando ExecuteReader a BD con spGetNodosRecorrido_filtrado. ERROR:", className, methodName, ex.Message);
                        }
                        if (reader != null)
                        {
                            while (reader.Read())
                            {
                                Payload payload = new();
                                payload.Payload_ID = int.Parse(reader["Payload_ID"].ToString());
                                payload.Device_ID = int.Parse(reader["Device_ID"].ToString());
                                payload.Alt = reader["Alt"].ToString();
                                payload.Hdop = reader["Hdop"].ToString();
                                payload.Info = reader["Info"].ToString();
                                payload.Latitud = reader["Latitud"].ToString();
                                payload.Longitud = reader["Longitud"].ToString();
                                payload.Datetime_Inicio = DateTime.Parse(reader["Datetime_Inicio"].ToString());
                                payload.Datetime_Fin = DateTime.Parse(reader["Datetime_Fin"].ToString());
                                payload.DeviceName = reader["DeviceName"].ToString();
                                payload.DevEUI = reader["DevEUI"].ToString();
                                payload.DevAddr = reader["DevAddr"].ToString();
                                payload.ApplicationID = reader["ApplicationID"].ToString();
                                payload.ApplicationName = reader["ApplicationName"].ToString();
                                payload.Gateway = reader["Gateway"].ToString();

                                _payload_list.Add(payload);
                            }
                        }
                    }
                }
            }
            return _payload_list.ToArray();
        }

        #endregion

        #region Metodos generales

        public IActionResult Logout()
        {
            // HttpContext.Session.Remove("chirpstackJWT");
            // HttpContext.Session.Remove("SessionUser");
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Home");
        }

        #endregion

        public ActionResult VM_Payload(string nodo_nombre, int cantidad_ultimos_minutos)
        {
            List<Payload> _lista_Payloads = new();
            using (ChapiDB_Context context = new())
            {
                DateTime ultimosMinutos = DateTime.Now;
                ultimosMinutos = ultimosMinutos.AddMinutes(-cantidad_ultimos_minutos);

                string empty_dataint = "0"; // Registro Alt != 0, o sea, tiene GPS.
                _lista_Payloads = context.payloads.Where(v => !v.Alt.Equals(empty_dataint) && v.DeviceName.Equals(nodo_nombre) && v.Datetime_Fin >= ultimosMinutos).OrderByDescending(v => v.Datetime_Fin).ToList();
            }
            return View(_lista_Payloads);
        }

        #region Clases temporales

        public class animal_object
        {
            public int Animal_ID { get; set; }
            public int? MGAP_Tag { get; set; }
            public int Subanimal_ID { get; set; }
            public int Animal_code { get; set; }
            public string Gender_MF { get; set; }
            public string Animal_type { get; set; }
            public string Age { get; set; }
            public string Category { get; set; }
            public string Breed { get; set; }
        }

        public class landlord_object
        {
            public int Owner_ID { get; set; }
            public int Land_ID { get; set; }
            public int Land_farm_ID { get; set; }
            public string Client_fullname { get; set; }
            public string Land_name { get; set; }
            public string Land_farm_name { get; set; }
        }

        #endregion

    }
}