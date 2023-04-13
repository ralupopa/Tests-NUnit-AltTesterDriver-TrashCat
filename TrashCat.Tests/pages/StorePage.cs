namespace TrashCat.Tests.pages
{
    public class StorePage : BasePage
    {
        public StorePage(AltDriver driver) : base(driver)
        {
        }
        public void LoadScene()
        {
            Driver.LoadScene("Shop");
        }

        public AltObject Store { get => Driver.WaitForObject(By.NAME, "StoreTitle", timeout: 10); }
        public AltObject CoinElement { get => Driver.WaitForObject(By.NAME, "Coin", timeout: 10); }
        public AltObject CoinsCounter { get => Driver.WaitForObject(By.NAME, "CoinsCounter", timeout: 10); }
        public AltObject PremiumCounter { get => Driver.WaitForObject(By.NAME, "Premium", timeout: 10); }
        public AltObject CoinFindObjectByName { get => Driver.FindObject(By.NAME, "Coin"); }
        public AltObject CoinFindObjectByPath { get => Driver.FindObject(By.PATH, "/Canvas/Background/Coin"); }
        public List<AltObject> FindObjectsByTagUntagged { get => Driver.FindObjects(By.TAG, "Untagged"); }

        public bool IsDisplayed()
        {
            if (Store != null && CoinElement != null 
                && CoinsCounter != null && PremiumCounter != null)
                return true;
            return false;
        }

    }
}