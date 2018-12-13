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


@BeforeScenarioWithResetApp
Scenario Outline: About iThemba contact info is correct for all the clinics
	Given The user '<user>' login in the iThemba app
	And The user opens the iThemba app menu
	When The user opens the About iThemba menu option
	Then The '<clinic>' About iThemba contact info is correct

Examples: 
	| clinic	 | user		|
	| Yeoville	 | User1001 |
	| Hillbrow   | User49	|


@BeforeScenarioWithUniqueLogin
@AfterScenarioWithGoToBloodResults
Scenario: User can open Whatsapp link at About iThemba
	Given The user opens the iThemba app menu
	And The user opens the About iThemba menu option
	When The user clicks in Whatsapp Link
	Then The user is redirect to whatsapp contact phone

