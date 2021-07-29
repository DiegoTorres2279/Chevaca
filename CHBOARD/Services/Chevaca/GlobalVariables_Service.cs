using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Chevaca
{
    public class GlobalVariables_Service
    {
        public GlobalVariables_Service(IConfiguration configuration)
        {
            StaticConfig = configuration;
        }
        public static IConfiguration StaticConfig { get; private set; }

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

        public static double GetGMaps_TiempoTolerancia()
        {            
            return Configurations.Get_TiempoTolerancia();
        }

        public static bool GetGMaps_isModoCompleto()
        {
            return Configurations.GetGMaps_isModoCompleto();
        }

    }
}
