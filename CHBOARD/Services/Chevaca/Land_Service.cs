using System.Collections.Generic;
using System.Linq;
using Domain.Chevaca;
using Domain.Context;

namespace Services.Chevaca
{
    public class Land_Service
    {
        private readonly ChevacaDB_Context _context;

        public Land_Service()
        {
            
        }

        public Land_Service(ChevacaDB_Context context)
        {
            _context = context;
        }
        public Land Agregar_estancia_campos()
        {
            return new Land();
        }

        public ICollection<Land> ObtenerCamposPorID_EstanciaCampo(int estanciaID)
        {
            ICollection<Land> _lista_estancia_campos = null;
            if (estanciaID > 0)
            {
                using (_context)
                {
                    Ranch ranch = _context.Db_Ranchs.Where(e => e.Ranch_ID == estanciaID).FirstOrDefault();
                    if (ranch != null)
                    {
                        /*
                        if (_land.estancia_camposs != null)
                        {
                            if (_land.estancia_camposs.Count > 0)
                            {
                                _lista_estancia_camposs = _land.land_farms;
                            }
                        }
                        */
                    }
                }
            }
            return _lista_estancia_campos;
        }
    }
}