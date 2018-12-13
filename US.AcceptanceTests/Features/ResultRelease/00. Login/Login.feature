@ResultRelease
@AfterscenarioWithResetBrowser
Feature: Login


Scenario: As a user with valid credentials I can Login into the ResultRelease
	Given The user clicks in the Login button
	When The user 'doctor' enter his credentials
	Then The Result Release page is opened

Scenario: As a user with invalid credentials I can't Login into the ResultRelease
	Given The user clicks in the Login button
	When The user 'invalid' enter his credentials
	Then The invalid credentials message appears and user can't login

Scenario: As a user I can logout from Result Release
	Given The user 'doctor' login in the Result Release
	When The user clicks in Logout
	Then The user is at login page