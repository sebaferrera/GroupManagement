using Blazored.LocalStorage;
using GroupManagement.BlazorUI.Contracts;
using GroupManagement.BlazorUI.Model;
using GroupManagement.BlazorUI.Providers;
using GroupManagement.BlazorUI.Static;
using Microsoft.AspNetCore.Components.Authorization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace GroupManagement.BlazorUI.Service
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IHttpClientFactory _client;
        private readonly ILocalStorageService _localStorage;
        private readonly AuthenticationStateProvider _authProvider;
        public AuthenticationService(IHttpClientFactory client, ILocalStorageService localStorage, AuthenticationStateProvider authProvider)
        {
            _client = client;
            _localStorage = localStorage;
            _authProvider = authProvider;
        }

        public async Task<bool> Login(LoginModel user)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, EndPoints.LoginEndPoint);
            request.Content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");

            var client = _client.CreateClient();
            HttpResponseMessage response = await client.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                return false;
            }

            var content = await response.Content.ReadAsStringAsync();
            var token = JsonConvert.DeserializeObject<TokenResponse>(content);

            //Store token
            await _localStorage.SetItemAsync("authToken", token.Token);

            //Change auth state of the app
            await ((ApiAuthenticationStateProvider)_authProvider).LoggedIn();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token.Token);

            return true;
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("authToken");
            await ((ApiAuthenticationStateProvider)_authProvider).LoggedOut();
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
