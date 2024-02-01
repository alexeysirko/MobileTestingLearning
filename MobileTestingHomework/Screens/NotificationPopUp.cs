using Aquality.Appium.Mobile.Applications;
using Aquality.Appium.Mobile.Elements.Interfaces;
using Aquality.Appium.Mobile.Screens;
using Aquality.Appium.Mobile.Screens.ScreenFactory;

namespace MobileTestingHomework.Screens
{
    [ScreenType(PlatformName.Android)]
    internal class NotificationPopUp : Screen
    {
        private readonly static By s_allowBtnXpath = By.Id("com.android.permissioncontroller:id/permission_allow_button");
        private readonly IButton allowNotificationsBtn = ElementFactory.GetButton(s_allowBtnXpath, "Allow");


        public NotificationPopUp() : base(s_allowBtnXpath, "Notification")
        {
        }

        public void ClickAllowButton()
        {
            allowNotificationsBtn.Click();
        }
    }
}
