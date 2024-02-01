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
        private readonly NotificationPopUp _notificationScreen = new();

        [When(@"Log in the app")]
        public void LogInMastadon()
        {
            _welcomeScreen.ClickLoginButton();

            _logInScreen.TypeServerUrl(SERVER_URL);
            _logInScreen.ClickFirstServerRadioButton();
            _logInScreen.ClickNextButton();
            _logInScreen.ClickAuthorizeBtn();

            if (_notificationScreen.State.WaitForDisplayed(TimeSpan.FromSeconds(5)))
            {
                _notificationScreen.ClickAllowButton();
            }
        }
    }
}
