using MobileTestingHomework.Screens;
using NUnit.Framework;

namespace MobileTestingHomework.StepDefinitions
{
    [Binding]
    internal class HomeStepDefinitions
    {
        private HomeScreen _homeScreen = new();

        [Then(@"Home screen is opened")]
        public void VerifyHomeScreenIsOpened()
        {
            Assert.That(_homeScreen.State.WaitForDisplayed(), "Home page is not opened");
        }
    }
}
