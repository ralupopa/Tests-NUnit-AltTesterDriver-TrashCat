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

        [Test]
        public void TestFindObjectsByComponent()
        {
            Assert.NotNull(storePage.FindObjectByComponentNIS);
            Assert.NotNull(storePage.FindObjectsByComponentShopList);
            Assert.That(storePage.FindObjectsByComponentShopList.Count, Is.EqualTo(4));
        }

        [Test]
        public void TestFindObjectByText()
        {
            Assert.NotNull(storePage.MagnetFindObjectByText);
            Assert.NotNull(storePage.FindObjectsByTextBuy);
            Assert.That(storePage.FindObjectsByTextBuy.Count, Is.EqualTo(4));
        }

        [Test]
        public void TestGetScreenshot()
        {
            var path="../../../test-screenshot.png";
            altDriver.GetPNGScreenshot(path);
            FileAssert.Exists(path);
        }

        [Test]
        public void TestFindObjectWhichContains()
        {
            Assert.NotNull(storePage.FindObjectWhichContainsPremium);
        }
        [Test]
        public void TestFindObjectsWhichContain()
        {
            Assert.NotNull(storePage.FindObjectsWhichContainItemEntry);
            Assert.That(storePage.FindObjectsWhichContainItemEntry.Count, Is.EqualTo(4));
        }
        [Test]
        public void TestFindObjectAtCoordinates()
        {
            Assert.NotNull(storePage.StoreTitleFindObjectAtCoordinates);
            Assert.That(storePage.StoreTitleFindObjectAtCoordinates.GetText(), Is.EqualTo("STORE"));
        }
        [Test]
        public void TestGetAllEnabledObjects()
        {
            Assert.IsNotEmpty(storePage.GetAllEnabledObjects);
            var enabledObjectsCount = storePage.GetAllEnabledObjects.Count;
            Console.WriteLine("There are " + enabledObjectsCount + " enabled objects.");
            Assert.Greater(enabledObjectsCount, 300);
        }
        [Test]
        public void TestGetAllDisabledObjects()
        {
            Assert.IsNotEmpty(storePage.GetAllDisabledObjects);
            var disabledObjectsCount = storePage.GetAllDisabledObjects.Count;
            Console.WriteLine("There are " + disabledObjectsCount + " disabled objects.");
            Assert.Greater(disabledObjectsCount, 300);
        }

        [Test]
        public void TestWaitForObjectWhichContains()
        {
            var foundObject = storePage.WaitForObjectWhichContainsPremium;
            Assert.NotNull(foundObject);
            Assert.That(foundObject.name, Is.EqualTo("Premium"));
        }

        [Test]
        public void TestPointerUpAndDown()
        {
            var ItemsTabObject = storePage.ItemsTab;
            Assert.NotNull(ItemsTabObject);
            Assert.That(0.9607843f, Is.EqualTo(storePage.GetColorOfObject()));

            var stateBeforePointDown = storePage.GetCurrentSelectionForObject(ItemsTabObject);
            ItemsTabObject.PointerDownFromObject();

            var stateAfterPointDown = storePage.GetCurrentSelectionForObject(ItemsTabObject);
            Assert.That(stateBeforePointDown, Is.Not.EqualTo(stateAfterPointDown));

            ItemsTabObject.PointerUpFromObject();
            var stateAfterPointerUp = storePage.GetCurrentSelectionForObject(ItemsTabObject);
            Assert.That(stateAfterPointDown, Is.Not.EqualTo(stateAfterPointerUp));
        }
        [Test]
        public void TestCallComponentMethodForGetColors()
        {
            Assert.NotNull(storePage.CallComponentMethodGetColor());
        }
        [Test]
        public void TestPointerEnterAndExit()
        {
            var BuyButtonFirst = storePage.FindObjectsByTextBuy[0].GetParent();
            Assert.NotNull(BuyButtonFirst);

            var stateBeforePointEnter = storePage.GetCurrentSelectionForObject(BuyButtonFirst);
            BuyButtonFirst.PointerEnterObject();

            var stateAfterPointEnter = storePage.GetCurrentSelectionForObject(BuyButtonFirst);
            Assert.That(stateBeforePointEnter, Is.Not.EqualTo(stateAfterPointEnter));

            // var before = storePage.CallComponentMethodIsHighlighted();
            // Console.WriteLine(altDriver.GetDelayAfterCommand());
            // Console.WriteLine(before);

            // BuyButtonFirst.PointerEnterObject();
            // altDriver.SetDelayAfterCommand(5);
            // Console.WriteLine(altDriver.GetDelayAfterCommand());
            // var after = storePage.CallComponentMethodIsHighlighted();
            // Console.WriteLine(after);
            //Assert.That(before, Is.Not.EqualTo(after));
        }

    }
}