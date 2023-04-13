using TrashCat.Tests.pages;

namespace TrashCat.Tests
{
    public class StorePageTests
    {
        AltDriver altDriver;
        StorePage storePage;

        [SetUp]
        public void Setup()
        {
            altDriver = new AltDriver();
            storePage = new StorePage(altDriver);
            storePage.LoadScene();
        }

        [TearDown]
        public void Dispose()
        {
            altDriver.Stop();
            Thread.Sleep(1000);
        }

        [Test]
        public void TestAccessStoreIsDislayed()
        {
            Assert.IsTrue(storePage.IsDisplayed());
        }

        [Test]
        public void TestFindObjectByName()
        {
            Assert.NotNull(storePage.CoinFindObjectByName);
        }

        [Test]
        public void TestFindObjectByPath()
        {
            Assert.NotNull(storePage.CoinFindObjectByPath);
        }

        [Test]
        public void TestFindObjectsByTag()
        {
            Assert.NotNull(storePage.FindObjectsByTagUntagged);
            /// <summary>
            /// FindObjects by Tag 'Untagged' returns different count each time
            /// also in desktop the count is different on each search
            /// using Assert.Greater to verify that at least 100 elements are returned
            /// </summary>
            Thread.Sleep(3000);
            Assert.Greater(storePage.FindObjectsByTagUntagged.Count, 100);
        }
    }
}