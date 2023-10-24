using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgFlowManager.Requester.API
{
    public class GenericAPIRequester
    {
        private readonly string _url = @"https://localhost:7131/api/";
        public HttpClient HttpClient { get; set; }

        public GenericAPIRequester()
        {
            HttpClient = new HttpClient();
            HttpClient.BaseAddress = new Uri(_url);
        }

        private TReturn JSONResponse<TReturn>(HttpResponseMessage response)
        {
            Type responseType = typeof(TReturn);

            if (response.IsSuccessStatusCode)
            {
                //string responseStr = response.Content.ReadAsStringAsync().Result;
                //Console.WriteLine(responseStr);
                if (responseType == typeof(bool)) return (TReturn)(object)(response.StatusCode == System.Net.HttpStatusCode.OK);
                else if (responseType == typeof(string)) return (TReturn)(object)response.Content.ReadAsStringAsync().Result;
                else return JSONDeserialize<TReturn>(ref response);
            }
            else throw new Exception(response.StatusCode.ToString());
        }
        private TModel JSONDeserialize<TModel>(ref HttpResponseMessage response)
        {
            string json = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<TModel>(json);
        }
        private HttpContent JSONSerialize<TModel>(TModel model, string mediaType = "application/json")
        {
            string jsonToSend = JsonConvert.SerializeObject(model);
            return new StringContent(jsonToSend, Encoding.UTF8, mediaType);
        }
        private TReturn SerializeLogic<TReturn, TModel>(Func<string, HttpContent, HttpResponseMessage> urlToResponse,
                                                                    string url, TModel model,
                                                                    string token = "",
                                                                    string mediaType = "application/json")
        {
            if (!string.IsNullOrWhiteSpace(token))
                HttpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

            using HttpResponseMessage response = urlToResponse(url, JSONSerialize(model, mediaType));

            return JSONResponse<TReturn>(response);
        }
        private TReturn DeserializeLogic<TReturn>(Func<string, HttpResponseMessage> urlToResponse,
                                                                    string url,
                                                                    string token = "")
        {
            if (!string.IsNullOrWhiteSpace(token))
                HttpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

            using HttpResponseMessage response = urlToResponse(url);

            return JSONResponse<TReturn>(response);
        }

        public TModel Get<TModel>(string url, string token = "")
        {
            return DeserializeLogic<TModel>(url => HttpClient.GetAsync(url).Result, url, token);
        }
        public TReturn Post<TReturn, TModel>(TModel model, string url, string token = "", string mediaType = "application/json")
        {
            return SerializeLogic<TReturn, TModel>((url, content) => HttpClient.PostAsync(url, content).Result, url, model, token, mediaType);
        }
        public bool Delete(string url, string token = "")
        {
            return DeserializeLogic<bool>(url => HttpClient.DeleteAsync(url).Result, url, token);
        }
        public bool Patch<TModel>(TModel model, string url, string token = "", string mediaType = "application/json")
        {
            return SerializeLogic<bool, TModel>((url, content) => HttpClient.PatchAsync(url, content).Result, url, model, token, mediaType);
        }
    }
}
