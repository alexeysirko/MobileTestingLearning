using Aquality.Appium.Mobile.Applications;
using Aquality.Appium.Mobile.Screens;
using Aquality.Appium.Mobile.Screens.ScreenFactory;
using OpenQA.Selenium;

namespace MobileTestingHomework.Screens
{
    [ScreenType(PlatformName.Android)]
    internal class WelcomeScreen : Screen
    {
        public WelcomeScreen() : base(By.Id("org.joinmastodon.android:id/btn_log_in"), "Welcome Screen")
        {
        }
    }
}
