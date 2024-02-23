using MobileTestingHomework.Screens.SearchTab;
using NUnit.Framework;

namespace MobileTestingHomework.StepDefinitions
{
    [Binding]
    internal class PostsStepDefinitions : BaseStepDefinitions
    {      
        private readonly ScenarioContext _scenarioContext;
        private readonly PostsScreen _postsScreen = new();
        private readonly SearchScreen _searchScreen = new();


        public PostsStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }


        [When(@"Open the first post")]
        public void OpenFirstPost()
        {
            string firstPostAuthorName = _postsScreen.GetAuthorName();
            _scenarioContext.Add(AUTHOR_NAME_KEY, firstPostAuthorName);
            _postsScreen.OpenFirstPost();
        }

        [When(@"Scroll down to the '(.*)' post")]
        public void ScrollDownToThePostByNumber(int postNumber)
        {
            _postsScreen.ScrollToPostByNumber(postNumber);
        }

        [Then(@"Post screen with provided # is opened")]
        public void PostWithHashtagIsOpened()
        {
            var expectedHashtagTitle = _scenarioContext.Get<string>(SEARCH_INPUT_TEXT_KEY);
            string actualHashtagTitle = _postsScreen.GetHashtagTitle();
            Assert.That(actualHashtagTitle, Does.Contain(expectedHashtagTitle), "Post screen with provided # is not opened");
        }

        [Then(@"Posts screen is opened")]
        public void VerifySearchScreenIsOpened()
        {
            Assert.That(_postsScreen.State.WaitForDisplayed(), "Posts screen is not opened");
        }

        [Then(@"Posts have the Displayed state")]
        public void PostsHaveDisplayedState()
        {
            _searchScreen.ArePostsDisplayed();
        }

        [Then(@"The first post is opened")]
        public void VerifyFirstPostIsOpened()
        {
            string? authorNameFromList = _scenarioContext.GetValueOrDefault(AUTHOR_NAME_KEY) as string;
            string openedAuthorName = _postsScreen.GetPostFromAuthorName();
            Assert.That(openedAuthorName, Does.Contain(authorNameFromList), "The first post from list is not opened");
        }
    }
}
