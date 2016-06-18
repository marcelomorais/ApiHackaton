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

        public JsonResult<List<Customer>> GetCustomers()
        {
            return Json(BlackBoxClientApi.Getcustomers());
        }

        public JsonResult<Customer> GetCustomer([FromUri] int id)
        {
            return Json(BlackBoxClientApi.Getcustomer(id));
        }
    }
}
