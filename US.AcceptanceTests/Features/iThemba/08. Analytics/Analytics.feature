@iThemba

@AfterScenarioWithGoToBloodResults

@Story:Analytics

Feature: Analytics


@BeforeScenarioWithResetApp
Scenario: As a user that login for the 3rd time I see a survey 
	Given The user opens the iThemba app 
	When The user 'User49' login for the 3rd time
	Then The 3rd login survey appears for the user 'User49'


@BeforeScenarioWithUniqueLogin
Scenario: When the camera is opened more than 3m then timeout appears
	Given The user opens the iThemba app menu
	And The user opens Barcode Scan menu option
	When The camera timeout expires after 3 minutes
	Then Then Barcode Scan timeout message appears


@BeforeScenarioWithResetApp
Scenario: User failed login attempts are saved in database
    Given The user opens the iThemba app
	When The user 'User49' completes the SMS authentication process with failed attempts
	Then FailedLoginAttempts analytic is saved at Database


@BeforeScenarioWithUniqueLogin
Scenario: User can join a Community from the list
	Given The user opens the iThemba app menu
	And The user opens the Community Chats menu option
	When The user clicks in join a Community
	Then The user is redirect to whatsapp Community Chat