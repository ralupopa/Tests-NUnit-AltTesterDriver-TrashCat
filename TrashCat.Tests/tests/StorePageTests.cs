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
        public void TestAccessStore()
        {
            storePage.IsDisplayed();
        }
    }
}