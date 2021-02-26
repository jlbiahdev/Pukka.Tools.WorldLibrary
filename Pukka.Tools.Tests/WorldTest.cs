using NUnit.Framework;
using Pukka.Tools.Countries;
using System.Threading.Tasks;

namespace Pukka.Tools.Tests
{
    public class WorldTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task RetrieveCities_Test()
        {
            var lib = GeoLibrary.GetInstance();
            await lib.InitializeAsync();

            var items = lib.GetCities();

            Assert.IsTrue(items.Count > 0);
        }

        [Test]
        public void RetrieveCities_FailWithException_Test()
        {
            try
            {
                var lib = GeoLibrary.GetInstance();
                var items = lib.GetCities();

            }
            catch (System.NullReferenceException x)
            {
                Assert.IsTrue(x.Message.Equals("City list is not initialized yet"));
            }
        }

        [Test]
        public async Task RetrieveCountries_Test()
        {
            var lib = GeoLibrary.GetInstance();
            await lib.InitializeAsync();

            var items = lib.GetCountries();

            Assert.IsTrue(items.Count > 0);
        }

        [Test]
        public void RetrieveCountries_FailWithException_Test()
        {
            try
            {
                var lib = GeoLibrary.GetInstance();
                var items = lib.GetCountries();

            }
            catch (System.NullReferenceException x)
            {
                Assert.IsTrue(x.Message.Equals("Country list is not initialized yet"));
            }
        }
    }
}