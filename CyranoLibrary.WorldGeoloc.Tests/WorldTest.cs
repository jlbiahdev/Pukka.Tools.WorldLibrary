using NUnit.Framework;
using System.Threading.Tasks;

namespace CyranoLibrary.WorldGeoloc.Tests
{
    internal class WorldTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task RetrieveCities_Test()
        {
            var lib = await GeoLocLibrary.GetInstanceAsync();
            var items = lib.GetCities();

            Assert.IsTrue(items.Count > 0);
        }

        [Test]
        public async Task RetrieveCountries_Test()
        {
            var lib = await GeoLocLibrary.GetInstanceAsync();
            var items = lib.GetCountries();

            Assert.IsTrue(items.Count > 0);
        }
    }
}