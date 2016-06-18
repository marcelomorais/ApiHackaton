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
        private MemoryCacher memoryCacher;

        public BlackBoxFactory()
        {
            BlackBoxClientApi = new BlackBoxClientApi();
            memoryCacher = new MemoryCacher();
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

        public Guid SaveListDevices(List<Device> devices)
        {
            var orderId = Guid.NewGuid();

            MemoryCacher.Add(orderId.ToString(), devices, null);
            
            return orderId;
        }

        public List<Offer> GetOfferByOrderId(Guid orderId)
        {
            var offers = new List<Offer>();
            if (MemoryCacher.CheckIfAlreadyExists<List<Offer>>(orderId.ToString()))
            {
                offers = MemoryCacher.GetValue<List<Offer>>(orderId.ToString());
            }

            return offers;
        }
    }


}