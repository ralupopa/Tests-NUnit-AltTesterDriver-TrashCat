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

        public AltObject PauseButton { get => Driver.WaitForObject(By.NAME, "pauseButton", timeout: 2); }
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

    }
}