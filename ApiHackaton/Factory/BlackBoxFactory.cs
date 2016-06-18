using System.Linq;
using System.Collections.Generic;
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

           var group =  retorno.GroupBy(x => x.MerchantId);
           var items = new Dictionary<string, List<Offer>>();

            foreach (var item in group)
            {
                items.Add(item.Key, item.ToList());
            }

            return items;
        }

    }
}