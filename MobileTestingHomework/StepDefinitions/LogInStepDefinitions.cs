using Aquality.Appium.Mobile.Applications;
using MobileTestingHomework.Screens;
using NUnit.Framework;

namespace MobileTestingHomework.StepDefinitions
{
    [Binding]
    public class LogInStepDefinitions
    {
        private const string SERVER_URL = "mastodon.social";
        private readonly WelcomeScreen _welcomeScreen = new();
        private readonly LogInScreen _logInScreen = new();
        private readonly NotificationScreen _notificationScreen = new();

        [When(@"I log in the app")]
        public void LogInMastadon()
        {
            _welcomeScreen.ClickLoginButton();

            _logInScreen.TypeServerUrl(SERVER_URL);
            _logInScreen.ClickFirstServerRadioButton();
            _logInScreen.ClickNextButton();
            _logInScreen.ClickAuthorizeBtn();


            Assert.That(AqualityServices.IsApplicationStarted); ;
            if (_notificationScreen.State.WaitForDisplayed(TimeSpan.FromSeconds(5)))
            {
                _notificationScreen.ClickAllowButton();
            }
        }
    }
}
