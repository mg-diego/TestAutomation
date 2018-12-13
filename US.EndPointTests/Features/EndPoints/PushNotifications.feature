Feature: Push Notifications



Scenario: Registration codes
	Given a successful login
	When request to registration codes is called
	Then The status code is '200'

Scenario: testing rabbit
	When request to rabbit a new 'XQAP2385B' message



