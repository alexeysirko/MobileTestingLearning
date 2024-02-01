using Aquality.Appium.Mobile.Applications;
using MobileTestingHomework.Resources;

namespace MobileTestingHomework.Hooks
{
    [Binding]
    internal class Hooks
    {
        [AfterScenario]
        public static void AfterFeature(FeatureContext featureContext)
        {
            if(AqualityServices.IsApplicationStarted)
            {
                AqualityServices.Application.Driver.TerminateApp(MastadonConstants.APP_ID);
            }
            AqualityServices.Application.Quit();
        }
    }
}
