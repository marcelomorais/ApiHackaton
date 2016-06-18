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

        public Guid SaveListOffers(List<Offer> offfers)
        {
            var orderId = Guid.NewGuid();

            MemoryCacher.Add(orderId.ToString(), offfers, null);
            
            return orderId;
        }




        //public List<Offer> GetOfferByOrderId(Guid orderId)
        //{
        //    if (MemoryCache.Default.Contains(CacheKey))
        //    {
        //        // expensiveString = MemoryCache.Default[CacheKey] as string;
        //    }


        //    return null;
        //}


    }


}