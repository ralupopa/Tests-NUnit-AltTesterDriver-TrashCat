using TrashCat.Tests.pages;

namespace TrashCat.Tests
{
    public class MainMenuTests
    {
        AltDriver altDriver;
        MainMenuPage mainMenuPage;
        StorePage storePage;
        GamePlay gamePlayPage;
        [SetUp]
        public void Setup()
        {
            altDriver = new AltDriver(port: 13000);
            mainMenuPage = new MainMenuPage(altDriver);
            storePage = new StorePage(altDriver);
            gamePlayPage = new GamePlay(altDriver);
            mainMenuPage.LoadScene();
        }

        [TearDown]
        public void Dispose()
        {
            altDriver.Stop();
            Thread.Sleep(1000);
        }

        [Test]
        public void TestMainMenuPageIsLoadedCorrectly()
        {
            Assert.True(mainMenuPage.IsDisplayed());
        }

        [Test]
        public void TestGetAndSetComponentPropertyString()
        {
            var newCharacterName = "Rich Cat";
            mainMenuPage.SetCharNameDisplay(newCharacterName);
            Assert.That(mainMenuPage.GetCharNameDisplay(), Is.EqualTo(newCharacterName));
        }
    }
}