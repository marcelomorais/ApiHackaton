using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;
using ApiHackaton.ApiClient.BlackBoxApi;
using ApiHackaton.Entities;
using ApiHackaton.Factory;
using Newtonsoft.Json;

namespace ApiHackaton.Controllers
{
    public class BlackBoxController : ApiController
    {
        public BlackBoxClientApi BlackBoxClientApi;
        public BlackBoxFactory BlackBoxFactory;
        public JsonSerializerSettings JsonSerializerSettings;
        public BlackBoxController()
        {
            BlackBoxClientApi = new BlackBoxClientApi();
            BlackBoxFactory = new BlackBoxFactory();
            JsonSerializerSettings = new JsonSerializerSettings();
        }

        [System.Web.Http.HttpGet]
        public JsonResult<List<Merchant>> Merchants()
        {
            return Json(BlackBoxClientApi.GetMerchants());
        }
        [System.Web.Http.HttpGet]
        public JsonResult<List<Offer>> OffersByMerchantId(Guid? merchantId = null)
        {
            return Json(BlackBoxClientApi.GetOffersByMerchantId(merchantId));
        }
        public JsonResult<List<Customer>> GetCustomers()
        {
            return Json(BlackBoxClientApi.Getcustomers());
        }

        public JsonResult<Customer> GetCustomer([FromUri] int id)
        {
            return Json(BlackBoxClientApi.Getcustomer(id));
        }

        public JsonResult<List<Order>> GetOrders([FromUri]Guid deviceId, [FromUri]Guid merchantId)
        {
            return Json(BlackBoxClientApi.GetOrders(deviceId, merchantId));
        }

        [System.Web.Http.HttpGet]
        public JsonResult<Dictionary<string, List<Offer>>> AllOffers()
        {
            return Json(BlackBoxFactory.GetAllOffers());
        }
        public JsonResult<List<Order>> GetOrdersAuthorized([FromUri]Guid merchantId)
        {
            return Json(BlackBoxClientApi.GetOrdersAuthorized(merchantId));
        }

    }
}
