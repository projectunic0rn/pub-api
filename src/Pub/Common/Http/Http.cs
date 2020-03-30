using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Linq; 

namespace Common.Http
{
    public class Http
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        private async Task<T> MakeRequestAsync<T>(HttpRequestMessage request)
        {
            var result = await _httpClient.SendAsync(request);
            return await ParseResponse<T>(result);
        }

        private async Task<string> MakeRequestForHtmlAsync(HttpRequestMessage request)
        {
            var result = await _httpClient.SendAsync(request);
            return await result.Content.ReadAsStringAsync();
        }

        private async Task MakeRequestAsync(HttpRequestMessage request)
        {
            await _httpClient.SendAsync(request);
            return;
        }

        public async Task Get(string requestUri, Dictionary<string, string> headers)
        {
            HttpRequestMessage httpRequestMessage = BuildRequestMessage(HttpMethod.Get, requestUri);

            foreach (var header in headers)
            {
                httpRequestMessage.Headers.Add(header.Key, header.Value);
            }

            await MakeRequestAsync(httpRequestMessage);
            return;
        }


        public async Task<string> GetHtml(string requestUri, Dictionary<string, string> headers)
        {
            HttpRequestMessage httpRequestMessage = BuildRequestMessage(HttpMethod.Get, requestUri);

            foreach (var header in headers)
            {
                httpRequestMessage.Headers.Add(header.Key, header.Value);
            }

            var response = await MakeRequestForHtmlAsync(httpRequestMessage);
            return response;
        }

        public async Task<T> Get<T>(string requestUri, Dictionary<string, string> headers)
        {
            HttpRequestMessage httpRequestMessage = BuildRequestMessage(HttpMethod.Get, requestUri);

            foreach (var header in headers)
            {
                httpRequestMessage.Headers.Add(header.Key, header.Value);
            }

            return await MakeRequestAsync<T>(httpRequestMessage);
        }

        public async Task<T> Put<T>(string requestUri, Dictionary<string, string> headers)
        {
            HttpRequestMessage httpRequestMessage = BuildRequestMessage(HttpMethod.Put, requestUri);

            foreach (var header in headers)
            {
                httpRequestMessage.Headers.Add(header.Key, header.Value);
            }

            return await MakeRequestAsync<T>(httpRequestMessage);
        }

        public async Task<T> Put<T>(string requestUri, Dictionary<string, string> headers, object body)
        {
            HttpRequestMessage httpRequestMessage = BuildRequestMessage(HttpMethod.Put, requestUri, body);

            foreach (var header in headers)
            {
                httpRequestMessage.Headers.Add(header.Key, header.Value);
            }

            return await MakeRequestAsync<T>(httpRequestMessage);
        }
        
        public async Task<T> Post<T>(string requestUri, Dictionary<string, string> headers)
        {
            HttpRequestMessage httpRequestMessage = BuildRequestMessage(HttpMethod.Post, requestUri);

            foreach (var header in headers)
            {
                httpRequestMessage.Headers.Add(header.Key, header.Value);
            }

            return await MakeRequestAsync<T>(httpRequestMessage);
        }

        public async Task<T> Post<T>(string requestUri, Dictionary<string, string> headers, object body)
        {
            HttpRequestMessage httpRequestMessage = BuildRequestMessage(HttpMethod.Post, requestUri, body);

            foreach (var header in headers)
            {
                httpRequestMessage.Headers.Add(header.Key, header.Value);
            }

            return await MakeRequestAsync<T>(httpRequestMessage);
        }

        public async Task Post(string requestUri, Dictionary<string, string> headers)
        {
            HttpRequestMessage httpRequestMessage = BuildRequestMessage(HttpMethod.Post, requestUri);

            foreach (var header in headers)
            {
                httpRequestMessage.Headers.Add(header.Key, header.Value);
            }

            await MakeRequestAsync(httpRequestMessage);
            return;
        }

        public async Task Post(string requestUri, Dictionary<string, string> headers, object body)
        {
            HttpRequestMessage httpRequestMessage = BuildRequestMessage(HttpMethod.Post, requestUri, body);
            foreach (var header in headers)
            {
                httpRequestMessage.Headers.Add(header.Key, header.Value);
            }

            await MakeRequestAsync(httpRequestMessage);
            return;
        }

        private HttpRequestMessage BuildRequestMessage(HttpMethod method, string requestUri)
        {

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage
            {
                Method = method,
                RequestUri = new Uri(requestUri)
            };

            return httpRequestMessage;
        }

        private HttpRequestMessage BuildRequestMessage(HttpMethod method, string requestUri, object content)
        {

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage
            {
                Method = method,
                RequestUri = new Uri(requestUri),
                Content = new StringContent(
                JsonConvert.SerializeObject(content),
                Encoding.UTF8,
                "application/json")
            };

            return httpRequestMessage;
        }

        private async Task<T> ParseResponse<T>(HttpResponseMessage result)
        {
            var responseJson = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(responseJson);
        }
    }
}