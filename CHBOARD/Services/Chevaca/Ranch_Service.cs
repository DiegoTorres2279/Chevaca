using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Chevaca;
using Domain.Context;
using Microsoft.EntityFrameworkCore;

namespace Services.Chevaca
{
    public class Ranch_Service
    {
        private readonly ChevacaDB_Context _context;



        public Ranch_Service(ChevacaDB_Context context)
        {
            _context = context;
        }

        public Ranch_Service()
        {
            
        }
        
        public List<Ranch> Obtener_estancias()
        {
            List<Ranch> _land = null;
            using (ChevacaDB_Context context = new())
            {
                _land = context.Db_Ranchs.ToList();
            }
            return _land;
        }

        /// <summary>
        /// Este metodo borrara primero las organizaciones primero para borrar las lands despues
        /// </summary>
        /// <param name="estanciaID"></param>
        /// <returns></returns>
        public DatabaseCommunication Borrar_Estancia(int estanciaID)
        {
            DatabaseCommunication dbComuniction = new();
            if (estanciaID > 0)
            {
                using (_context)
                {
                    Ranch ranch = _context.Db_Ranchs.FirstOrDefault(m => m.Ranch_ID == estanciaID);
                    if (ranch != null)
                    {
                        _context.Db_Ranchs.Remove(ranch);
                        _context.SaveChanges();
                        dbComuniction.Result = true;
                        dbComuniction.ObjectId = estanciaID;
                        dbComuniction.ErrorMessage = String.Empty;
                    }
                }
            }
            return dbComuniction;
        }

        public Ranch Agregar_Estancia(int estanciaID, string estancia_RUT, string estancia_nombre, string pDisplayName, bool pCanHaveGat, int pMaxGat, int pMaxDev)
        {
            Ranch ranch = new();
            ranch.Ch_Organization_ID = estanciaID;
            ranch.Company_SocialReason = estancia_nombre;
            ranch.Company_Name = pDisplayName;
            ranch.Company_Rut = estancia_RUT;
            return ranch;
        }

        public string ObenerRazonSocialPorID_Estancia(int estanciaID)
        {
            string _razonSocial = String.Empty;
            if (estanciaID > 0)
            {
                using (ChevacaDB_Context context = new())
                {
                    Ranch ranch = context.Db_Ranchs.Where(est => est.Ranch_ID == estanciaID).FirstOrDefault();
                    if (ranch != null)
                    {
                        if (!string.IsNullOrWhiteSpace(ranch.Company_Name))
                        {
                            _razonSocial = ranch.Company_Name;
                        }
                    }
                }
            }
            return _razonSocial;
        }

        public List<Ranch> Obtener_Estancia(int estanciaID, string estancia_nombre)
        {
            List<Ranch> _lista_estancias = new();
            using (ChevacaDB_Context context = new())
            {
                // Filtrar por ID
                if (estanciaID > 0)
                {
                    Ranch ranch = context.Db_Ranchs.FirstOrDefault(est => est.Ranch_ID == estanciaID);
                    if (ranch != null)
                    {
                        _lista_estancias.Add(ranch);
                    }
                }
                else
                {
                    // Filtrar por RS o Nombre
                    if (!string.IsNullOrWhiteSpace(estancia_nombre))
                    {
                        _lista_estancias = context.Db_Ranchs.Where(est => est.Company_SocialReason.Contains(estancia_nombre)).ToList();
                        _lista_estancias = context.Db_Ranchs.Where(est => est.Company_Name.Contains(estancia_nombre)).ToList();
                    }
                }
            }
            return _lista_estancias;
        }

        public string ObtenerPorRUT_Estancia(string estancia_RUT)
        {
            string _estanciaRUT = String.Empty;
            if (!string.IsNullOrWhiteSpace(estancia_RUT))
            {
                using (ChevacaDB_Context context = new())
                {
                    Ranch ranch = context.Db_Ranchs.Where(e => e.Company_Rut == estancia_RUT).FirstOrDefault();
                    if (ranch != null)
                    {
                        if (!string.IsNullOrWhiteSpace(ranch.Company_Rut))
                        {
                            _estanciaRUT = ranch.Company_Rut;
                        }
                    }
                }
            }
            return _estanciaRUT;
        }

        public DatabaseCommunication Guardar_Estancia(int estanciaID, string estancia_RUT, string estancia_nombre, string pDisplayName, bool pCanHaveGat, int pMaxGat, int pMaxDev)
        {
            DatabaseCommunication result = null;
            using (ChevacaDB_Context context = new())
            {
                Ranch ranch = Agregar_Estancia(estanciaID, estancia_RUT, estancia_nombre, pDisplayName, pCanHaveGat, pMaxGat, pMaxDev);
                if (ranch != null)
                {
                    context.Db_Ranchs.Add(ranch);
                    context.SaveChanges();
                    result = new DatabaseCommunication(ranch.Ranch_ID);
                }
            }
            return result;
        }

        public Ranch ObtenerPorID_Estancia(int estanciaID)
        {
            Ranch ranch = null;
            using (ChevacaDB_Context context = new())
            {
                ranch = context.Db_Ranchs.Where(est => est.Ranch_ID == estanciaID).FirstOrDefault();
            }
            return ranch;
        }
    }
}
