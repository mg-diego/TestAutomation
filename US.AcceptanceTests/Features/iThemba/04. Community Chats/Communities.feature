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
