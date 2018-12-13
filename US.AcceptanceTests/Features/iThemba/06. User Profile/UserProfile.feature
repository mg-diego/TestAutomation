@iThemba
@AfterScenarioWithGoToBloodResults

Feature: Settings
    As a user i want to be able to open the settings menu

@Story:Settings


@BeforeScenarioWithUniqueLogin
Scenario: As a user I can open the My Profile menu option 
	Given The user opens the iThemba app menu
	And The user opens the My Profile menu option
	Then The My Profile menu is opened

@BeforeScenarioWithUniqueLogin
Scenario: As a user I can return to Blood result Page 
	Given The user opens the iThemba app menu
	And The user opens the My Profile menu option
	When The user clicks on Android back button
	Then The Blood Results is opened

@BeforeScenarioWithUniqueLogin
Scenario: As a user I can navigate through My Profile
	Given The user opens the iThemba app menu
	And The user opens the My Profile menu option
	When The user clicks Next button at demograph info page
	When The user clicks Done button at clinic info page
	Then The Blood Results is opened

@BeforeScenarioWithUniqueLogin
Scenario: As a user I can navigate back at My Profile
	Given The user opens the iThemba app menu
	And The user opens the My Profile menu option
	When The user clicks Next button at demograph info page
	And The user clicks Previous button at clinic info page
	Then The user is at Demographic info page at My Profile


@BeforeScenarioWithResetApp
Scenario Outline: As a user I can see my correct information at My Profile
    Given The user '<user>' login in the iThemba app
	And The user opens the iThemba app menu
	When The user opens the My Profile menu option
	Then The <user> see his correct information at My Profile

	Examples: 
	| user     |
	| User49   |
	| User1000 |