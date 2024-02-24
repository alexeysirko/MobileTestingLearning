using MobileTestingHomework.Screens.SearchTab;

namespace MobileTestingHomework.StepDefinitions
{
    [Binding]
    internal class TabBarStepDefinitions
    {
        private readonly TabBar _tabBar = new();

        [When(@"Tap '(.*)' tab")]
        public void SwitchTab(string tabName)
        {
            _tabBar.ClickTabButtonByIdPart(tabName);
        }
    }
}
