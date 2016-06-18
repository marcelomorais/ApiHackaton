﻿using ApiHackaton.ApiClient.BlackBoxApi;
using ApiHackaton.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Results;
using ApiHackaton.Factory;
using Newtonsoft.Json;

namespace ApiHackaton.Controllers
{
    [RoutePrefix("BlackBox")]
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

        [HttpGet]
        [Route("Merchants")]
        public JsonResult<List<Merchant>> Merchants()
        {
            return Json(BlackBoxClientApi.GetMerchants());
        }
        [HttpGet]
        [Route("OffersByMerchantId")]
        public JsonResult<List<Offer>> OffersByMerchantId(Guid? merchantId = null)
        {
            return Json(BlackBoxClientApi.GetOffersByMerchantId(merchantId));
        }
        [HttpGet]
        [Route("Customers")]
        public JsonResult<List<Customer>> Customers()
        {
            return Json(BlackBoxClientApi.Getcustomers());
        }
        [HttpGet]
        [Route("Customer")]
        public JsonResult<Customer> Customer([FromUri] int id)
        {
            return Json(BlackBoxClientApi.Getcustomer(id));
        }

        [HttpGet]
        [Route("Order/Device")]
        public JsonResult<List<Order>> DeviceOrder([FromUri]Guid deviceId, [FromUri]Guid merchantId, int? id = null)
        {
            return Json(BlackBoxClientApi.GetOrders(deviceId, merchantId, id));
        }

        [HttpGet]
        [Route("Order/Authorized")]
        public JsonResult<List<Order>> AuthorizedOrders([FromUri]Guid merchantId)
        {
            return Json(BlackBoxClientApi.GetOrdersAuthorized(merchantId));
        }

        [HttpGet]
        [Route("AllOffers")]
        public JsonResult<Dictionary<string, List<Offer>>> AllOffers()
        {
            return Json(BlackBoxFactory.GetAllOffers());
        }

        [HttpGet]
        [Route("DevicesByCustomerId")]
        public JsonResult<List<Device>> DevicesByCustomerId(int customerId)
        {
            return Json(BlackBoxClientApi.GetDevice().Where(x => x.CustomerId == customerId).ToList());
        }

        [HttpPost]
        [Route("DevicesByCustomerId")]
        public JsonResult<Guid?> Authorize(AuthorizedModel authorizedModel)
        {
            return Json(BlackBoxFactory.AssociateDevices(authorizedModel));
        }

    }
}
