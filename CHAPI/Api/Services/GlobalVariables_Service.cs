using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Models.Services
{
    public class GlobalVariables_Service
    {
        private readonly IConfiguration _configuration;

        public GlobalVariables_Service(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public enum UserRoles_enum
        {
            Administrador = 1,
            ClienteDueno = 2,
            ClienteEmpleado = 3
        }
        public enum Animals_enum
        {
            Vaca = 1,
            Oveja = 2,
            Caballo = 3
        }
        public static DateTime GetCurrentTime_Uruguay()
        {
            DateTime serverTime = DateTime.Now;
            return TimeZoneInfo.ConvertTimeBySystemTimeZoneId(serverTime, TimeZoneInfo.Local.Id, "Montevideo Standard Time");
            // DateTime _localTime = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(serverTime, TimeZoneInfo.Local.Id, "Mountain Standard Time");
        }

        public double GetGMaps_TiempoTolerancia()
        {  
            double tolerancia_segundos = 0; // 2 minutos
            if (_configuration.GetSection("Tolerancia_segundos_str") != null && !string.IsNullOrWhiteSpace(_configuration.GetSection("Tolerancia_segundos_str").Value))
            {
                if (!double.TryParse(_configuration.GetSection("Tolerancia_segundos_str").Value, out tolerancia_segundos))
                {
                    tolerancia_segundos = 120; 
                }
            }
            return tolerancia_segundos;

        }

        public bool GetGMaps_isModoCompleto()
        {
            bool isModoCompleto = true;
            if (_configuration.GetSection("Modo_completo") != null && !string.IsNullOrWhiteSpace(_configuration.GetSection("Modo_completo").Value))
            {
                if (!bool.TryParse(_configuration.GetSection("Modo_completo").Value, out isModoCompleto))
                {
                    isModoCompleto = true;
                }
            }
            return isModoCompleto;
        }

    }
}
