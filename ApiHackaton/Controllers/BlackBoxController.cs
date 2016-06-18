﻿using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;
using ApiHackaton.ApiClient.BlackBoxApi;
using ApiHackaton.Entities;
using System;

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

        public JsonResult<List<Order>> GetOrders([FromUri]Guid deviceId, [FromUri]Guid merchantId)
        {
            return Json(BlackBoxClientApi.GetOrders(deviceId, merchantId));
        }

        public JsonResult<List<Order>> GetOrdersAuthorized([FromUri]Guid merchantId)
        {
            return Json(BlackBoxClientApi.GetOrdersAuthorized(merchantId));
        }
    }
}
