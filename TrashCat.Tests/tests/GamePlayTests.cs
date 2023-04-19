using TrashCat.Tests.pages;

namespace TrashCat.Tests
{
    public class GamePlayTests
    {
        AltDriver altDriver;
        MainMenuPage mainMenuPage;
        GamePlay gamePlayPage;
        PauseOverlayPage pauseOverlayPage;

        [SetUp]
        public void Setup()
        {

            altDriver = new AltDriver();
            mainMenuPage = new MainMenuPage(altDriver);
            mainMenuPage.LoadScene();

            Assert.NotNull(mainMenuPage.RunButton);
            mainMenuPage.TapRun();

            gamePlayPage = new GamePlay(altDriver);
            pauseOverlayPage = new PauseOverlayPage(altDriver);

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
            Assert.Multiple(() =>
            {
                Assert.True(gamePlayPage.IsDisplayed());
                altDriver.WaitForObjectNotBePresent(By.NAME, "StartButton", timeout: 5);

                Assert.NotNull(gamePlayPage.PauseButton);
                gamePlayPage.TapPause();
                altDriver.WaitForObjectNotBePresent(By.NAME, "pauseButton", timeout: 15);

                pauseOverlayPage.TapMainMenu();

            });
        }

        [Test, Order(1)]
        public void TestGetComponentPropertyInt()
        {
            Assert.True(gamePlayPage.IsDisplayed());
            Assert.That(gamePlayPage.GetCurrentLife(), Is.EqualTo(3));
        }

        [Test]
        public void TestCallComponentMethodBoolean()
        {
            Assert.False(gamePlayPage.GetCheatInvincible());
        }

    }
}