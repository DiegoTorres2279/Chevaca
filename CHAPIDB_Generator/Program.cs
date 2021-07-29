using Microsoft.SqlServer.Types;
using Microsoft.Web.Administration;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;
using System.Threading;

namespace CHAPIDB_Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            Setup();
        }

        private static void Setup()
        {
            Console.WriteLine("Remoto: Server=sql5063.site4now.net;Database=db_a4d7d8_chapidb;User Id=db_a4d7d8_chapidb_admin;Password=chevaca1234; (S)");
            Console.WriteLine("Local: Server=localhost;Database=chapidb;User Id=chevaca_login;Password=chevaca1234; (N)");
            Console.WriteLine("1) ¿Remoto?: [default SÍ] S/N");
            bool isLocal = false;
            string decision = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(decision))
            {
                if (decision.ToUpperInvariant().Equals("N"))
                {
                    isLocal = true;
                }
            }

            Console.WriteLine("");
            Console.WriteLine("MODO Completo: Además de los nodos, ingresa datos de cliente, estancia, campo y animales. (S)");
            Console.WriteLine("MODO Solo nodos: Sólo ingresa datos de los nodos. (N)");
            Console.WriteLine("");
            Console.WriteLine("2) ¿MODO Completo?: [default SÍ] S/N");
            bool isModoCompleto = true;
            decision = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(decision))
            {
                if (decision.ToUpperInvariant().Equals("N"))
                {
                    isModoCompleto = false;
                }
            }

            Console.WriteLine("");
            Console.WriteLine("3) Duracion_segundos: [default 60]"); // 30 mins = 1800 segs, 10 mins = 600 segs
            string duracion_segundos = Console.ReadLine();
            int duracion_segundos_int = 60;
            if (!string.IsNullOrWhiteSpace(duracion_segundos))
            {
                if (!int.TryParse(duracion_segundos, out duracion_segundos_int))
                {
                    duracion_segundos_int = 60;
                }
            }

            Console.WriteLine("");
            Console.WriteLine("4) Frecuencia_inserts_segundos: [default 2]");
            string frecuencia_inserts_segundos = Console.ReadLine();
            int frecuencia_inserts_segundos_int = 2;
            if (!string.IsNullOrWhiteSpace(frecuencia_inserts_segundos))
            {
                if (!int.TryParse(frecuencia_inserts_segundos, out frecuencia_inserts_segundos_int))
                {
                    frecuencia_inserts_segundos_int = 2;
                }
            }

            Console.WriteLine("");
            Console.WriteLine("5) Cantidad_nodos: [default 5]");
            string cantidad_nodos = Console.ReadLine();
            int cantidad_nodos_int = 5;
            if (!string.IsNullOrWhiteSpace(cantidad_nodos))
            {
                if (!int.TryParse(cantidad_nodos, out cantidad_nodos_int))
                {
                    cantidad_nodos_int = 5;
                }
            }

            Console.WriteLine("");
            Console.WriteLine("6) Radio_dispersión: [default 10]");
            string radio_dispersión = Console.ReadLine();
            int radio_dispersión_int = 10;
            if (!string.IsNullOrWhiteSpace(radio_dispersión))
            {
                if (!int.TryParse(radio_dispersión, out radio_dispersión_int))
                {
                    radio_dispersión_int = 10;
                }
            }

            Console.WriteLine("");
            Console.WriteLine("7.a) POS posicion_inicial_lat: [default -32.227014754892366]");
            string posicion_inicial_lat = Console.ReadLine();
            decimal posicion_inicial_lat_decimal = -32.227014754892366m;
            if (!string.IsNullOrWhiteSpace(posicion_inicial_lat))
            {
                if (!decimal.TryParse(posicion_inicial_lat, out posicion_inicial_lat_decimal))
                {
                    posicion_inicial_lat_decimal = -32.227014754892366m;
                }
            }

            Console.WriteLine("");
            Console.WriteLine("7.b) POS posicion_inicial_long: [default -54.14713658008381]");
            string posicion_inicial_long = Console.ReadLine();
            decimal posicion_inicial_long_decimal = -54.14713658008381m;
            if (!string.IsNullOrWhiteSpace(posicion_inicial_long))
            {
                if (!decimal.TryParse(posicion_inicial_long, out posicion_inicial_long_decimal))
                {
                    posicion_inicial_long_decimal = -54.14713658008381m;
                }
            }

            GMaps_GenerarRecorridoRandom(duracion_segundos_int, frecuencia_inserts_segundos_int, cantidad_nodos_int, posicion_inicial_lat_decimal, posicion_inicial_long_decimal, radio_dispersión_int, isLocal, isModoCompleto);
        }

        /// <summary>
        /// 60 s = 1 m
        /// 600 s = 10 m
        /// 1800 s = 30 m
        /// 3600 s = 1 h
        /// </summary>
        /// <param name="duracion_segundos"></param>
        public static void GMaps_GenerarRecorridoRandom(int duracion_segundos, int frecuencia_inserts_segundos, int cantidad_nodos, decimal posicion_inicial_lat, decimal posicion_inicial_long, int radio_dispersión_int, bool isLocal, bool isModoCompleto)
        {
            DateTime hora_cierre = DateTime.Now;
            hora_cierre = hora_cierre.AddSeconds(duracion_segundos);
            bool boton_finalizar = false;
            decimal precision_movimiento = 0.00001m;
            string precision_movimiento_str = "0.00001"; // Externalizar
            if (!string.IsNullOrWhiteSpace(precision_movimiento_str))
            {
                // Sistema de logs
                System.Diagnostics.StackTrace stackTrace = new(true);
                System.Diagnostics.StackFrame stackFrame = new();
                string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
                string methodName = stackFrame.GetMethod().Name;

                if (!decimal.TryParse(precision_movimiento_str, System.Globalization.NumberStyles.AllowDecimalPoint, new CultureInfo("en-US"), out precision_movimiento))
                {
                    precision_movimiento = 0.00001m; // posición 5
                }

                Random random_EUI = new();
                Random random = new();
                decimal[,] movimiento_nodos = new decimal[cantidad_nodos, 2];
                int[] nodos_ID = new int[cantidad_nodos];

                // Inicializar posición inicial para todos los nodos
                for (int i = 0; i < cantidad_nodos; i++)
                {
                    movimiento_nodos[i, 0] = posicion_inicial_lat;
                    movimiento_nodos[i, 1] = posicion_inicial_long;

                    nodos_ID[i] = random_EUI.Next(10000);
                }

                Console.WriteLine("Hora de cierre: " + hora_cierre);
                Console.WriteLine("Inicia el proceso. ************************");

                // Remoto por defecto
                string connection_string_chapi = "Server=sql5063.site4now.net;Database=db_a4d7d8_chapidb;User Id=db_a4d7d8_chapidb_admin;Password=chevaca1234;"; // Externalizar
                string connection_string_chboard = "Server=sql5063.site4now.net;Database=db_a4d7d8_chevacadb;User Id=db_a4d7d8_chevacadb_admin;Password=chevaca1234;"; // Externalizar
                if (isLocal)
                {
                    connection_string_chapi = "Server=localhost;Database=chapidb;User Id=chevaca_login;Password=chevaca1234;"; // Externalizar
                    connection_string_chboard = "Server=localhost;Database=chevacadb;User Id=chevaca_login;Password=chevaca1234;"; // Externalizar
                }
                if (!string.IsNullOrWhiteSpace(connection_string_chapi) && !string.IsNullOrWhiteSpace(connection_string_chboard))
                {
                    SqlConnection connection_chapi = new(connection_string_chapi);
                    SqlConnection connection_chboard = new(connection_string_chboard);
                    if (connection_chapi != null && connection_chboard != null)
                    {
                        connection_chapi.Open();
                        connection_chboard.Open();

                        // Modo completo: inserta datos extras
                        if (isModoCompleto)
                        {
                            // Inserta datos por única vez

                            // ********************** DATOS DE personas duenos
                            string query_insert_chboard = "INSERT INTO [dbo].[person]([Full_Name],[Email],[Identification],[Date_born], [IsOwner]) output INSERTED.Person_ID VALUES (@Nombre_completo,@Email,@Cedula,@FechaNacimiento, @Is_Owner)";

                            SqlCommand sqlCommand = new(query_insert_chboard, connection_chboard);
                            sqlCommand.Parameters.AddWithValue("@Nombre_completo", "PERSONA TESTING");
                            sqlCommand.Parameters.AddWithValue("@Email", 1);
                            sqlCommand.Parameters.AddWithValue("@Cedula", 1);
                            sqlCommand.Parameters.AddWithValue("@FechaNacimiento", DateTime.Now.AddYears(-50));
                            sqlCommand.Parameters.AddWithValue("@IsOwner", true);
                            int ultimo_ID_persona = (int)sqlCommand.ExecuteScalar();

                            // // ********************** DATOS DE duenos
                            // query_insert_chboard = "INSERT INTO [Person]([Person_ID],[User_ID]) output INSERTED.Landlord_ID VALUES (@Persona_ID,@Usuario_ID)";
                            //
                            // sqlCommand = new(query_insert_chboard, connection_chboard);
                            // sqlCommand.Parameters.AddWithValue("@Persona_ID", ultimo_ID_persona);
                            // sqlCommand.Parameters.AddWithValue("@Usuario_ID", 1);
                            // int ultimo_ID_dueno = (int)sqlCommand.ExecuteScalar();
                            //
                            // ********************** DATOS DE estancias
                            query_insert_chboard = "INSERT INTO [Ranch]([CH_Organization_ID],[Land_name],[Company_RUT],[Company_name],[Company_domain],[Company_rsocial]) output INSERTED.Land_ID VALUES (@Organization_ID,@Estancia_nombre,@Empresa_RUT,@Empresa_nombre,@Empresa_dominio,@Empresa_rsocial)";

                            sqlCommand = new(query_insert_chboard, connection_chboard);
                            sqlCommand.Parameters.AddWithValue("@Dueno_ID", ultimo_ID_persona);
                            sqlCommand.Parameters.AddWithValue("@Organization_ID", 1);
                            sqlCommand.Parameters.AddWithValue("@Estancia_nombre", "ESTANCIA TESTING");
                            sqlCommand.Parameters.AddWithValue("@Empresa_RUT", 1);
                            sqlCommand.Parameters.AddWithValue("@Empresa_nombre", "EMPRESA TESTING");
                            sqlCommand.Parameters.AddWithValue("@Empresa_dominio", 1);
                            sqlCommand.Parameters.AddWithValue("@Empresa_rsocial", 1);
                            int ultimo_ID_estancia = (int)sqlCommand.ExecuteScalar();

                            // ********************** DATOS DE estancia_campos
                            query_insert_chboard = "INSERT INTO [land_farms]([Farm_name],[Land_ID],[Description],ChirpstackApplication_ID) output INSERTED.Land_farm_ID VALUES (@Campo_nombre,@Estancia_ID,@Descripcion,@ChirpstackApplication_ID)";

                            sqlCommand = new(query_insert_chboard, connection_chboard);
                            sqlCommand.Parameters.AddWithValue("@Campo_nombre", "CAMPO TESTING");
                            sqlCommand.Parameters.AddWithValue("@Estancia_ID", ultimo_ID_estancia);
                            sqlCommand.Parameters.AddWithValue("@Descripcion", 1);
                            sqlCommand.Parameters.AddWithValue("@ChirpstackApplication_ID", 1);
                            int ultimo_ID_estancia_campo = (int)sqlCommand.ExecuteScalar();

                            // Pasada de los datos extras
                            for (int i = 0; i < cantidad_nodos; i++) // Recorro cada nodo
                            {
                                // ********************** DATOS EXTRAS

                                int DEVICE_ID = nodos_ID[i];

                                // ********************** DATOS DE chirpstack_nodos
                                query_insert_chboard = "INSERT INTO [chirpstack_devices](Device_ID,Chirpstack_Dev_Eui,Chirpstack_App_Key,Chirpstack_Profile_ID,Chirpstack_App_ID) VALUES (@Device_ID,@Chirpstack_Dev_Eui,@Chirpstack_App_Key,@Chirpstack_Profile_ID,@Chirpstack_App_ID)";

                                sqlCommand = new(query_insert_chboard, connection_chboard);
                                sqlCommand.Parameters.AddWithValue("@Device_ID", DEVICE_ID);
                                sqlCommand.Parameters.AddWithValue("@Chirpstack_Dev_Eui", 1);
                                sqlCommand.Parameters.AddWithValue("@Chirpstack_App_Key", 1);
                                sqlCommand.Parameters.AddWithValue("@Chirpstack_Profile_ID", 1);
                                sqlCommand.Parameters.AddWithValue("@Chirpstack_App_ID", 1);
                                sqlCommand.ExecuteNonQuery();

                                // ********************** DATOS DE animales
                                query_insert_chboard = "INSERT INTO [animals]([Land_farm_ID],[Device_ID],[MGAP_tag_ID],[List_animals_types_code],[List_animals_breeds_code],[List_animals_categories_code],[Code_animal],[Gender_MF],[Date_born]) output INSERTED.Animal_ID VALUES (@Estancia_campo_ID,@Device_ID,@Caravana_MGAP_ID,@Lista_animales_tipos_Codigo,@Lista_animales_razas_Codigo,@Lista_animales_categorias_Codigo,@Codigo_animal,@Sexo_MH, @Date_born)";

                                sqlCommand = new(query_insert_chboard, connection_chboard);
                                sqlCommand.Parameters.AddWithValue("@Estancia_campo_ID", ultimo_ID_estancia_campo);
                                sqlCommand.Parameters.AddWithValue("@Device_ID", DEVICE_ID);
                                sqlCommand.Parameters.AddWithValue("@Caravana_MGAP_ID", 1);
                                sqlCommand.Parameters.AddWithValue("@Lista_animales_tipos_Codigo", 1);
                                sqlCommand.Parameters.AddWithValue("@Lista_animales_razas_Codigo", 1);
                                sqlCommand.Parameters.AddWithValue("@Lista_animales_categorias_Codigo", 1);
                                sqlCommand.Parameters.AddWithValue("@Codigo_animal", 1);
                                sqlCommand.Parameters.AddWithValue("@Sexo_MH", "M"); 
                                sqlCommand.Parameters.AddWithValue("@Date_born", DateTime.Now.AddMonths(-13)); 
                                int ultimo_ID_animal = (int)sqlCommand.ExecuteScalar();

                                // ********************** DATOS DE animal_vacas
                                query_insert_chboard = "INSERT INTO [animal_cows](Animal_ID) VALUES (@Animal_ID)";

                                sqlCommand = new(query_insert_chboard, connection_chboard);
                                sqlCommand.Parameters.AddWithValue("@Animal_ID", ultimo_ID_animal);
                                sqlCommand.ExecuteNonQuery();

                            } // for
                        } // isModoCompleto

                        // Inicia el tiempo de insertados automáticos para todos los nodos
                        int tanda = 1;
                        while (DateTime.Now < hora_cierre && !boton_finalizar)
                        {
                            // Pasada de cada nodo
                            for (int i = 0; i < cantidad_nodos; i++)
                            {
                                // ********************** DATOS DEL NODO

                                int DEVICE_ID = nodos_ID[i];

                                int random_value1 = random.Next(radio_dispersión_int);
                                int random_value2 = random.Next(radio_dispersión_int);
                                int random_value_symbol = random.Next(2);

                                decimal symbol = 1;
                                if (random_value_symbol == 1) // else 0
                                {
                                    symbol = -1;
                                }
                                decimal alter_value1 = precision_movimiento * random_value1 * symbol;
                                decimal alter_value2 = precision_movimiento * random_value2 * symbol;

                                decimal new_lat = movimiento_nodos[i, 0] + alter_value1;
                                decimal new_long = movimiento_nodos[i, 1] + alter_value2;

                                if (new_lat >= -90 && new_lat <= 90 && new_long >= -180 && new_long <= 180)
                                {
                                    movimiento_nodos[i, 0] = new_lat;
                                    movimiento_nodos[i, 1] = new_long;

                                    // SQL -----------------------
                                    // Fuente: https://makolyte.com/find-the-distance-between-two-coordinates-using-sql-and-csharp/                                    

                                    string query_insert = "INSERT INTO [payloads] VALUES(@Device_ID,@Datetime_Inicio,@Datetime_Fin,@Alt,@Hdop,@Info,@Latitud,@Longitud,@DeviceName,@DevEUI,@DevAddr,@ApplicationID,@ApplicationName,@Gateway,@Numeracion)";

                                    SqlCommand sqlCommand = new(query_insert, connection_chapi);
                                    sqlCommand.Parameters.AddWithValue("@Device_ID", DEVICE_ID);
                                    sqlCommand.Parameters.AddWithValue("@Datetime_Inicio", DateTime.Now);
                                    sqlCommand.Parameters.AddWithValue("@Datetime_Fin", DateTime.Now);
                                    sqlCommand.Parameters.AddWithValue("@Alt", "1");
                                    sqlCommand.Parameters.AddWithValue("@Hdop", "1");
                                    sqlCommand.Parameters.AddWithValue("@Info", "TESTING_" + (i + 1));
                                    sqlCommand.Parameters.AddWithValue("@Latitud", new_lat.ToString());
                                    sqlCommand.Parameters.AddWithValue("@Longitud", new_long.ToString());
                                    sqlCommand.Parameters.AddWithValue("@DeviceName", "TESTING_" + (i + 1));
                                    sqlCommand.Parameters.AddWithValue("@DevEUI", "1");
                                    sqlCommand.Parameters.AddWithValue("@DevAddr", "1");
                                    sqlCommand.Parameters.AddWithValue("@ApplicationID", "TESTING");
                                    sqlCommand.Parameters.AddWithValue("@ApplicationName", "TESTING");
                                    sqlCommand.Parameters.AddWithValue("@Gateway", "TESTING");
                                    sqlCommand.Parameters.AddWithValue("@Numeracion", (i + 1));

                                    sqlCommand.ExecuteNonQuery();

                                    /* ----------------------------------------------------------------------------------------------- */

                                }
                            } // for

                            Console.WriteLine("Tanda: " + tanda);
                            tanda++;
                            Thread.Sleep(frecuencia_inserts_segundos * 1000);

                        } // while
                        Console.WriteLine("Finaliza del proceso. ************************");
                        Console.WriteLine("");
                        Console.WriteLine("");
                        Console.WriteLine("¿Desea reiniciar? S/N");

                        string decision = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(decision))
                        {
                            if (decision.ToUpperInvariant().Equals("S"))
                            {
                                GMaps_GenerarRecorridoRandom(duracion_segundos, frecuencia_inserts_segundos, cantidad_nodos, posicion_inicial_lat, posicion_inicial_long, radio_dispersión_int, isLocal, isModoCompleto);
                            }
                        }
                        connection_chapi.Close();
                    }
                }
            }
        }
    }
}