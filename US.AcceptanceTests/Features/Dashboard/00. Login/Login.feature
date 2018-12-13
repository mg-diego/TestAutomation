@Dashboard
@AfterscenarioWithResetBrowser
Feature: Login


Scenario: As a user with valid credentials I can Login into the Dashboard
	Given The user clicks in the Login button
	When The user 'doctor' enter his credentials
	Then The Dashboard page is opened

Scenario: As a user with invalid credentials I can't Login into the Dashboard
	Given The user clicks in the Login button
	When The user 'invalid' enter his credentials
	Then The invalid credentials message appears and user can't login

Scenario: As a user I can logout from the Dashboard
	Given The user 'doctor' login in the Dashboard
	When The user clicks in the Logout button
	Then The user is at login page


