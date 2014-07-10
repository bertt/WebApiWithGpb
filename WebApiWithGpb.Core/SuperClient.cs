using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

namespace WebApiWithGpb.Core
{
    public class SuperClient
    {
        private readonly HttpClient client;

        public SuperClient(Uri baseUrl, string username, string password)
        {
            client = new HttpClient { BaseAddress = baseUrl };
            var creds = Convert.ToBase64String(Encoding.UTF8.GetBytes(username + ":" + password));
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-protobuf"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", creds);
        }

        public async Task<List<Person>> GetPersons()
        {
            var response = await client.GetAsync("persons");
            var result = Serializer.Deserialize<List<Person>>(response.Content.ReadAsStreamAsync().Result);
            return result;
        }
    }
}
