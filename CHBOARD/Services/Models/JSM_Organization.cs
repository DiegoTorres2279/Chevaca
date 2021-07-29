using System.Collections.Generic;
using Domain.ChirpStack;

namespace Services.Models
{
    public class JSM_Organization
    {
        public Organization organization { get; set; }
        public List<Organization> result { get; set; }
        public string totalCount { get; set; }
        public int id { get; set; }

        public int statusCode { get; set; }

        public string answerContent { get; set; }

        public JSM_Organization()
        {
            organization = new Organization();
        }
    }
}