Feature: IdentityServer - Profile


Scenario: GET - Get valid profile
	Given a successful login
	When request to get profile
	Then The response contains the profile info of the user

Scenario: GET - Get invalid profile
	Given an invalid login
	When request to get profile
	Then The status code is '401'

Scenario: GET - Get no scim profile
	Given the user noScim login
	When request to get profile
	Then response contains the result 'no_scim_id'
