﻿using ApiHackaton.Factory;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApiHackatonTests
{
    [TestClass]
    public class UnitTest1
    {
        private BlackBoxFactory factory;


        [TestInitialize]
        public void Init()
        {
            factory = new BlackBoxFactory();
        }

        [TestMethod]
        public void GetAllOffers()
        {
           factory.GetAllOffers();
        }


        [TestMethod]
        public void AssociateDevices()
        {
          var authorizedModel =  factory.AssociateDevices(new ApiHackaton.Entities.AuthorizedModel
            {
                DeviceOffers = new System.Collections.Generic.List<ApiHackaton.Entities.DeviceOffer>()
                {
                    new ApiHackaton.Entities.DeviceOffer
                    {
                        DeviceId = "3ad1fabc-068e-4d2c-bad9-633680c81eeb",
                        Label = "Queijo Minas Frescal Orgânico ",
                        Offer =  new ApiHackaton.Entities.Offer
                    {
                        Id = 1,
                        Label = "Queijo Minas Frescal Orgânico ",
                        Description = "Queijo Minas Frescal ",
                        MerchantSku = "83738773",
                        ImageUrl = "http://organomix.vteximg.com.br/arquivos/ids/16276-1000-1000/DSC03492.jpg",
                        Price = 19.05F,
                        Quantity = 1,
                        MerchantId = "612a64c0-22e7-4fb9-aa2b-eb31670f207f"
                    }
                    }
                },
                Label = "Test",
                CustomerId = 1
            });

            var authorizedModel2 = factory.AssociateDevices(new ApiHackaton.Entities.AuthorizedModel
            {
                DeviceOffers = new System.Collections.Generic.List<ApiHackaton.Entities.DeviceOffer>()
                {
                    new ApiHackaton.Entities.DeviceOffer
                    {
                        DeviceId = "3ad1fabc-068e-4d2c-bad9-633680c81eeb",
                        Label = "Queijo Minas Frescal Orgânico ",
                        Offer =  new ApiHackaton.Entities.Offer
                    {
                        Id = 1,
                        Label = "Queijo Minas Frescal Orgânico ",
                        Description = "Queijo Minas Frescal ",
                        MerchantSku = "83738773",
                        ImageUrl = "http://organomix.vteximg.com.br/arquivos/ids/16276-1000-1000/DSC03492.jpg",
                        Price = 19.05F,
                        Quantity = 1,
                        MerchantId = "612a64c0-22e7-4fb9-aa2b-eb31670f207f"
                    }
                    }
                },
                Label = "Test",
                CustomerId = 1
            });

            var teste = factory.GetDeviceOfferByCustomerId(authorizedModel.CustomerId);
        }
    }
}
