@iThemba
@BeforeScenarioWithResetApp
@Story:Onboard


Feature: MainPage
	In order to explain the users the iThemba app
	As a PLWH when launching the app for the first time 
	I want to know why and how I should use it


Scenario: A user that launches the app for the first time receives info about how to use it
	When The user opens the iThemba app for the first time
	Then The user can see the info about how to use the app

Scenario: A user that does not launch the app for the first time does not receive info about how to use it
	When The user opens the iThemba app for the second time
	Then The user can see the Sign-up screen