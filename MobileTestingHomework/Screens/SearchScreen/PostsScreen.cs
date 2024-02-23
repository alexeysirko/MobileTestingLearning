using Aquality.Appium.Mobile.Actions;
using Aquality.Appium.Mobile.Applications;
using Aquality.Appium.Mobile.Elements.Interfaces;
using Aquality.Appium.Mobile.Screens;

namespace MobileTestingHomework.Screens.SearchTab
{
    internal class PostsScreen : Screen
    {
        private ILabel _firstAuthorName = ElementFactory.GetLabel(By.Id("org.joinmastodon.android:id/name"), "First author Names");

        private readonly ILabel _postFromLabel = ElementFactory.GetLabel(
            By.XPath("//*[@resource-id='org.joinmastodon.android:id/toolbar']//android.widget.TextView[contains(@text,'Post from')]")
            , "post from");    

        private readonly ILabel _firstPostHeader = ElementFactory.GetLabel(
            By.XPath("//*[@resource-id='org.joinmastodon.android:id/list']/android.widget.RelativeLayout[1]")
            , "First Post Header");

        private readonly ILabel _hashtagTitle = ElementFactory.GetLabel(By.Id("org.joinmastodon.android:id/title"), "Hashtag title");
        private readonly IButton _backButton = ElementFactory.GetButton(By.XPath("//android.widget.ImageButton[@content-desc='Back']"), "Back");
        //private List<IButton> ReplyButtons 
        //    => ElementFactory.FindElements<IButton>(By.XPath("//android.widget.Button[@resource-id='org.joinmastodon.android:id/reply_btn']"), "Reply buttons")
        //    .ToList();
        private IButton ReplyButton => ElementFactory.GetButton(By.Id("org.joinmastodon.android:id/reply_btn"), "Reply button");


        public PostsScreen() : base(By.Id("org.joinmastodon.android:id/discover_posts"), "Posts")
        {
        }


        public string GetHashtagTitle()
        {
            return _hashtagTitle.GetAttribute("text");
        }

        public string GetAuthorName()
        {
            return _firstAuthorName.GetAttribute("text");
        }

        public void OpenFirstPost()
        {
            _firstPostHeader.Click();
        }       

        public string GetPostFromAuthorName()
        {
            return _postFromLabel.GetAttribute("text");
        }

        public void ScrollToPostByNumber(int postNumber)
        {
            //It generates locator only for 2 posts. So I scroll to next post {postNumber} times           
            for (int i = 0; i < postNumber-1; i++)
            {
                var backButtonLocation = _backButton.GetElement().Location;
                var replyButtonLocation = ReplyButton.GetElement().Location;     
                AqualityServices.TouchActions.SwipeWithLongPress(replyButtonLocation, backButtonLocation);
            }
        }
    }
}
