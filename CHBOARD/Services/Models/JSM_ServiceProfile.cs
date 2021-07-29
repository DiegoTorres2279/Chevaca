using System;
using System.Collections.Generic;
using Domain.ChirpStack;

namespace Services.Models
{
    public class JSM_ServiceProfile
    {
        public List<ServiceProfile> result { get; set; }
        public ServiceProfile serviceProfile { get; set; }
        public string id { get; set; }
        public int totalCount { get; set; }
        public int statusCode { get; set; }
        public string answerContent { get; set; }

        public JSM_ServiceProfile()
        {
            serviceProfile = new ServiceProfile();
        }
    }
}