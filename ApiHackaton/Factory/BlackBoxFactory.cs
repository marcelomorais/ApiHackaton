using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.Caching;
using ApiHackaton.ApiClient.BlackBoxApi;
using ApiHackaton.Entities;



namespace ApiHackaton.Factory
{
    public class BlackBoxFactory
    {
        private BlackBoxClientApi BlackBoxClientApi;

        public BlackBoxFactory()
        {
            BlackBoxClientApi = new BlackBoxClientApi();
        }

        public Dictionary<string, List<Offer>> GetAllOffers()
        {
            var merchants = BlackBoxClientApi.GetMerchants();
            var retorno = new List<Offer>();

            foreach (var merchant in merchants)
            {
                retorno.AddRange(BlackBoxClientApi.GetOffersByMerchantId(merchant.MerchantId));
            }

            var group = retorno.GroupBy(x => x.MerchantId);
            var items = new Dictionary<string, List<Offer>>();

            foreach (var item in group)
            {
                var merchantName = merchants.FirstOrDefault(x => x.MerchantId.ToString() == item.Key).Name;
                items.Add(merchantName, item.ToList());
            }

            return items;
        }

        public AuthorizedModel SaveAuthorizedModel(AuthorizedModel authorizedModel)
        {
            authorizedModel.CartId = Guid.NewGuid();
            MemoryCacher.Add(authorizedModel.CustomerId.ToString(), authorizedModel, null);

            return authorizedModel;
        }

        public AuthorizedModel AssociateDevices(AuthorizedModel authorizedModel)
        {
            var deviceOffer = new List<DeviceOffer>();

            foreach (var item in authorizedModel.DeviceOffers)
            {
                var device = BlackBoxClientApi.CreateDevice();
                device.CustomerId = authorizedModel.CustomerId;
                device.OfferId = item.Offer.Id;
                device = BlackBoxClientApi.ConnectDeviceToOffer(device);

                if (BlackBoxClientApi.Authorize(device.Id))
                    deviceOffer.Add(new DeviceOffer { Label = authorizedModel.Label, DeviceId = device.Id, Offer = item.Offer });
            }
            authorizedModel.DeviceOffers = deviceOffer;
            
            return SaveAuthorizedModel(authorizedModel);
        }

        public AuthorizedModel GetDeviceOfferByCustomerId(int customerId)
        {
            var authorizedModel = new AuthorizedModel();

            if (MemoryCacher.CheckIfAlreadyExists<AuthorizedModel>(customerId.ToString()))
            {
                authorizedModel = MemoryCacher.GetValue<AuthorizedModel>(customerId.ToString());
            }

            return authorizedModel;
        }

        public List<Offer> GetOffersByDevice(Guid deviceId)
        {
            var orders = BlackBoxClientApi.GetOrders(deviceId, null, null);
            var i = new List<int>();
            var offers = new List<Offer>();
            foreach (var order in orders)
            {
                if (!i.Contains(order.OfferId))
                {

                    offers.AddRange(BlackBoxClientApi.GetOfferById(order.OfferId));
                    i.Add(order.OfferId);
                }
            }

            return offers;
        }

    }
}