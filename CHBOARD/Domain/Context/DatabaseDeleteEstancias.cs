namespace Domain.Context
{
    public class DatabaseDeleteEstancias
    {
        public int estanciaEliminadaId { get; set; }
        public int orgEliminadaId { get; set; }
        public int operationResult { get; set; }
        public int estanciaNoEliminadaId { get; set; }
        public int orgNoElimindaId { get; set; }

        public string errorMessage { get; set; }
    }
}