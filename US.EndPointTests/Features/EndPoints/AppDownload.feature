Feature: AppDownload


Scenario: POST - Valid code
	Given a successful login
	When request to post valid code
	Then the response does not contain the code entered is wrong

Scenario: POST - Invalid code
	Given a successful login
	When request to post invalid code
	Then the response contains the code entered is wrong
