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
        public string GetCurrentSelectionForObject(AltObject Object)
        {
            return Object.GetComponentProperty<string>("UnityEngine.UI.Button", "currentSelectionState", "UnityEngine.UI");
        }
        public object GetColorFromObject(AltObject Object)
        {
            return Object.CallComponentMethod<object>("UnityEngine.CanvasRenderer", "GetColor", "UnityEngine.UIModule", new object[] { });
        }

    }
}