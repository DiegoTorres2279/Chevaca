using System;
using System.Collections.Generic;
using Domain.ChirpStack;

namespace Services.Models
{
    public class JSM_NetworkServer
    { 
        public List<NetworkServer> result { get; set; }
        public NetworkServer networkServer { get; set; }
        public int id { get; set; }
        public string totalCount { get; set; }

        public JSM_NetworkServer()
        {
            networkServer = new NetworkServer();
        }
    }
}