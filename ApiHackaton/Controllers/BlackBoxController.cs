using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;
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
        public JsonResult<List<Merchant>> GetMerchants()
        {
            return Json(BlackBoxClientApi.GetMerchants());
        }

        public JsonResult<List<Merchant>> GetCustomer()
        {
            return Json(BlackBoxClientApi.GetMerchants());
        }
    }
}
