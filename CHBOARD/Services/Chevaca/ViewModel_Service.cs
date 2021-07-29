using System.Linq;
using Domain.Chevaca;
using Domain.Context;

namespace Services.Chevaca
{
    public class ViewModel_Service
    {
        private Configurations _configurations = new();

        /// <summary>
        /// SIN TERMINAR, DEFINIR QU� ES UN USUARIO AUTORIZADO
        /// </summary>
        /// <returns></returns>
        public bool UsuarioAutorizado()
        {
            bool _usuario_autorizado = false;
            using (ChevacaDB_Context context = new())
            {
                User user = context.Db_Users.Where(u => u.User_Name.Equals(_configurations.Usuario_logueado)).FirstOrDefault();
                if (user != null)
                {
                    if (user.Rol.Rol_ID > 0) //??
                    {
                        _usuario_autorizado = true;
                    }
                }
            }
            return _usuario_autorizado;
        }

    }
}