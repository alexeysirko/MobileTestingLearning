using Aquality.Appium.Mobile.Elements.Interfaces;
using Aquality.Appium.Mobile.Screens;

namespace MobileTestingHomework.Screens.SearchTab
{
    internal class TabBar : Screen
    {
        private IButton TabButtonByIdPart(string idPart) => ElementFactory.GetButton(By.Id($"org.joinmastodon.android:id/tab_{idPart.ToLower()}"), $"tab button with id part '{idPart}'");

        public TabBar() : base(By.Id("org.joinmastodon.android:id/tabbar"), "Tab Bar")
        {
        }

        public void ClickTabButtonByIdPart(string idPart)
        {
            TabButtonByIdPart(idPart).Click();
        }
    }
}
