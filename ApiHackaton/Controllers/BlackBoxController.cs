using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;
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

        [System.Web.Http.HttpGet]
        public JsonResult<Dictionary<string, List<Offer>>> AllOffers()
        {
            return Json(BlackBoxFactory.GetAllOffers());
        }

    }
}
