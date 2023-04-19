namespace TrashCat.Tests.pages
{
    public class GamePlay : BasePage
    {
        public GamePlay(AltDriver driver) : base(driver)
        {
        }
        public void LoadScene()
        {
            Driver.LoadScene("Main");
        }

        public AltObject PauseButton { get => Driver.WaitForObject(By.NAME, "pauseButton", timeout: 5); }
        public AltObject Character { get => Driver.WaitForObject(By.NAME, "PlayerPivot"); }

        public bool IsDisplayed()
        {
            if (PauseButton != null && Character != null)
                return true;
            return false;
        }

        public void TapPause()
        {
            PauseButton.Tap();
        }
        public int GetCurrentLife()
        {
            return Character.GetComponentProperty<int>("CharacterInputController", "currentLife", "Assembly-CSharp");
        }
        public bool GetCheatInvincible()
        {
            return Character.CallComponentMethod<bool>("CharacterInputController", "IsCheatInvincible", "Assembly-CSharp", new object[] { });
        }

        public void SetCurrentLife(int valueToSet)
        {
            Assert.NotNull(Character);
            Assert.That(GetCurrentLife(), Is.EqualTo(3));

            Character.SetComponentProperty("CharacterInputController", "currentLife", valueToSet, "Assembly-CSharp");
        }
    }
}