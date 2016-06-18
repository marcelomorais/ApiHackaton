using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;
using ApiHackaton.ApiClient.BlackBoxApi;
using ApiHackaton.Entities;

namespace ApiHackaton.Controllers
{
    public class BlackBoxController : ApiController
    {
        public BlackBoxClientApi BlackBoxClientApi;
        public BlackBoxController()
        {
            BlackBoxClientApi = new BlackBoxClientApi();
        }

        [HttpGet]
        public JsonResult<List<Merchant>> Merchants()
        {
            return Json(BlackBoxClientApi.GetMerchants());
        }
        [HttpGet]
        public JsonResult<List<Offer>> OffersByMerchantId(Guid? merchantId = null)
        {
            return Json(BlackBoxClientApi.GetOffersByMerchantId(merchantId));
        }
    }
}
