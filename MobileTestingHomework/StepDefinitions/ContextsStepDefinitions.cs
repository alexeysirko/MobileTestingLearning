using Aquality.Appium.Mobile.Applications;

namespace MobileTestingHomework.StepDefinitions
{
    [Binding]
    internal class ContextsStepDefinitions : BaseStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;

        public ContextsStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }


        [Given(@"Get the current context")]
        public void GetCurrentContext()
        {
            string currentContext = AqualityServices.Application.Driver.Context;
            AqualityServices.Logger.Info($"Current context is: {currentContext}");
        }

        [When(@"Check if there are other contexts")]
        public void CheckContexts()
        {
            IReadOnlyCollection<string> contexts = AqualityServices.Application.Driver.Contexts;
            _scenarioContext.Add(CONTEXTS_KEY, contexts);
        }

        [When(@"If those contexts are there, switch to them")]
        public void SwitchContexts()
        {
            var contexts = _scenarioContext.Get<IReadOnlyCollection<string>>(CONTEXTS_KEY);
            foreach(string context in contexts)
            {
                AqualityServices.Application.Driver.Context = context;
            }
        }
    }
}
