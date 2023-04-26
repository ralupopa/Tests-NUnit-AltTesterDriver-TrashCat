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
        [Description("Use GetComponentProperty and SetComponentProperty for property from 'Fields' column")]
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

        [Test]
        public void TestGetParent()
        {
            Assert.NotNull(mainMenuPage.StartButtonChild);
            var startButton = mainMenuPage.StartButtonChild.GetParent();
            Assert.That(startButton.name, Is.EqualTo("StartButton"));
        }

        [Test]
        public void TestMoveMouseToObjectCoordinates()
        {
            mainMenuPage.TapSettings();
            var AboutBtn = mainMenuPage.AboutButton;
            Assert.NotNull(AboutBtn);
            var btnWorldCoordinates = AboutBtn.GetWorldPosition();

            Assert.Multiple(() =>
            {
                var stateBeforeMoveMouse = mainMenuPage.GetCurrentSelectionForObject(AboutBtn);
                Assert.That(stateBeforeMoveMouse, Is.EqualTo("0"));

                altDriver.MoveMouse(new AltVector2(btnWorldCoordinates.x, btnWorldCoordinates.y), 1);

                var stateAfterMoveMouse = mainMenuPage.GetCurrentSelectionForObject(AboutBtn);
                altDriver.SetDelayAfterCommand(2);
                Assert.That(stateAfterMoveMouse, Is.EqualTo("1"));

                Assert.That(stateBeforeMoveMouse, Is.Not.EqualTo(stateAfterMoveMouse));
                mainMenuPage.TapCloseSettings();
            });
        }

        [Test]
        public void TestAboutPointerEnterAndExit()
        {
            mainMenuPage.TapSettings();
            var AboutBtn = mainMenuPage.AboutButton;
            Assert.NotNull(AboutBtn);

            Assert.Multiple(() =>
            {
                var stateBeforePointerEnter = mainMenuPage.GetCurrentSelectionForObject(AboutBtn);
                Assert.That(stateBeforePointerEnter, Is.EqualTo("0"));

                Console.WriteLine("Before " + mainMenuPage.GetColorFromObject(AboutBtn));

                //AboutBtn.PointerEnterObject();
                Console.WriteLine(mainMenuPage.CallComponentMethodOnPointerEnter(AboutBtn));
                altDriver.SetDelayAfterCommand(3);
                //Console.WriteLine(mainMenuPage.GetCurrentSelectionForObject(AboutBtn));
                Console.WriteLine("After " + mainMenuPage.GetColorFromObject(AboutBtn));

                mainMenuPage.TapCloseSettings();
            });
        }
        [Test]
        public void TestGetAllComponents()
        {
            var expectedComponents = ListOfComponentNamesForStoreButton();
            var storeBtnComponentsList = mainMenuPage.StoreButton.GetAllComponents();

            Assert.IsNotEmpty(storeBtnComponentsList);
            for (int index = 0; index <= storeBtnComponentsList.Count-1; index++)
            {
                Assert.That(storeBtnComponentsList[index].componentName, Is.EqualTo(expectedComponents[index]));
            }
        }
        [Test]
        public void TestGetAllProperties()
        {
            AltComponent testComponent = new AltComponent("UnityEngine.CanvasRenderer", "UnityEngine.UIModule");
            var storeBtnProperties = mainMenuPage.StoreButton.GetAllProperties(testComponent);

            Assert.That(storeBtnProperties.Count, Is.EqualTo(16));
            Assert.That(storeBtnProperties[0].name, Is.EqualTo("hasPopInstruction"));
            Assert.That(storeBtnProperties[0].value, Is.EqualTo("False"));
        }
        public static List<string> ListOfComponentNamesForStoreButton()
        {
            var listComponents = new List<string>()
            {
                "UnityEngine.RectTransform",
                "UnityEngine.CanvasRenderer",
                "UnityEngine.UI.Image",
                "UnityEngine.UI.Button",
                "LevelLoader",
                "UnityEngine.AudioSource"
            };
            return listComponents;
        }
    }
}