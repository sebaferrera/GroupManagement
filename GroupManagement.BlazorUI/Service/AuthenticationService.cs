using GroupManagement.BlazorUI.Contracts;
using GroupManagement.BlazorUI.Model;
using GroupManagement.BlazorUI.Static;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GroupManagement.BlazorUI.Service
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IHttpClientFactory _client;
        public AuthenticationService(IHttpClientFactory client)
        {
            _client = client;
        }
        public async Task<UserRegistrationResultDTO> Register(RegistrationModel user)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, EndPoints.RegisterEndPoint);
            request.Content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");

            var client = _client.CreateClient();
            HttpResponseMessage response = await client.SendAsync(request);

            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<UserRegistrationResultDTO>(content);

            return result;
        }
    }
}
