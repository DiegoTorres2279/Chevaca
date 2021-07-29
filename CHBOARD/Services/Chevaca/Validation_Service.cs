

using Domain.Context;

namespace Services.Chevaca
{
    public class Validation_Service
    {
        private readonly ChevacaDB_Context _context;

        public Validation_Service(ChevacaDB_Context context)
        {
            _context = context;
        }
        
        public bool OwnerExist(string dueno_cedula)
        {
            bool exist = false;
            using (_context)
            {
                //exist = context.landlords.Where(cl => cl.Persona_ID.Cedula == dueno_cedula).FirstOrDefault() != null ? true : false;
            }
            return exist;
        }
    }
}