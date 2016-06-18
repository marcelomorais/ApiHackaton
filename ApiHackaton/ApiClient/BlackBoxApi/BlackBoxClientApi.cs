
using System;
using System.Collections.Generic;
using System.Configuration;
using ApiHackaton.Entities;
using RestSharp;
using RestSharp.Deserializers;

namespace ApiHackaton.ApiClient.BlackBoxApi
{
    public class BlackBoxClientApi
    {
        public IRestClient RestClient { get; set; }
        protected IDeserializer JsonDeserializer { get; set; }

        public string MerchantId { get { return "4C29C6C4-C65A-49C0-A2C9-FB70D3136FB5"; } }

        public string MerchantKey { get { return "PVrrSyO5LW9Y9l5hEoW9tC8hIjnIdtq0A683Qfp7"; } }

        public BlackBoxClientApi()
        {
            RestClient = new RestClient { BaseUrl = new Uri(GetBaseUrl()) };
            JsonDeserializer = new JsonDeserializer();
        }

        private static string GetBaseUrl()
        {
            var url = ConfigurationManager.AppSettings["BlackBoxUrl"];

            if (string.IsNullOrWhiteSpace(url))
                throw new InvalidOperationException("Configuration [PagadorApiRestBaseAddress] is invalid");

            if (!url.EndsWith("/"))
                url = url + "/";

            return url;
        }

        public List<Merchant> GetMerchants()
        {
            var httpRequest = new RestRequest(@"merchant/", Method.GET) { RequestFormat = DataFormat.Json };
           
            var response = RestClient.Execute(httpRequest);

            return JsonDeserializer.Deserialize<List<Merchant>>(response);
        }

        public List<Customer> Getcustomers()
        {
            var httpRequest = new RestRequest(@"customer/", Method.GET) { RequestFormat = DataFormat.Json };

            var response = RestClient.Execute(httpRequest);

            return JsonDeserializer.Deserialize<List<Customer>>(response);
        }

        public Customer Getcustomer(int id)
        {
            var httpRequest = new RestRequest(string.Format(@"customer/{0}", id), Method.GET) { RequestFormat = DataFormat.Json };

            var response = RestClient.Execute(httpRequest);

            return JsonDeserializer.Deserialize<Customer>(response);
        }
    }
}