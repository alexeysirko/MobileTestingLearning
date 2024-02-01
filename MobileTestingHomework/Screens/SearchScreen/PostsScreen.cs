using Aquality.Appium.Mobile.Elements.Interfaces;
using Aquality.Appium.Mobile.Screens;

namespace MobileTestingHomework.Screens.SearchTab
{
    internal class PostsScreen : Screen
    {
        private readonly ILabel _authorName = ElementFactory.GetLabel(By.Id("org.joinmastodon.android:id/name"), "Author Name");

        private readonly ILabel _postFromLabel = ElementFactory.GetLabel(
            By.XPath("//*[@resource-id='org.joinmastodon.android:id/toolbar']//android.widget.TextView[contains(@text,'Post from')]")
            , "post from");    

        private readonly ILabel _firstPostHeader = ElementFactory.GetLabel(
            By.XPath("//*[@resource-id='org.joinmastodon.android:id/list']/android.widget.RelativeLayout[1]")
            , "First Post Header");


        public PostsScreen() : base(By.Id("org.joinmastodon.android:id/discover_posts"), "Posts")
        {
        }

        public string GetAuthorName()
        {
            return _authorName.Text;
        }

        public void OpenFirstPost()
        {
            _firstPostHeader.Click();
        }       

        public string GetPostFromAuthorName()
        {
            return _postFromLabel.Text;
        }
    }
}
