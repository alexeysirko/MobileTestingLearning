using MobileTestingHomework.Screens;

namespace MobileTestingHomework.StepDefinitions
{
    [Binding]
    public class LogInStepDefinitions
    {
        private const string SERVER_URL = "mastodon.social";
        private readonly WelcomeScreen _welcomeScreen = new();
        private readonly LogInScreen _logInScreen = new();

        [When(@"I log in the app")]
        public void LogInMastadon()
        {
            _welcomeScreen.ClickLoginButton();

            _logInScreen.TypeServerUrl(SERVER_URL);
            _logInScreen.ClickFirstServerRadioButton();
            _logInScreen.ClickNextButton();


        }
    }
}
