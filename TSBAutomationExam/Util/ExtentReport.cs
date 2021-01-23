using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using TSBAutomationExam.Util;

namespace TSBAutomationExam.Pages
{
    [Binding]
    public class ExtentReport
    {
        private static ExtentTest featureName;
        private static ExtentTest scenario;
        private static ExtentReports extent;


        [BeforeScenario(Order = 3)]
        public void InitializeScenario(ScenarioContext scenarioContext)
        {
            scenario = featureName.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
            //Console.WriteLine($"\n\nScenario Name: {scenarioContext.ScenarioInfo.Title}");
            //Console.WriteLine();
        }


        [BeforeTestRun]
        public static void InitializeReport()
        {
            var htmlReporter = new ExtentV3HtmlReporter(Utilities.TestResultFolder + "ExtentReport.html");
            htmlReporter.Config.Theme = Theme.Dark;
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            featureName = extent.CreateTest<Feature>(featureContext.FeatureInfo.Title);
            //Console.WriteLine($"\n\nFeature Name: {featureContext.FeatureInfo.Title}");
            //Console.WriteLine();
        }


        [AfterStep]
        public void InsertReportingSteps(ScenarioContext scenarioContext)
        {
            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();

            if (scenarioContext.TestError == null)
            {
                scenario.CreateNode(new GherkinKeyword(stepType), ScenarioStepContext.Current.StepInfo.Text);
            }
            else
            {
                scenario.CreateNode(new GherkinKeyword(stepType), ScenarioStepContext.Current.StepInfo.Text).Fail($"Step Failed: {scenarioContext.TestError.Message}");
            }
        }

        [AfterTestRun(Order = 1)]
        public static void extentFlush()
        {
            extent.Flush();
        }
    }
}
