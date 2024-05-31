using Aquality.Appium.Mobile.Applications;
using MobileTestingHomework.Resources;
using MobileTestingHomework.Screens;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Enums;

namespace MobileTestingHomework.StepDefinitions
{
    [Binding]
    public class MastadonAppStepDefinitions
    {
        private readonly WelcomeScreen _welcomeScreen = new();

        [Given(@"Open Mastadon application")]
        [When(@"Open Mastadon application")]
        public void OpenMastadonApp()
        {
            AqualityServices.Application.Driver.ActivateApp(MastadonConstants.APP_ID);
        }

        [When(@"Close Mastadon application")]
        public void WhenICloseMastadonApplication()
        {
            AqualityServices.Application.Driver.TerminateApp(MastadonConstants.APP_ID);
        }


        [Then(@"Welcome screen is opened")]
        public void VerifyWelcomeScreenIsOpened()
        {
            Assert.That(_welcomeScreen.State.WaitForDisplayed(), "Welcome Screen is not opened");
        }

        [Then(@"Mastadon application is closed")]
        public void VerifyWelcomeScreenIsClosed()
        {
            var appState = AqualityServices.Application.Driver.GetAppState(MastadonConstants.APP_ID);
            Assert.That(appState, Is.EqualTo(AppState.NotRunning), "Mastadon is not closed");
        }
    }
}
