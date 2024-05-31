using Aquality.Appium.Mobile.Actions;
using Aquality.Appium.Mobile.Applications;
using Aquality.Appium.Mobile.Elements.Interfaces;
using Aquality.Appium.Mobile.Screens;
using Aquality.Selenium.Core.Elements;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.MultiTouch;
using System.Drawing;
using static System.Net.Mime.MediaTypeNames;

namespace MobileTestingHomework.Screens.SearchTab
{
    internal class PostsScreen : Screen
    {
        private readonly ILabel _postFromLabel = ElementFactory.GetLabel(
            By.XPath("//*[@resource-id='org.joinmastodon.android:id/toolbar']//android.widget.TextView[contains(@text,'Post from')]")
            , "post from");    

        private readonly ILabel _firstPostHeader = ElementFactory.GetLabel(
            By.XPath("//*[@resource-id='org.joinmastodon.android:id/list']/android.widget.RelativeLayout[1]")
            , "First Post Header");

        private readonly ILabel _firstAuthorName = ElementFactory.GetLabel(By.Id("org.joinmastodon.android:id/name"), "First author Names");
        private readonly ILabel _hashtagTitle = ElementFactory.GetLabel(By.Id("org.joinmastodon.android:id/title"), "Hashtag title");
        private readonly IButton _backButton = ElementFactory.GetButton(By.XPath("//android.widget.ImageButton[@content-desc='Back']"), "Back");
        private readonly IButton _replyButton = ElementFactory.GetButton(By.Id("org.joinmastodon.android:id/reply_btn"), "Reply button");
        private readonly IButton _postsOption = ElementFactory.GetButton(By.XPath("//android.widget.LinearLayout[@content-desc='Posts']"), "Posts option");
        private List<ILabel> PostTexts => ElementFactory.FindElements<ILabel>(By.XPath("//*[@resource-id='org.joinmastodon.android:id/text']"), "Post texts").ToList();
        private ILabel PostByText(string text) => ElementFactory.GetLabel(By.XPath($"//*[@resource-id='org.joinmastodon.android:id/text' and @text='{text}']"), "postByText", ElementState.ExistsInAnyState);

        private Dictionary<string, int> _uniquePostTexts = new();

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

        public void ScrollToPostWithSwipe(int postNumber)
        {
            for (int i = 0; i < postNumber-1; i++)
            {
                _replyButton.TouchActions.SwipeWithLongPress(_backButton.GetElement().Location);
            }
        }

        public void ScrollToPostWithSwipeAtCoordinates(int postNumber)
        {
            //I tried everything to use scrollToElement in this step. But coudln't do anything. So I used Swipe in this step and scrollToElement in next step (switched steps)
            int countOfUniquePosts = 0;
            while (countOfUniquePosts < postNumber)
            {
                countOfUniquePosts = AddPostTextsAndGetAmountOfUniquePosts();
                _replyButton.TouchActions.SwipeWithLongPress(_postsOption.GetElement().Location);
            }
        }

        public void GoBackToPostWithScrollToElement(int postNumber)
        {
            string expectedText = _uniquePostTexts.ElementAt(postNumber - 1).Key;
            PostByText(expectedText).TouchActions.ScrollToElement(SwipeDirection.Up);
        }

        public void SwipeToPostUsingAppium(int postNumber)
        {
            int countOfUniquePosts = 0;
            while (countOfUniquePosts < postNumber)
            {
                countOfUniquePosts = AddPostTextsAndGetAmountOfUniquePosts();
                var xPostion = 1;
                var startYPosition = ScreenElement.GetElement().Location.Y + ScreenElement.GetElement().Size.Height- ScreenElement.GetElement().Size.Height * 0.1;
                var endYPosition = ScreenElement.GetElement().Location.Y + ScreenElement.GetElement().Size.Height * 0.1;
                new TouchAction(AqualityServices.Application.Driver)
                    .Press(xPostion, startYPosition)
                    .MoveTo(xPostion, endYPosition)
                    .Release()
                    .Perform();
            }
        }

        public bool IsPostDisplayed(int postNumber)
        {
            string expectedText = _uniquePostTexts.ElementAt(postNumber - 1).Key;
            return PostTexts.Any(post => post.Text == expectedText);
        }

        public int AddPostTextsAndGetAmountOfUniquePosts()
        {
            foreach(var postText in PostTexts)
            {
                _uniquePostTexts.TryAdd(postText.Text, 0);
            }
            return _uniquePostTexts.Count;
        }
    }
}
