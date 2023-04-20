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
        public AltObject FindObjectByComponentNIS { get => Driver.FindObject(By.COMPONENT, "Altom.AltTester.NewInputSystem"); }
        public List<AltObject> FindObjectsByComponentShopList { get => Driver.FindObjects(By.COMPONENT, "ShopItemListItem"); }
        public AltObject MagnetFindObjectByText { get => Driver.FindObject(By.TEXT, "Magnet"); }
        public List<AltObject> FindObjectsByTextBuy { get => Driver.FindObjects(By.TEXT, "BUY"); }
        public AltObject FindObjectWhichContainsPremium { get => Driver.FindObjectWhichContains(By.NAME, "Premium"); }
        public List<AltObject> FindObjectsWhichContainItemEntry { get => Driver.FindObjectsWhichContain(By.NAME, "ItemEntry(Clone"); }
        public AltObject StoreTitleFindObjectAtCoordinates { get => Driver.FindObjectAtCoordinates(new AltVector2(548, 568)); }
        public List<AltObject> GetAllEnabledObjects { get => Driver.GetAllElements(enabled: true); }
        public List<AltObject> GetAllDisabledObjects { get => Driver.GetAllElements(enabled: false); }
        public AltObject WaitForObjectWhichContainsPremium { get => Driver.WaitForObjectWhichContains(By.NAME, "Premi", timeout: 5); }
        public AltObject ItemsTab { get => Driver.FindObject(By.NAME, "Item"); }

        public bool IsDisplayed()
        {
            if (Store != null && CoinElement != null 
                && CoinsCounter != null && PremiumCounter != null)
                return true;
            return false;
        }

        public float GetColorOfObject()
        {
            return ItemsTab.GetComponentProperty<float>("UnityEngine.UI.Button", "colors.highlightedColor.r", "UnityEngine.UI");
        }

        public object CallComponentMethodGetColor()
        {
            return ItemsTab.CallComponentMethod<object>("UnityEngine.UI.Button", "get_colors", "UnityEngine.UI", new object[] { });
        }

        public string GetCurrentSelectionItemButton()
        {
            return ItemsTab.GetComponentProperty<string>("UnityEngine.UI.Button", "currentSelectionState", "UnityEngine.UI");
        }

    }
}