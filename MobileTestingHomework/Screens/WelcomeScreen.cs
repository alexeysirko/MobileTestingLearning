using Aquality.Appium.Mobile.Applications;
using Aquality.Appium.Mobile.Elements.Interfaces;
using Aquality.Appium.Mobile.Screens;
using Aquality.Appium.Mobile.Screens.ScreenFactory;

namespace MobileTestingHomework.Screens
{
    [ScreenType(PlatformName.Android)]
    internal class WelcomeScreen : Screen
    {
        private readonly static By s_loginBtnXpath = By.Id("org.joinmastodon.android:id/btn_log_in");
        private readonly IButton _loginBtn = ElementFactory.GetButton(s_loginBtnXpath, "Log in");


        public WelcomeScreen() : base(s_loginBtnXpath, "Welcome Screen")
        {
        }


        public void ClickLoginButton()
        {
            _loginBtn.Click();
        }
    }
}
