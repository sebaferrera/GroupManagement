﻿using GroupManagement.BlazorUI.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GroupManagement.BlazorUI.Service
{
    public class BaseService<T> : IBaseService<T> where T : class
    {
        private readonly IHttpClientFactory _client;
        public BaseService(IHttpClientFactory client)
        {
            _client = client;
        }
        public async Task<bool> Create(string url, T obj)
        {
            if (obj == null)
                return false;

            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Content = new StringContent(JsonConvert.SerializeObject(obj)
                , Encoding.UTF8, "application/json");

            var client = _client.CreateClient();
            HttpResponseMessage response = await client.SendAsync(request);

            return response.StatusCode == System.Net.HttpStatusCode.Created;
        }

        public async Task<bool> Delete(string url, int id)
        {
            if (id < 1)
                return false;

            var request = new HttpRequestMessage(HttpMethod.Delete, url + id.ToString());

            var client = _client.CreateClient();
            HttpResponseMessage response = await client.SendAsync(request);

            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }

        public async Task<T> Get(string url, int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url + id.ToString());
            var client = _client.CreateClient();

            HttpResponseMessage response = await client.SendAsync(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(content);
            }

            return null;
        }

        public async Task<IList<T>> Get(string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var client = _client.CreateClient();

            HttpResponseMessage response = await client.SendAsync(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IList<T>>(content);
            }

            return null;
        }

        public async Task<bool> Update(string url, T obj)
        {
            if (obj == null)
                return false;

            var request = new HttpRequestMessage(HttpMethod.Put, url);
            request.Content = new StringContent(JsonConvert.SerializeObject(obj)
                , Encoding.UTF8, "application/json");

            var client = _client.CreateClient();

            HttpResponseMessage response = await client.SendAsync(request);
            return response.StatusCode == System.Net.HttpStatusCode.OK;
        }
    }
}
