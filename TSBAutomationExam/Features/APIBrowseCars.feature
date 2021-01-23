Feature: [API]BrowseCars
	This is to verify the following tests on browsing cars thru API in the TradeMe website

@API
Scenario: Check there is atleast one listing in the TradeMe UsedCars Category
	Given I create an <Endpoint> client connection
	And I add an <AuthType> type Authenticator
	When I set the <MethodType> type of the request
	And I execute the request
	Then I can check if there is atleast one listing in the TradeMe UsedCars category

Examples: 
| Endpoint                                               | AuthType | MethodType |
| https://api.tmsandbox.co.nz/v1/Search/Motors/Used.json | OAuth    | GET        |


@API
Scenario: Check that the make ‘Kia’ exists
	Given I create an <Endpoint> client connection
	When I set the <MethodType> type of the request
	And I execute the request
	Then I can see the Make <Make> exists

Examples: 
| Endpoint                                              | MethodType | Make |
| https://api.trademe.co.nz/v1/Categories/UsedCars.json | GET        | Kia  |


@API
Scenario: Check if the Car Details is displayed in the Used Car Listing
	Given I create an <Endpoint> client connection
	And I add an <AuthType> type Authenticator
	When I set the <MethodType> type of the request
	And I execute the request
	Then I can see the Car <Year> <Make> <Model> Details is correct

Examples: 
| Endpoint                                               | AuthType | MethodType | Year | Make | Model |
| https://api.tmsandbox.co.nz/v1/Search/Motors/Used.json | OAuth    | GET        | 1998 | BMW  | 328i  |