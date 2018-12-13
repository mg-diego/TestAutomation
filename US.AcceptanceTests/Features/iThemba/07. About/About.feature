@iThemba
@AfterScenarioWithGoToBloodResults

@Story:About

Feature: About
	As a user I want to have info about the iThemba app

@BeforeScenarioWithUniqueLogin
@AfterScenarioWithGoToBloodResults
Scenario: User can open the About iThemba menu option
	Given The user opens the iThemba app menu
	When The user opens the About iThemba menu option
	Then The About iThemba menu is opened

@BeforeScenarioWithUniqueLogin
Scenario: About iThemba contact info is correct
	Given The user opens the iThemba app menu
	When The user opens the About iThemba menu option
	Then The About iThemba contact info is correct


