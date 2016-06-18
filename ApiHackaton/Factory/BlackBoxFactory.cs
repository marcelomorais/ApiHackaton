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
        private readonly MemoryCacher MemoryCacher;

        public BlackBoxFactory()
        {
            BlackBoxClientApi = new BlackBoxClientApi();
            MemoryCacher = new MemoryCacher();
        }

        public Dictionary<string, List<Offer>> GetAllOffers()
        {
            var merchants = BlackBoxClientApi.GetMerchants();
            var retorno = new List<Offer>();

            foreach (var merchant in merchants)
            {
                retorno.AddRange(BlackBoxClientApi.GetOffersByMerchantId(merchant.MerchantId));
            }

           var group =  retorno.GroupBy(x => x.MerchantId);
           var items = new Dictionary<string, List<Offer>>();

            foreach (var item in group)
            {
                items.Add(item.Key, item.ToList());
            }

            return items;
        }

        public Guid SaveListDeviceOffers(List<DeviceOffer> deviceOffers)
        {
            var orderId = Guid.NewGuid();

            var saved = MemoryCacher.Add(orderId.ToString(), deviceOffers, null);
            
            return saved ? orderId : Guid.Empty;
        }

        //public List<Offer> GetOfferByOrderId(Guid orderId)
        //{
        //    if (MemoryCache.Default.Contains(CacheKey))
        //    {
        //        // expensiveString = MemoryCache.Default[CacheKey] as string;
        //    }


        //    return null;
        //}

        public Guid? AssociateDevices(AuthorizedModel authorizedModel)
        {
            var deviceOffer = new List<DeviceOffer>();

            foreach (var item in authorizedModel.Offers)
            {
                var device = BlackBoxClientApi.CreateDevice();
                device.CustomerId = authorizedModel.CustomerId;
                device.OfferId = item.Id;
                device = BlackBoxClientApi.ConnectDeviceToOffer(device);
                deviceOffer.Add(new DeviceOffer { TokenName = authorizedModel.TokenName ,DeviceId = device.Id, Offer = item });
            }

            var saveOnMemory = SaveListDeviceOffers(deviceOffer);

            if (saveOnMemory != Guid.Empty)
                return saveOnMemory;

            return null;
        }

    }


}