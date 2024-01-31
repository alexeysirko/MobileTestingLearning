using Aquality.Appium.Mobile.Applications;
using Aquality.Appium.Mobile.Elements.Interfaces;
using Aquality.Appium.Mobile.Screens;
using Aquality.Appium.Mobile.Screens.ScreenFactory;
using System.Runtime.ExceptionServices;


namespace MobileTestingHomework.Screens
{
    [ScreenType(PlatformName.Android)]
    internal class LogInScreen : Screen
    {
        private readonly static By s_serverUrlTxbXpath = By.Id("org.joinmastodon.android:id/search_edit");       
        private readonly ITextBox _serverUrlTxb = ElementFactory.GetTextBox(s_serverUrlTxbXpath, "Server Url");
        
        private readonly IEnumerable<IRadioButton> _serversRadioBtns = ElementFactory.FindElements<IRadioButton>(By.XPath("//android.widget.RadioButton[@resource-id='org.joinmastodon.android:id/radiobtn']"), "Servers picks");
        private readonly IButton _nextBtn = ElementFactory.GetButton(By.Id("org.joinmastodon.android:id/btn_next"), "Next");

        public LogInScreen() : base(s_serverUrlTxbXpath, "Log In")
        {
        }


        public void TypeServerUrl(string url)
        {
            _serverUrlTxb.Type(url);
        }
        public void ClickFirstServerRadioButton()
        {
            _serversRadioBtns.First().Click();
        }

        public void ClickNextButton()
        {
            _nextBtn.Click();
        }

    }
}