using Aquality.Appium.Mobile.Screens;

namespace MobileTestingHomework.Screens
{
    internal class HomeScreen : Screen
    {
        private readonly static By s_homeLabelXpath = By.XPath("//android.widget.TextView[@text='Home']");

        public HomeScreen() : base(s_homeLabelXpath, "Home")
        {
        }


    }
}
