@iThemba
@BeforeScenarioWithResetApp

@Story:Login

Feature: Login
	As a PLWH I want to log in with my phone and clearly know how it works so I can see my results quickly


Scenario: User can receive SMS authentication code
    Given The user opens the iThemba app
	And The user 'User49' enters his phone number
	When The user click in send phone number
    Then The user 'User49' receives the confirmation code

Scenario: User can login setting all profile info
    Given The user opens the iThemba app
	And The user 'User49' completes the SMS authentication process
	When The user sets it's profile info
	And The user sets it's location info
    Then The user 'User49' can complete the login

Scenario: User can't login setting only gender age info
    Given The user opens the iThemba app
	And The user 'User49' completes the SMS authentication process
	When The user sets it's profile info
	And The user skips it's location info
    Then The user 'User49' can complete the login

Scenario: User can login setting only clinic location info
    Given The user opens the iThemba app
	And The user 'User49' completes the SMS authentication process
	When The user skips it's profile info
	And The user sets it's location info
    Then The user 'User49' can complete the login

Scenario: User can logout from the application 
    Given The user 'User49' login in the iThemba app
	And The user opens the iThemba app menu
	When The user clicks the Logout menu option
    Then The user can logout from the application

Scenario: User can request a second confirmation code  
	Given The user opens the iThemba app
	And The user 'User49' enters his phone number
	And The user click in send phone number
	When The user click in send code again
	Then The user 'User49' receives the confirmation code

Scenario: User can go back after he introduced a phone number
	Given The user opens the iThemba app
	And The user 'User49' enters his phone number
	And The user click in send phone number
	When The user click in back button on code confirmation screen
	Then The user can see the Sign-up screen 

Scenario: User can exit from the application 
	Given The user opens the iThemba app 
	When The user click in the exit button
	Then The application is closed

@AfterScenarioWithEnablingNetwork
Scenario: As a user with no Network I can see the No connection to Network message
    Given The user opens the iThemba app
	And The user 'User49' enters his phone number
	And The user click in send phone number
	When The user 'User49' receives the confirmation code and loses Network after login 
	Then The user can see the No connection to network message

Scenario: As a user I can exit from the application using Android native BACK button
	Given The user 'User49' login in the iThemba app
	And The user opens the iThemba app menu
	And The user opens the Blood Results menu option
	And The user clicks on Android back button
	When The user clicks in YES, EXIT button
	Then The application is closed

