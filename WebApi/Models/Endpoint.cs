using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiBancoNacion.Models
{
    public class Endpoint
    {
        public string Url { get; }

        public Endpoint(IConfiguration configuration)
        {
            Url = configuration["endpointBancoNacion"];
        }
    }
}
