using Aquality.Appium.Mobile.Applications;
using MobileTestingHomework.Screens;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Enums;

namespace MobileTestingHomework.StepDefinitions
{
    [Binding]
    public class MastadonAppStepDefinitions
    {
        private readonly WelcomeScreen _welcomeScreen = new();
        private const string APP_ID = "org.joinmastodon.android";

        [When(@"Open Mastadon application")]
        public void OpenMastadonApp()
        {
            AqualityServices.Application.Driver.ActivateApp(APP_ID);
        }

        [When(@"Close Mastadon application")]
        public void WhenICloseMastadonApplication()
        {
            AqualityServices.Application.Driver.TerminateApp(APP_ID);
        }


        [Then(@"Welcome screen is opened")]
        public void VerifyWelcomeScreenIsOpened()
        {           
            Assert.That(_welcomeScreen.State.WaitForDisplayed(), "Welcome Screen is not opened");
        }

        [Then(@"Mastadon application is closed")]
        public void VerifyWelcomeScreenIsClosed()
        {
            var appState = AqualityServices.Application.Driver.GetAppState(APP_ID);
            Assert.That(appState, Is.EqualTo(AppState.NotRunning), "Mastadon is not closed");
        }
    }
}
