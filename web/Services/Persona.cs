using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;

namespace web.Services
{
    public class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }


        public List<Persona> List()
        {
            HttpClient client = new HttpClient();
            using HttpResponseMessage response = client.GetAsync("https://localhost:7182/Persona/List").Result;
            dynamic result = JsonConvert.DeserializeObject<dynamic>(response.Content.ReadAsStringAsync().Result);

            if (result.status == "ok")
            {
                var body = result.body;
                return JsonConvert.DeserializeObject<List<Persona>>(body.ToString());
            }
            else
            {
                return new List<Persona>();
            }
        }

        public dynamic Add(Persona persona)
        {
            HttpClient client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, $"https://localhost:7182/Persona/Add");

            //request.Headers.Add("Authorization", $"Token {token}");
            dynamic obj = new
            {
                nombre = persona.Nombre,
                descripcion = persona.Descripcion
            };

            var content = new StringContent(JsonConvert.SerializeObject(obj), null, "application/json");
            request.Content = content;
            var response = client.Send(request);
            string text = response.Content.ReadAsStringAsync().Result;
            return text;
        }

        public string Delete(int id)
        {
            HttpClient client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, $"https://localhost:7182/Persona/Delete?id={id}");
            var content = new StringContent(JsonConvert.SerializeObject(""), null, "application/json");
            request.Content = content;
            var response = client.Send(request);
            string text = response.Content.ReadAsStringAsync().Result;
            return text;
        }
    }
}
