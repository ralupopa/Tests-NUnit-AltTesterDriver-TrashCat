using TrashCat.Tests.pages;

namespace TrashCat.Tests
{
    public class GamePlayTests
    {
        AltDriver altDriver;
        MainMenuPage mainMenuPage;
        GamePlay gamePlayPage;

        [SetUp]
        public void Setup()
        {

            altDriver = new AltDriver();
            mainMenuPage = new MainMenuPage(altDriver);
            mainMenuPage.LoadScene();

            gamePlayPage = new GamePlay(altDriver);

        }
        [TearDown]
        public void Dispose()
        {
            altDriver.Stop();
            Thread.Sleep(1000);
        }

        [Test]
        public void TestWaitForObjectNotBePresent()
        {
            Assert.NotNull(mainMenuPage.RunButton);
            mainMenuPage.TapRun();
            Assert.True(gamePlayPage.IsDisplayed());
            altDriver.WaitForObjectNotBePresent(By.NAME, "StartButton", timeout: 5);

            Assert.NotNull(gamePlayPage.PauseButton);
            gamePlayPage.TapPause();
            altDriver.WaitForObjectNotBePresent(By.NAME, "pauseButton", timeout: 5);
        }

    }
}