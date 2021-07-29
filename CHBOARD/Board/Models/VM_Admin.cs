namespace Board.Models
{
    public class VM_Admin
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Foto { get; set; }
        public int Rol { get; set; }

        public VM_Admin(string pNom, string pApell, string pEmail, string pFoto, int pRol)
        {
            Nombre = pNom;
            Apellido = pApell;
            Email = pEmail;
            Foto = pFoto;
            Rol = pRol;
        }
    }
}