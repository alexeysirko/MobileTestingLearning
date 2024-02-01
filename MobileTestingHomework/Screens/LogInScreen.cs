using Aquality.Appium.Mobile.Applications;
using Aquality.Appium.Mobile.Elements.Interfaces;
using Aquality.Appium.Mobile.Screens;
using Aquality.Appium.Mobile.Screens.ScreenFactory;


namespace MobileTestingHomework.Screens
{
    [ScreenType(PlatformName.Android)]
    internal class LogInScreen : Screen
    {
        private readonly static By s_serverUrlTxbXpath = By.Id("org.joinmastodon.android:id/search_edit");
        private readonly ITextBox _serverUrlTxb = ElementFactory.GetTextBox(s_serverUrlTxbXpath, "Server Url");

        private readonly IRadioButton _firstServersRadioBtn = ElementFactory.GetRadioButton(By.XPath("//android.widget.RadioButton[@resource-id='org.joinmastodon.android:id/radiobtn']"), "First server pick");
        private readonly IButton _nextBtn = ElementFactory.GetButton(By.Id("org.joinmastodon.android:id/btn_next"), "Next");
        private readonly IButton _authorizeBtn = ElementFactory.GetButton(By.XPath("//android.widget.Button[@text='Authorize']"), "Authorize");

        public LogInScreen() : base(s_serverUrlTxbXpath, "Log In")
        {
        }


        public void TypeServerUrl(string url)
        {
            _serverUrlTxb.Type(url);
        }
        public void ClickFirstServerRadioButton()
        {
            _firstServersRadioBtn.Click();
        }

        public void ClickNextButton()
        {
            _nextBtn.Click();
        }

        public void ClickAuthorizeBtn()
        {
            _authorizeBtn.Click();
        }
    }
}