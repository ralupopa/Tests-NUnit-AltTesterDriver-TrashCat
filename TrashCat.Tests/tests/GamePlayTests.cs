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

                Assert.True(pauseOverlayPage.IsDisplayed());
                pauseOverlayPage.TapMainMenu();
            });
        }

        [Test]
        [Order(1)]
        public void TestGetComponentPropertyInt()
        {
            Assert.True(gamePlayPage.IsDisplayed());
            Assert.That(gamePlayPage.GetCurrentLife(), Is.EqualTo(3));
        }

        [Test]
        [Order(2)]
        public void TestCallComponentMethodBoolean()
        {
            Assert.False(gamePlayPage.GetCheatInvincible());
        }

        [Test]
        [Order(3)]
        public void TestSetComponentPropertyInt()
        {
            gamePlayPage.SetCurrentLife(5);
            Assert.That(gamePlayPage.GetCurrentLife(), Is.EqualTo(5));
        }
        [Test]
        [Order(4)]
        public void TestUpdateObject()
        {
            Assert.NotNull(gamePlayPage.Character);

            Assert.Multiple(() =>
            {
                var TrashCat = gamePlayPage.Character;

                AltVector3 initialPostion = TrashCat.GetWorldPosition();

                Thread.Sleep(8000);

                AltVector3 AfterStartPostion = TrashCat.UpdateObject().GetWorldPosition();

                Assert.That(initialPostion, Is.Not.EqualTo(AfterStartPostion));

                gamePlayPage.ClickPause();

                Assert.True(pauseOverlayPage.IsDisplayed());
                pauseOverlayPage.TapMainMenu();
            });
        }
    }
}