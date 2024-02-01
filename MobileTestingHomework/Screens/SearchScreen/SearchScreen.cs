using Aquality.Appium.Mobile.Screens;

namespace MobileTestingHomework.Screens.SearchTab
{
    internal class SearchScreen : Screen
    {
        public SearchScreen() : base(By.Id("org.joinmastodon.android:id/search_wrap"), "Search")
        {
        }
    }
}
