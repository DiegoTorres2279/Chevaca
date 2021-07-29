using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Api
{
    public class Configuraciones : IConfiguraciones
    {
        public string API_link { get; set; }
        public string API_token { get; set; }
        public string Usuario_logueado { get; set; }
        public string ConnectionString_chapi { get; set; }
        public string ConnectionString_chapi_remoto { get; set; }
        public string ConnectionString_isLocal { get; set; }
        public string Error_log_file { get; set; }

        public Configuraciones()
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
            ConnectionString_chapi = configuration.GetConnectionString("ConnectionString_chapi");
            ConnectionString_chapi_remoto = configuration.GetConnectionString("ConnectionString_chapi_remoto");
            ConnectionString_isLocal = configuration.GetConnectionString("ConnectionString_isLocal");
            Error_log_file = configuration.GetConnectionString("Error_log_file");
        }
    }
}