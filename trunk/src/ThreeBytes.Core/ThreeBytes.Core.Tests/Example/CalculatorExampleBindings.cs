using NUnit.Framework;
using TechTalk.SpecFlow;

namespace ThreeBytes.Core.Tests.Example
{
    [Binding]
    public class CalculatorExampleBindings
    {
        private CalculatorExample calculatorExample = new CalculatorExample();
        private int addOperationResult;

        [Given(@"I have entered (50|70) into the calculator")]
        public void GivenIHaveFilledOutTheFormAsFollows(string value)
        {
            switch (value)
            {
                case "50":
                    ScenarioContext.Current["arg1"] = int.Parse(value);
                    break;
                case "70":
                    ScenarioContext.Current["arg2"] = int.Parse(value);
                    break;
            }
        }

        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            addOperationResult = calculatorExample.Add((int)ScenarioContext.Current["arg1"], (int)ScenarioContext.Current["arg2"]);
        }

        [Then(@"the result should be 120 on the screen")]
        public void ThenISee120OnTheScreen()
        {
            Assert.That(addOperationResult, Is.EqualTo(120));
        }
    }
}
