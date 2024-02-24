using Aquality.Appium.Mobile.Elements.Interfaces;
using Aquality.Appium.Mobile.Screens;
using System.Drawing;

namespace MobileTestingHomework.Screens.SearchTab
{
    internal class SearchScreen : Screen
    {
        private ILabel _postLabels = ElementFactory.GetLabel(By.Id("org.joinmastodon.android:id/list"), "Posts");
        private IButton _searchField = ElementFactory.GetButton(By.Id("org.joinmastodon.android:id/search_text"), "Search text box");
        private ITextBox _activeSearchField = ElementFactory.GetTextBox(By.ClassName("android.widget.EditText"), "Active search text box");
        private ILabel _searchResultAvatar = ElementFactory.GetLabel(By.XPath("//android.widget.ImageView[@resource-id='org.joinmastodon.android:id/avatar']"), "First search result avatar");
        private IButton _postsWithHashtagButton = ElementFactory.GetButton(
            By.XPath("//android.widget.TextView[@resource-id='org.joinmastodon.android:id/title' and contains(@text,'Posts with “#')]")
            , "posts with hashtag");


        public SearchScreen() : base(By.Id("org.joinmastodon.android:id/search_wrap"), "Search")
        {
        }


        public Point GetSearchFieldPosition()
        {
            int x = _searchField.GetElement().Location.X;
            int y = _searchField.GetElement().Location.Y;
            return new Point(x, y);
        }

        public void EnterTextToActiveSearchField(string text)
        {
            _activeSearchField.Type(text);
        }

        public bool ArePostsDisplayed()
        {
            return _postLabels.State.WaitForDisplayed();
        }

        public bool IsNotEmptySearchResult()
        {
            return _searchResultAvatar.State.WaitForDisplayed();
        }

        public void ClickPostsWithHashtag()
        {
            _postsWithHashtagButton.Click();
        }
    }
}
