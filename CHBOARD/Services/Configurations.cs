using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Newtonsoft.Json;

namespace Services
{
    public class Configurations
    {
        public string API_link { get; set; }
        public string API_token { get; set; }
        public string Usuario_logueado { get; set; }
        public string ConnectionString_chboard { get; set; }
        public string ConnectionString_chboard_remoto { get; set; }
        public string ConnectionString_isLocal { get; set; }
        public string Error_log_file { get; set; }
        public static IHttpContextAccessor accessor_static;

        public Configurations()
        {
            IHttpContextAccessor accessor = new HttpContextAccessor();

            var configuration = new ConfigurationBuilder()
                .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"), optional: false)
                .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.Development.json"), optional: false)
                .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"), optional: false)
                .Build();

            API_link = configuration.GetSection("UrlWebApi").Value;
            // API_token = accessor.HttpContext.Session.GetString("chirpstackJWT");
            // Usuario_logueado = accessor.HttpContext.Session.GetString("SessionUser");
            ConnectionString_chboard = configuration.GetConnectionString("ConnectionString_chboard");
            ConnectionString_chboard_remoto = configuration.GetConnectionString("ConnectionString_chboard_remoto");
            ConnectionString_isLocal = configuration.GetConnectionString("ConnectionString_isLocal");
            Error_log_file = configuration.GetSection("Error_log_file").Value;
        }

        public static string Get_ConnectionString_chboard()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"), optional: false)
                .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.Development.json"), optional: false)
                .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"), optional: false)
                .Build();

            string value_return = string.Empty;
            bool isLocal = false;
            if (!string.IsNullOrWhiteSpace(configuration.GetConnectionString("ConnectionString_isLocal")))
            {
                if (!bool.TryParse(configuration.GetConnectionString("ConnectionString_isLocal"), out isLocal))
                {
                    isLocal = false;
                }
            }

            if (isLocal)
            {
                if (!string.IsNullOrWhiteSpace(configuration.GetConnectionString("ConnectionString_chapi")))
                {
                    value_return = configuration.GetConnectionString("ConnectionString_chapi");
                }
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(configuration.GetConnectionString("ConnectionString_chapi_remoto")))
                {
                    value_return = configuration.GetConnectionString("ConnectionString_chapi_remoto");
                }
            }
            return value_return;
        }

        public static double Get_TiempoTolerancia()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"), optional: false)
                .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.Development.json"), optional: false)
                .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"), optional: false)
                .Build();

            double tolerancia_segundos = 0; // 2 minutos
            if (configuration.GetSection("Tolerancia_segundos_str") != null && !string.IsNullOrWhiteSpace(configuration.GetSection("Tolerancia_segundos_str").Value))
            {
                if (!double.TryParse(configuration.GetSection("Tolerancia_segundos_str").Value, out tolerancia_segundos))
                {
                    tolerancia_segundos = 120; 
                }
            }
            return tolerancia_segundos;
        }

        public static bool GetGMaps_isModoCompleto()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"), optional: false)
                .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.Development.json"), optional: false)
                .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"), optional: false)
                .Build();

            bool isModoCompleto = true;
            if (configuration.GetSection("Modo_completo") != null && !string.IsNullOrWhiteSpace(configuration.GetSection("Modo_completo").Value))
            {
                if (!bool.TryParse(configuration.GetSection("Modo_completo").Value, out isModoCompleto))
                {
                    isModoCompleto = true;
                }
            }
            return isModoCompleto;
        }

    }
}