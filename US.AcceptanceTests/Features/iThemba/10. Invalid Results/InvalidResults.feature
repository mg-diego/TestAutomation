@iThemba
@AfterScenarioWithGoToBloodResults
Feature: InvalidResults


@BeforeScenarioWithResetApp
Scenario: As a user with an unique result with invalid status I can show my Barcode
	Given The user 'UserWithSingleInvalidResults' login in the iThemba app
	When The 'UserWithSingleInvalidResults' Blood Results page is opened
	And The user clicks in Show Barcode
	Then The user 'UserWithSingleInvalidResults' barcode is opened
	And The user clicks in Close Barcode

@BeforeScenarioWithResetApp
Scenario: As a user I can see only valid results at Past Results
	Given The user 'UserWithMultipleInvalidResults' login in the iThemba app
	And The 'UserWithMultipleInvalidResults' Blood Results page is opened
	When The user opens the Past Results menu option
	Then The user 'UserWithMultipleInvalidResults' Past Results page is opened