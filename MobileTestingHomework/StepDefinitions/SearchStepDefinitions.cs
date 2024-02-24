using Aquality.Appium.Mobile.Applications;
using MobileTestingHomework.Screens.SearchTab;
using NUnit.Framework;
using OpenQA.Selenium.Appium.MultiTouch;
using System.Drawing;

namespace MobileTestingHomework.StepDefinitions
{
    [Binding]
    internal class SearchStepDefinitions : BaseStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly SearchScreen _searchScreen = new();


        public SearchStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }


        [When(@"Get the position of a search field")]
        public void GetSearchFieldPosition()
        {
            Point position = _searchScreen.GetSearchFieldPosition();
            _scenarioContext.Add(POSITION_KEY, position);
        }

        [When(@"Tap the search field by the position")]
        public void TabSearchFieldByPosition()
        {
            _scenarioContext.TryGetValue(POSITION_KEY, out Point elementLocation);
            // Using TouchAction class here because there is no Tap by location in Aquality TouchActions
            TouchAction action = new(AqualityServices.Application.Driver);
            action.Tap(elementLocation.X, elementLocation.Y).Perform();
        }

        [When(@"Open the Posts with # search results")]
        public void OpenPostsWithHashtag()
        {
            _searchScreen.ClickPostsWithHashtag();
        }

        [When(@"Enter '(.*)' to the search field")]
        public void EnterTextToSearchField(string text)
        {
            _scenarioContext.Add(SEARCH_INPUT_TEXT_KEY, text);
            _searchScreen.EnterTextToActiveSearchField(text);
        }

        [Then(@"Search field doesn't have the '(.*)':'(.*)' position value")]
        public void CheckSearchFieldPosition(int notExpectedX, int notExpectedY)
        {
            _scenarioContext.TryGetValue(POSITION_KEY, out Point actualLocation);
            Assert.Multiple(() =>
            {
                Assert.That(notExpectedX, Is.Not.EqualTo(actualLocation.X), "Search field X position value is equal to expected");
                Assert.That(notExpectedY, Is.Not.EqualTo(actualLocation.Y), "Search field Y position value is equal to expected");
            });
        }

        [Then(@"Search result is not empty")]
        public void IsNotEmptySearchResult()
        {
            Assert.That(_searchScreen.IsNotEmptySearchResult(), "Search result is empty");
        }
    }
}
