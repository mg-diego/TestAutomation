@iThemba
@AfterScenarioWithGoToBloodResults
Feature: ImportResults
	As a user I want to have users with imported results

@BeforeScenarioWithResetApp
Scenario: As a user with an unique imported results I can see First Login Screen
	Given The user 'UserWithSingleImportResults' login in the iThemba app
	And The user opens the iThemba app menu
	When The user opens the Blood Results menu option
	Then The Scan the first Barcode page is opened

@BeforeScenarioWithResetApp
Scenario: As a user I can see only the non imported results
	Given The user 'UserWithMultipleImportResults' login in the iThemba app
	And The user opens the iThemba app menu
	When The user opens the Blood Results menu option
	Then The 'UserWithMultipleImportResults' Blood Results page is opened

@BeforeScenarioWithResetApp
Scenario: As a user I can see at past results my imported results without barcode
	Given The user 'UserWithMultipleImportResults' login in the iThemba app
	When The user opens the Past Results menu option
	Then The user 'UserWithMultipleImportResults' Past Results page is opened
