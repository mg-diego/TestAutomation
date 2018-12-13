Feature: NoConnectivity

@BeforeScenarioWithResetApp
Scenario: As a user that loses connection after input the phone number
	Given The user opens the iThemba app
	And The user 'User49' enters his phone number
	And The user click in send phone number
	When The user loses Connectivity
	Then The user can see the No connection to network message
	And The user recovers Connectivity
	And The user click in Try Again
	And The user is at Onboarding page


@BeforeScenarioWithResetApp
Scenario: As a user that loses connection after input the SMS code
	Given The user opens the iThemba app
	And The user 'User49' enters his phone number
	And The user click in send phone number
	And The user is at Enter SMS confirmation code
	When The user loses Connectivity
	Then The user can see the No connection to network message
	And The user recovers Connectivity
	And The user click in Try Again
	And The user is at Onboarding page

@BeforeScenarioWithCleanUser
Scenario: As a user that loses connection after input gender/age
	Given The user opens the iThemba app
	And The new user 'NewUser' completes the SMS authentication process
	When The user loses Connectivity
	Then The user can see the No connection to network message
	And The user recovers Connectivity
	And The user click in Try Again
	And The user is at Onboarding page

@BeforeScenarioWithCleanUser
Scenario: As a user that loses connection after input clinic location
	Given The user opens the iThemba app
	And The new user 'NewUser' completes the SMS authentication process
	And The user sets it's profile info
	When The user loses Connectivity
	Then The user can see the No connection to network message
	And The user recovers Connectivity
	And The user click in Try Again
	And The user is at Onboarding page

@BeforeScenarioWithResetApp
@AfterScenarioWithGoToBloodResultsWithNetwork
Scenario: As a user that loses connection after open Past Results
	Given The user 'User1001' login in the iThemba app	
	And The user opens the Past Results menu option
	When The user loses Connectivity
	Then The user can see the No connection to network message
	And The user recovers Connectivity
	And The user click in Try Again
	And The 'User1001' Blood Results page is opened


@BeforeScenarioWithUniqueLogin
@AfterScenarioWithGoToBloodResultsWithNetwork
Scenario: As a user that loses connection after open Blood Results 
    When The user loses Connectivity
	Then The user can see the No connection to network message
	And The user recovers Connectivity
	And The user click in Try Again
	And The Blood Results is opened


@BeforeScenarioWithUniqueLogin
@AfterScenarioWithGoToBloodResultsWithNetwork
Scenario: As a user that loses connection after open Barcode Scanner 	
	Given The user opens the iThemba app menu
	And The user opens Barcode Scan menu option
	When The user loses Connectivity
	Then The user can see the No connection to network message
	And The user recovers Connectivity
	And The user click in Try Again
	And The Blood Results is opened


@BeforeScenarioWithUniqueLogin
@AfterScenarioWithGoToBloodResultsWithNetwork
Scenario: As a user that loses connection after open Community Chats
    Given The user opens the iThemba app menu
	And The user opens the Community Chats menu option
	When The user loses Connectivity
	Then The user can see the No connection to network message
	And The user recovers Connectivity
	And The user click in Try Again
	And The Blood Results is opened


@BeforeScenarioWithUniqueLogin
@AfterScenarioWithGoToBloodResultsWithNetwork
Scenario: As a user that loses connection after open About iThemba    
	Given The user opens the iThemba app menu
	And The user opens the About iThemba menu option
	When The user loses Connectivity
	Then The user can see the No connection to network message
	And The user recovers Connectivity
	And The user click in Try Again
	And The Blood Results is opened


@BeforeScenarioWithUniqueLogin
@AfterScenarioWithGoToBloodResultsWithNetwork
Scenario: As a user that loses connection after open My Profile Demographic	
	Given The user opens the iThemba app menu
	And The user opens the My Profile menu option
	When The user loses Connectivity
	Then The user can see the No connection to network message
	And The user recovers Connectivity
	And The user click in Try Again
	And The Blood Results is opened


@BeforeScenarioWithUniqueLogin
@AfterScenarioWithGoToBloodResultsWithNetwork
Scenario: As a user that loses connection after open My Profile Clinic Location
	Given The user opens the iThemba app menu
	And The user opens the My Profile menu option	
	And The user clicks Next button at demograph info page
	When The user loses Connectivity
	Then The user can see the No connection to network message
	And The user recovers Connectivity
	And The user click in Try Again
	And The Blood Results is opened



