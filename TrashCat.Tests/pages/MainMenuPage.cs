namespace TrashCat.Tests.pages
{
    public class MainMenuPage : BasePage
    {
        public MainMenuPage(AltDriver driver) : base(driver)
        {
        }
        public void LoadScene()
        {
            Driver.LoadScene("Main");
        }

        public AltObject StoreButton { get => Driver.WaitForObject(By.NAME, "StoreButton", timeout: 10); }
        public AltObject LeaderBoardButton { get => Driver.WaitForObject(By.NAME, "OpenLeaderboard", timeout: 10); }
        public AltObject SettingsButton { get => Driver.WaitForObject(By.NAME, "SettingButton", timeout: 10); }
        public AltObject MissionButton { get => Driver.WaitForObject(By.NAME, "MissionButton", timeout: 10); }
        public AltObject RunButton { get => Driver.WaitForObject(By.NAME, "StartButton", timeout: 10); }
        public AltObject CharacterName { get => Driver.WaitForObject(By.NAME, "CharName", timeout: 10); }
        public AltObject ThemeZone { get => Driver.WaitForObject(By.NAME, "ThemeZone", timeout: 10); }
        public AltObject FindObjectByComponentLoadoutState { get => Driver.FindObject(By.COMPONENT, "LoadoutState"); }
        public AltObject StartButtonChild { get => Driver.FindObject(By.PATH, "//StartButton/Text"); }
        public AltObject AboutButton { get => Driver.FindObject(By.NAME, "About"); }
        public AltObject CloseSettingsButton { get => Driver.FindObject(By.PATH, "//SettingPopup/*/CloseButton"); }
        public AltObject CloseStoreButton { get => Driver.FindObject(By.PATH, "/Canvas/Background/Button"); }
        public bool IsDisplayed()
        {
            if (StoreButton != null && LeaderBoardButton != null && SettingsButton != null && MissionButton != null 
            && RunButton != null && CharacterName != null && ThemeZone != null)
                return true;
            return false;
        }

        public void TapRun()
        {
            RunButton.Tap();
        }
        public string GetCharNameDisplay()
        {
            return FindObjectByComponentLoadoutState.GetComponentProperty<string>("LoadoutState", "charNameDisplay.text", "Assembly-CSharp");
        }
        public void SetCharNameDisplay(string valueToSet)
        {
            Assert.That(GetCharNameDisplay(), Is.EqualTo("Trash Cat"));
            FindObjectByComponentLoadoutState.SetComponentProperty("LoadoutState", "charNameDisplay.text", valueToSet, "Assembly-CSharp");
        }
        public string GetTextRunButton()
        {
            return StartButtonChild.GetText();
        }
        public void SetTextRunButton(string valueToSet)
        {
            StartButtonChild.SetText(valueToSet);
        }
        public void TapSettings()
        {
            SettingsButton.Tap();
        }
        public void TapCloseSettings()
        {
            CloseSettingsButton.Tap();
        }
        public void TapStore()
        {
            StoreButton.Tap();
        }
        public void TapCloseStore()
        {
            CloseStoreButton.Tap();
        }
        public string GetCurrentSelectionForObject(AltObject Object)
        {
            return Object.GetComponentProperty<string>("UnityEngine.UI.Button", "currentSelectionState", "UnityEngine.UI");
        }
        public object GetColorFromObject(AltObject Object)
        {
            return Object.CallComponentMethod<object>("UnityEngine.CanvasRenderer", "GetColor", "UnityEngine.UIModule", new object[] { });
        }
        public short GetScreenWidth()
        {
            return Driver.CallStaticMethod<short>("UnityEngine.Screen", "get_width", "UnityEngine.CoreModule", new string[] { }, null);
        }
        public short GetScreenHeight()
        {
            return Driver.CallStaticMethod<short>("UnityEngine.Screen", "get_height", "UnityEngine.CoreModule", new string[] { }, null);
        }
        public string GetScreenWidthFromProperty()
        {
            return Driver.GetStaticProperty<string>("UnityEngine.Screen", "width", "UnityEngine.CoreModule");
        }
        public string GetScreenHeightFromProperty()
        {
            return Driver.GetStaticProperty<string>("UnityEngine.Screen", "height", "UnityEngine.CoreModule");
        }
        public void SetScreenResolutionUsingCallStaticMethod(string widthSet, string heightSet)
        {
            string[] parameters = new[] { widthSet, heightSet, "false" };
            string [] typeOfParameters = new[] { "System.Int32", "System.Int32", "System.Boolean" };
            Driver.CallStaticMethod<string>("UnityEngine.Screen", "SetResolution", "UnityEngine.CoreModule", parameters, typeOfParameters );
        }
        public void SetFullScreenUsingSetStaticProperty()
        {
            //object[] parameters = {"true"};
            // fails with "Object reference not set to an instance of an object"

            //Driver.SetStaticProperty("UnityEngine.Screen", "fullScreen", "UnityEngine.CoreModule", new object[] { "true"});

            var heightCurrent = Driver.GetStaticProperty<string>("UnityEngine.Screen", "height", "UnityEngine.CoreModule");
            Console.WriteLine("Height from GetStaticProperty " + heightCurrent);
            object[] newValue = new[] {"true"};
            Driver.SetStaticProperty("UnityEngine.Screen", "fullScreen", "UnityEngine.CoreModule", newValue);
        }
        public bool GetFullScreenFromStaticProperty()
        {
            return Driver.GetStaticProperty<bool>("UnityEngine.Screen", "fullScreen", "UnityEngine.CoreModule");
        }
        public void SetOrientationUsingSetStaticProperty()
        {
            Driver.SetStaticProperty("UnityEngine.Screen", "orientation", "UnityEngine.CoreModule", new object[] {"ScreenOrientation.LandscapeLeft" });
        }
        public void SetSleepTimeoutFromStaticProperty()
        {
            var newValue = 5;
            Driver.SetStaticProperty("UnityEngine.Screen", "sleepTimeout", "UnityEngine.CoreModule", newValue);
        }
        public dynamic GetCurrentResolutionUsingGetStaticProperty()
        {
            return Driver.GetStaticProperty<dynamic>("UnityEngine.Screen", "currentResolution", "UnityEngine.CoreModule");
        }
        public string UseGetSetStringKeyPlayerPref(string key, string setValue)
        {
            Driver.SetKeyPlayerPref(key, setValue);
            return Driver.GetStringKeyPlayerPref(key);
        }
        public int UseGetSetIntKeyPlayerPref(string key, int setValue)
        {
            Driver.SetKeyPlayerPref(key, setValue);
            return Driver.GetIntKeyPlayerPref(key);
        }
        public float UseGetSetFloatKeyPlayerPref(string key, float setValue)
        {
            Driver.SetKeyPlayerPref(key, setValue);
            return Driver.GetFloatKeyPlayerPref(key);
        }
    }
}