Feature: Reports


Scenario: As a user I can open the Reports tab
	Given The user 'doctor' login in the Dashboard
	When The user clicks in the Reports button
	Then The Reports tab is opened

Scenario: As a user I search for CAPCTM results
	Given The user 'doctor' login in the Dashboard
	When The user selects 'CAPCTM' as device

