using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi2.Services
{
    public class BuzzerService : IBuzzerService
    {
        public string GetSignal(int input)
        {
            var client = new RestClient("https://localhost:5001");
            var resource = "api/buzzer/" + input.ToString();
            var request = new RestRequest(resource, Method.GET);

            var response = client.Execute(request);
            var content = response.Content;

            return content;
        }
    }
}
