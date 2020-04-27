using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;

namespace Telemetrics
{
    public static class ClientSend
    {
        //Успешное добавление клиента 23.04.20, Чт. + Lidl Meteo + 2xRadio
        public static void SendTelegram(float p1, float p2, float p3, float p4, float p5, string t1)
        {

            Telemetrics.Models.Telegram telegram = new Models.Telegram(p1, p2, p3, p4, p5, t1);
            string serialized = JsonConvert.SerializeObject(telegram);

            var client = new RestClient("https://localhost:44385/api/Telegrams");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", serialized, ParameterType.RequestBody);
            //request.AddParameter("application/json", "{\r\n  \r\n  \"p1\":10.1, \r\n  \"p2\":10.2,\r\n  \"p3\":10.3,\r\n  \"p4\":10.4,\r\n  \"p5\":10.5,\r\n  \"t1\":\"Postman\"\r\n}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

            

        }

    }
}
