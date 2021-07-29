using System.Collections.Generic;
using System.Linq;
using Domain.Chevaca;
using Domain.Context;


namespace Services.Chevaca
{
    public class User_Service
    {
        Configurations _configurations = new();
        public User_Service()
        {

        }

        public int VerificarRolLogin_Usuario(string login_usuario, string login_dominio, string password_usuario)
        {
            int resultado = 0; // 0=ingerso inv�lido, 1=OK, 2=dominio inv�lido, 3=usuario inv�lido, 4=password inv�lido
            if (!string.IsNullOrWhiteSpace(login_usuario) && !string.IsNullOrWhiteSpace(password_usuario))
            {
                using (ChevacaDB_Context context = new())
                {
                    // CHECK: Domain
                    if (!string.IsNullOrWhiteSpace(login_usuario) && !string.IsNullOrWhiteSpace(login_dominio))
                    {
                        resultado = 2;
                        // CHECK: Usuario en Domain
                        Ranch ranch = context.Db_Ranchs.Where(v => v.Company_Domain.Equals(login_dominio)).FirstOrDefault();
                        if (ranch != null)
                        {
                            resultado = 3;
                            int estanciaID = ranch.Ranch_ID;
                            if (estanciaID > 0)
                            {
                                // Todos los ID usuarios de la estancia
                                List<User> _users_employees = context.Db_Employees.Where(v => v.Land.Equals(estanciaID)).Select(v => v.User).ToList();
                                if (_users_employees != null && _users_employees.Count > 0)
                                {
                                    User user_result = null;
                                    foreach (User _user in _users_employees)
                                    {
                                        user_result = _user; 
                                        if (user_result != null) // Si encuentra usuario
                                        {
                                            if (!string.IsNullOrWhiteSpace(user_result.User_Name))
                                            {
                                                if (login_usuario.Equals(user_result.User_Name))
                                                {
                                                    resultado = 4;
                                                    if (_user.Password.Equals(password_usuario))
                                                    {
                                                        resultado = 1;
                                                    }
                                                }
                                            }
                                            break; // Salir del foreach
                                        }
                                    } // foreach
                                }
                            }
                        }
                    }
                }
            }
            return resultado;
        }

        public bool EsAdministrador_Usuario(string usuario_logueado_str)
        {
            bool esAdministrador = false;
            if (!string.IsNullOrWhiteSpace(usuario_logueado_str))
            {
                using (ChevacaDB_Context context = new())
                {
                    string usuario_dominio = ObtenerUsername_UsuarioLogueado();
                    string nombre_dominio = ObtenerDominio_UsuarioLogueado();

                    User user = context.Db_Users.Where(v => v.User_Name.Equals(usuario_dominio)).FirstOrDefault();
                    if (user != null)
                    {
                        Person person = context.Db_Employees.Where(v => v.User.Equals(user.User_ID)).FirstOrDefault();
                        string estancia_dominio = context.Db_Ranchs.Where(v => v.Ranch_ID.Equals(person.Land)).FirstOrDefault().Company_Domain;
                        if (estancia_dominio == nombre_dominio)
                        {
                            if (user.Rol.Rol_ID > 0)
                            {
                                Rol _rol_usuario = context.Db_Roles.Where(v => v.Rol_ID == user.Rol.Rol_ID).FirstOrDefault();
                                if (_rol_usuario != null)
                                {
                                    // Es Administrador
                                    if (_rol_usuario.Rol_Name.Equals(GlobalVariables_Service.UserRoles_enum.Administrador.ToString()))
                                    {
                                        esAdministrador = true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return esAdministrador;
        }

        public string ObtenerDominio_UsuarioLogueado()
        {
            string value = string.Empty;
            if (!string.IsNullOrWhiteSpace(_configurations.Usuario_logueado))
            {
                string[] nombre_usuario_array = _configurations.Usuario_logueado.Split('@');
                if (nombre_usuario_array.Length == 2)
                {
                    value = nombre_usuario_array[1];
                }
            }
            return value;
        }

        public string ObtenerUsername_UsuarioLogueado()
        {
            string value = string.Empty;
            if (!string.IsNullOrWhiteSpace(_configurations.Usuario_logueado))
            {
                string[] nombre_usuario_array = _configurations.Usuario_logueado.Split('@');
                if (nombre_usuario_array.Length == 2)
                {
                    value = nombre_usuario_array[0];
                }
            }
            return value;
        }

        public User ObtenerPorUsername_Usuario(string nombre_usuario, string dominio_usuario)
        {
            User _usuario_resultado = null;
            if (!string.IsNullOrWhiteSpace(nombre_usuario) && !string.IsNullOrWhiteSpace(dominio_usuario))
            {
                using (ChevacaDB_Context context = new())
                {
                    //users _user = null;
                    //List<employees> _usuarios_con_ese_nombre = context.employees.Where(v => v.User_name == nombre_usuario).ToList();
                    //lands _land = context.lands.Where(v => v.Company_domain == dominio_usuario).FirstOrDefault();
                    //foreach (employees dep in _usuarios_con_ese_nombre)
                    //{
                    //    if (dep.Land_farm_ID == _land.Land_ID)
                    //    {
                    //        _user = context.users.Where(v => v.User_ID == dep.User_ID).FirstOrDefault();
                    //    }
                    //}
                    //if (_user != null)
                    //{
                    //    _usuario_resultado = _user;
                    //}
                }
            }
            return _usuario_resultado;
        }
        public int ObtenerIDPorUsername_Usuario(string nombre_usuario)
        {
            int _usuario_resultado = 0;
            if (!string.IsNullOrWhiteSpace(nombre_usuario))
            {
                using (ChevacaDB_Context context = new())
                {
                    User user = context.Db_Users.Where(v => v.User_Name.Equals(nombre_usuario)).FirstOrDefault();
                    if (user != null)
                    {
                        _usuario_resultado = user.User_ID;
                    }
                }
            }
            return _usuario_resultado;
        }

        public string ObtenerNombreRolPorUsername_Usuario(string nombre_usuario)
        {
            string _rol_resultado = string.Empty;
            if (!string.IsNullOrWhiteSpace(nombre_usuario))
            {
                using (ChevacaDB_Context context = new())
                {
                    User user = context.Db_Users.Where(v => v.User_Name.Equals(nombre_usuario)).FirstOrDefault();
                    if (user != null)
                    {
                        int rolID = user.Rol.Rol_ID;
                        if (rolID > 0)
                        {
                            Rol rol_usuario = context.Db_Roles.Where(v => v.Rol_ID.Equals(rolID)).SingleOrDefault();
                            _rol_resultado = rol_usuario.Rol_Name.ToString();
                        }
                    }
                }
            }
            return _rol_resultado;
        }

        public User ObtenerPorUsername_Persona(string nombre_usuario, string dominio_usuario)
        {
            User _usuario_resultado = null;
            if (!string.IsNullOrWhiteSpace(nombre_usuario) && !string.IsNullOrWhiteSpace(dominio_usuario))
            {
                using (ChevacaDB_Context context = new())
                {
                    //users _user = null;
                    //List<employees> _usuarios_con_ese_nombre = context.employees.Where(v => v.User_name == nombre_usuario).ToList();
                    //lands _land = context.lands.Where(v => v.Company_domain == dominio_usuario).FirstOrDefault();
                    //foreach (employees dep in _usuarios_con_ese_nombre)
                    //{
                    //    if (dep.Land_farm_ID == _land.Land_ID)
                    //    {
                    //        _user = context.users.Where(v => v.User_ID == dep.User_ID).FirstOrDefault();
                    //    }
                    //}
                    //if (_user != null)
                    //{
                    //    _usuario_resultado = _user;
                    //}
                }
            }
            return _usuario_resultado;
        }
    }
}