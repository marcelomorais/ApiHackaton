using ApiHackaton.Factory;
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
    }
}
