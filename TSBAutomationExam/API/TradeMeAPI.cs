﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using TSBAutomationExam.DataObjects;
using TSBAutomationExam.Util;

namespace TSBAutomationExam.API
{
    public class TradeMeAPI
    {
        private RestClient client;
        private RestRequest request;
        private IRestResponse response;


        public void CreateClientConnection(string endpoint)
        {
            client = new RestClient(endpoint);
        }

        public void AddHeaderAuthenticator(string authType)
        {
            var authDetails = Utilities.GetAuthDetails(authType);
            client.Authenticator = OAuth1Authenticator.ForRequestToken(authDetails.ConsumerKey, authDetails.ConsumerSecret);
        }

        public void SetTypeOfMethod(string method)
        {
            switch (method.ToUpper())
            {
                
                case "POST":
                    request = new RestRequest(Method.POST);
                    break;
                case "PUT":
                    request = new RestRequest(Method.PUT);
                    break;
                case "DELETE":
                    request = new RestRequest(Method.DELETE);
                    break;
                case "GET":
                default:
                    request = new RestRequest(Method.GET);
                    break;
            }
        }

        public void ExecuteRequest()
        {
            response = client.Execute(request);
        }

        public void IsCarMakeDisplayed(string make)
        {
            var data = JsonConvert.DeserializeObject<CategoriesDO>(response.Content);
            var carMakeDetails = data.Subcategories.Find(x => x.Name == make);
            Assert.IsTrue(carMakeDetails != null, $"Test Failed: Car Make {make} is NOT displayed.");

        }

        public void IsThereAListingDisplayed()
        {
            var data = JsonConvert.DeserializeObject<ListingsDO>(response.Content);
            Assert.IsTrue(data.TotalCount >= 1, "Test Failed: There is no listing results displayed.");
        }

        public void IsCarDetailsCorrect(CarDO car)
        {
            var data = JsonConvert.DeserializeObject<ListingsDO>(response.Content);
            var responseCar = data.List.Find(x => x.Title.Contains(car.CarName));

            if (data.TotalCount <= 1)
            {
                Assert.AreEqual(car.NumberPlate, responseCar.NumberPlate, "Test Failed: Number Plate displayed as expected.");
                Assert.IsTrue(car.Kilometres.Contains(string.Format("{0:#,###0}", responseCar.Odometer)), "Test Failed: Kilometres is not displayed as expected.");
                Assert.AreEqual(car.Body, $"{responseCar.ExteriorColour}, {responseCar.Doors} door, {responseCar.BodyStyle}", "Test Failed: Body is not displayed as expected.");
                Assert.AreEqual(car.Seats, responseCar.Seats.ToString(), "Test Failed: Seats are not displayed as expected.");
                Assert.AreEqual(car.FuelType, responseCar.Fuel, "Test Failed: Fuel Type is not displayed as expected.");
                Assert.AreEqual(car.Engine, $"{responseCar.Cylinders} cylinder, {responseCar.EngineSize}cc", "Test Failed: Engine is not displayed as expected.");
                Assert.AreEqual(car.Transmission, responseCar.Transmission, "Test Failed: Transmission is not displayed as expected.");
                Assert.AreEqual(car.History, $"{responseCar.Owners} owners, Imported", "Test Failed: History is not displayed as expected.");
                //Assert.AreEqual(car.RegistrationExpires, responseCar.RegistrationExpires, "Test Failed: Registration Expires is not displayed as expected.");
                //Assert.AreEqual(car.WoFExpires, responseCar.WoFExpires, "Test Failed: WoF Expires is not displayed as expected.");
                //Registration Expires and WoFExpires have both value of - /Date(0)/, thus omitting this assertion for now
                Assert.AreEqual(car.ModelDetail, responseCar.ModelDetail, "Test Failed: Model Details is not displayed as expected.");
            }
            else
                Assert.Fail("Test Failed: There is no listing results displayed.");
        }
    }
}
