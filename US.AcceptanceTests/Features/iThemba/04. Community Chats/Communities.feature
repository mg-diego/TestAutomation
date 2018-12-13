@iThemba

@AfterScenarioWithGoToBloodResults

@Story:Communities

Feature: Communities
	As a user i want to be able to connect easily with the community once I open the application.
	I want to see a list of different communities and be able to join them with a click of a button


@BeforeScenarioWithUniqueLogin
@AfterScenarioWithGoToBloodResults
Scenario: User can open the Chat with Communities menu option
	Given The user opens the iThemba app menu
	When The user opens the Community Chats menu option
	Then The Chat with Communities is opened


@BeforeScenarioWithUniqueLogin
Scenario: As a user I can navigate back using the Android native BACK button
	Given The user opens the iThemba app menu
	And The user opens the Community Chats menu option
	When The user clicks on Android back button
	Then The Blood Results is opened

@BeforeScenarioWithResetApp
Scenario Outline: As a user I can see my correct WhatsApp groups by gender / location
	Given The user '<user>' login in the iThemba app
	And The user opens the iThemba app menu
	When The user opens the Community Chats menu option
	Then The user '<user>' can see the groups for gender '<gender>' and location '<location>'

	Examples: 
	| user			  | gender   | location |
	| ResultsOnTheWay | Male     | Hillbrow | 
	| User49		  | Female   | Hillbrow |
	| User1001		  | Male	 | Yeoville | 
	| NoResult		  | Female   | Yeoville | 


@BeforeScenarioWithUniqueLogin
@AfterScenarioWithGoToBloodResults
Scenario: User can join a Community Chat
	Given The user opens the iThemba app menu
	And The user opens the Community Chats menu option
	When The user clicks in join a Community
	Then The user is redirect to whatsapp Community Chat
