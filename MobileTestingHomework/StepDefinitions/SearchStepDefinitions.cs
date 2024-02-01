using MobileTestingHomework.Screens.SearchTab;
using NUnit.Framework;

namespace MobileTestingHomework.StepDefinitions
{
    [Binding]
    internal class SearchStepDefinitions
    {
        private const string AUTHOR_NAME_KEY = "AUTHOR_NAME_KEY";
        private readonly ScenarioContext _scenarioContext;
        private readonly PostsScreen _postsScreen = new();


        public SearchStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }


        [Then(@"Posts screen is opened")]
        public void VerifySearchScreenIsOpened()
        {
            Assert.That(_postsScreen.State.WaitForDisplayed(), "Posts screen is not opened");
        }

        [When(@"Open the first post")]
        public void OpenFirstPost()
        {
            string firstPostAuthorName = _postsScreen.GetAuthorName();
            _scenarioContext.Add(AUTHOR_NAME_KEY, firstPostAuthorName);
            _postsScreen.OpenFirstPost();
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
