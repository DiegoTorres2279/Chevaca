namespace Board.Models
{
    public class VM_EstanciaOrg_SP
    {
        public VM_Ranch vmEstOrg { get; set; }
        public VM_ServiceProfile vmSP { get; set; }

        public VM_EstanciaOrg_SP()
        {
            vmEstOrg = new VM_Ranch();
            vmSP = new VM_ServiceProfile();
        }
    }
}