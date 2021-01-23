Feature: [UI]BrowseCars
	This is to verify the following tests on browsing cars thru UI in the TradeMe website

@UI
Scenario: Check there is atleast one listing in the TradeMe UsedCars Category
	Given I navigated to the TradeMe website
	When I browse thru the Motors page
	And I look for Used Cars
	Then I can see there is at least one listing display


@UI
Scenario: Check that the make ‘Kia’ exists
	Given I navigated to the TradeMe website
	When I browse thru the Motors page
	And I look for Used Cars
	Then I can see the Make <Make> exists

Examples: 
| Make |
| Kia  |


@UI
Scenario: Check if the Car Details is displayed in the Used Car Listing
	Given I navigated to the TradeMe website
	When I browse thru the Motors page
	And I look for Used Cars
	And I select the <Year> <Make> <Model> car from the listing
	Then I can see the Car <Year> <Make> <Model> Details is correct

Examples: 
| Year | Make | Model |
| 1998 | BMW  | 328i  |