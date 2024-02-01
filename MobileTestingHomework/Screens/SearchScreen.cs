using Aquality.Appium.Mobile.Elements.Interfaces;
using Aquality.Appium.Mobile.Screens;

namespace MobileTestingHomework.Screens
{
    internal class SearchScreen : Screen
    {
        private static readonly By s_searchBarXpath = By.Id("org.joinmastodon.android:id/search_wrap");

        private readonly ILabel _discoverPostsLayout = ElementFactory.GetLabel(By.Id("org.joinmastodon.android:id/discover_posts"), "discover posts layout");

        public SearchScreen() : base(s_searchBarXpath, "Search")
        {
        }

        public bool IsPostsScreenOpened()
        {
            return _discoverPostsLayout.State.WaitForDisplayed();
        }
    }
}
