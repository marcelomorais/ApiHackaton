using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using ApiHackaton.Entities;
using RestSharp;
using RestSharp.Deserializers;

namespace ApiHackaton.ApiClient.BlackBoxApi
{
    public class BlackBoxClient2Api
    {
        public IRestClient RestClient { get; set; }
        protected IDeserializer JsonDeserializer { get; set; }

        public string MerchantId { get { return "4C29C6C4-C65A-49C0-A2C9-FB70D3136FB5"; } }

        public string MerchantKey { get { return "PVrrSyO5LW9Y9l5hEoW9tC8hIjnIdtq0A683Qfp7"; } }

        public BlackBoxClient2Api()
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

    }
}