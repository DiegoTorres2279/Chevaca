using Domain.Chevaca;
using System;
using System.IO;
using System.Runtime.CompilerServices;
using Domain.Context;
using Microsoft.Extensions.Configuration;

namespace Services.Chevaca
{
    public class logs_Service
    {
        private readonly IConfiguration _configurations;

        private readonly ChevacaDB_Context _context;
        //public IConfigurations Configurations { get; }

        public logs_Service(IConfiguration configuration, ChevacaDB_Context context)
        {
            _configurations = configuration;
            _context = context;
            //Configurations = configurations;
        }

        public void Log_AgregarExcepcion(string message, string className, string methodName, string obj, [CallerLineNumber] int numberNumber = 0)
        {
            try
            {
                string error_log_file = _configurations.GetSection("Error_log_file").Value;
                if (!string.IsNullOrWhiteSpace(error_log_file))
                {
                    using (StreamWriter writer = new(error_log_file, true))
                    {
                        writer.WriteLine(DateTime.Now.ToString() + ": [ln:" + numberNumber + "] " + className + ": " + methodName + "() - " + message + " " + obj + ".");
                    }
                }
            }
            catch (Exception) { }
        }

        public void Log_AgregarAccion(string message, string object_ID, string userID_str, string username, string IP_client = "")
        {
            // Logger variables
            System.Diagnostics.StackTrace stackTrace = new (true);
            System.Diagnostics.StackFrame stackFrame = new ();
            string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
            string methodName = stackFrame.GetMethod().Name;

            using (_context)
            {
                Logs _logs = new();
                _logs.Date_created = GlobalVariables_Service.GetCurrentTime_Uruguay();
                _logs.User.User_Name = username;
                _logs.Description = message;
                _logs.Info= object_ID;
                _logs.IP_client = IP_client;

                int userID = 0;
                if (!int.TryParse(userID_str, out userID))
                {
                    userID = 0;
                    Log_AgregarExcepcion("Excepcion. Convirtiendo int. ERROR:", className, methodName, userID_str);
                }
                _logs.User_ID = userID;
                _context.Db_Logs.Add(_logs);
                _context.SaveChanges();
            }
        }
    }
}
