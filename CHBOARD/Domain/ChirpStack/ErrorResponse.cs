namespace Domain.ChirpStack
{
    public class ErrorResponse
    {
        public string error { get; set; }
        public string code { get; set; }
        public string message { get; set; }
        public string[] details { get; set; }
    }
}