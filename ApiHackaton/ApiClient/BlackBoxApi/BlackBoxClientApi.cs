
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
            httpRequest.AddHeader("Content-Type", "application/json");
            var response = RestClient.Execute(httpRequest);

            return JsonDeserializer.Deserialize<List<Merchant>>(response);
        }

        public List<Offer> GetOffersByMerchantId(Guid? merchantId)
        {
           
                var httpRequest = new RestRequest(string.Concat(@"offer/merchant/", merchantId == Guid.Empty || merchantId == null ? MerchantId : merchantId.ToString()), Method.GET) { RequestFormat = DataFormat.Json };
            httpRequest.AddHeader("Content-Type", "application/json");
            var response = RestClient.Execute(httpRequest);

            return JsonDeserializer.Deserialize<List<Offer>>(response);
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

        public List<Order> GetOrders(Guid deviceId, Guid merchantId, int? id)
        {
            var httpRequest = new RestRequest(string.Format(@"order/?DeviceId=/{0}&{1}{2}", deviceId, merchantId, id == null ? string.Empty : string.Format("&id={0}", id)), Method.GET) { RequestFormat = DataFormat.Json };

            var response = RestClient.Execute(httpRequest);

            return JsonDeserializer.Deserialize<List<Order>>(response);
        }

        public List<Order> GetOrdersAuthorized(Guid merchantId)
        {
            var httpRequest = new RestRequest(string.Format(@"order/authorized/{0}", merchantId), Method.GET) { RequestFormat = DataFormat.Json };

            var response = RestClient.Execute(httpRequest);

            return JsonDeserializer.Deserialize<List<Order>>(response);
        }
        
        public Device CreateDevice(string type = "VIRTUAL")
        {
            var httpRequest = new RestRequest(@"device", Method.POST) { RequestFormat = DataFormat.Json };
            httpRequest.AddParameter("Type",type);
            var response = RestClient.Execute(httpRequest);

            return JsonDeserializer.Deserialize<Device>(response);
        }
        
        public bool Authorize(string deviceId)
        {
            var httpRequest = new RestRequest(@"device", Method.POST) { RequestFormat = DataFormat.Json };
            httpRequest.AddBody(deviceId);

            var response = RestClient.Execute(httpRequest);

            if (response.StatusCode == System.Net.HttpStatusCode.Created)
                return true;

            return false;
        }

        public List<Device> GetDevice()
        {
            var httpRequest = new RestRequest(@"device/", Method.GET) { RequestFormat = DataFormat.Json };

            var response = RestClient.Execute(httpRequest);

            return JsonDeserializer.Deserialize<List<Device>>(response);
        }

        public Device ConnectDeviceToOffer(Device device)
        {

            var httpRequest = new RestRequest(@"device/", Method.PUT) { RequestFormat = DataFormat.Json };
            httpRequest.AddBody(device);
            var response = RestClient.Execute(httpRequest);

            return JsonDeserializer.Deserialize<Device>(response);
        }

    }
}