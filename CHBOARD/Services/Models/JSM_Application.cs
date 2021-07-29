using System.Collections.Generic;
using Domain.ChirpStack;

namespace Services.Models
{
    public class JSM_Application
    {
        public List<Application> result { get; set; }
        public int id { get; set; }
        public Application application { get; set; }
    }
}