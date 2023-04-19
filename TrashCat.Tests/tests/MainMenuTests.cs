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

        [Test, Description("Use GetComponentProperty and SetComponentProperty for property from 'Fields' column")]
        public void TestGetAndSetComponentPropertyString()
        {
            var newCharacterName = "Rich Cat";
            mainMenuPage.SetCharNameDisplay(newCharacterName);
            Assert.That(mainMenuPage.GetCharNameDisplay(), Is.EqualTo(newCharacterName));
        }
        [Test]
        public void TestFindObjectByPathSelectChild()
        {
            Assert.NotNull(mainMenuPage.StartButtonChild);
        }
        [Test]
        public void TestGetAndSetTextOnStartButton()
        {
            var newTextStartBtn = "Just play";
            Assert.That(mainMenuPage.GetTextRunButton(), Is.EqualTo("Run!"));
            mainMenuPage.SetTextRunButton(newTextStartBtn);
            Assert.That(mainMenuPage.GetTextRunButton(), Is.EqualTo(newTextStartBtn));

        }
    }
}