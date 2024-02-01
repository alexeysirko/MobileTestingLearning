using MobileTestingHomework.Screens;
using NUnit.Framework;

namespace MobileTestingHomework.StepDefinitions
{
    [Binding]
    internal class SearchStepDefinitions
    {
        private readonly SearchScreen _searchScreen = new();

        [Then(@"Posts screen is opened")]
        public void VerifySearchScreenIsOpened()
        {
            Assert.That(_searchScreen.IsPostsScreenOpened(), "Posts screen is not opened");
        }
    }
}
