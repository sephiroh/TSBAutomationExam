using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using TSBAutomationExam.API;
using TSBAutomationExam.DataObjects;
using TSBAutomationExam.Util;

namespace TSBAutomationExam.StepDefinitions
{
    [Scope(Tag = "API")]
    [Binding]
    public class APIBrowseCarsSteps
    {
        public TradeMeAPI tradeMeAPI = new TradeMeAPI();

        [Given(@"I create an (.*) client connection")]
        public void GivenICreateAClientConnection(string endpoint)
        {
            tradeMeAPI.CreateClientConnection(endpoint);
        }


        [Given(@"I add an (.*) type Authenticator")]
        public void GivenIAddAnTypeAuthenticator(string authType)
        {
            tradeMeAPI.AddHeaderAuthenticator(authType);
        }

        [When(@"I set the (.*) type of the request")]
        public void WhenISetTheTypeOfTheRequest(string method)
        {
            tradeMeAPI.SetTypeOfMethod(method);

        }

        [When(@"I execute the request")]
        public void WhenIExecuteTheRequest()
        {
            tradeMeAPI.ExecuteRequest();
        }

        [Then(@"I can check if there is atleast one listing in the TradeMe UsedCars category")]
        public void ThenICanCheckIfThereIsAtleastOneListingInTheTradeMeUsedCarsCategory()
        {
            tradeMeAPI.IsThereAListingDisplayed();
        }

        [Then(@"I can see the Make (.*) exists")]
        public void ThenICanSeeTheMakeExists(string make)
        {
            tradeMeAPI.IsCarMakeDisplayed(make);
        }

        [Then(@"I can see the Car (.*) (.*) (.*) Details is correct")]
        public void ThenICanSeeTheCarDetailsIsCorrect(string year, string make, string model)
        {
            string carName = $"{year} {make} {model}";
            CarDO carDetails = Utilities.GetCarDetails(carName);
            tradeMeAPI.IsCarDetailsCorrect(carDetails);
        }

    }
}
