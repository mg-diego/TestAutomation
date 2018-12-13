@After_scenario_empty_whatsapp_groups
Feature: ReferenceData


@Before_scenario_empty_whatsapp_groups
Scenario Outline: Get groups
	Given a successful login
	When request to get the groups for gender '<gender>' and clinic '<clinic>'
	Then the response contains groups for gender '<gender>' and clinic '<clinic>'

Examples: 
| example description | gender | clinic |
| Male-HI			  | Male   | HI     |
| Male-YE             | Male   | YE     |
| Female-HI           | Female | HI     |
| Female-YE			  | Female | YE     |


@Before_scenario_complete_whatsapp_groups
Scenario: Get groups - No group available
	Given a successful login
	When request to get the groups for gender 'Female' and clinic 'YE'
	Then the response is empty

@Before_scenario_complete_first_whatsapp_groups
Scenario: Get groups - Only second groups available
	Given a successful login
	When request to get the groups for gender 'Female' and clinic 'YE'
	Then the response contains the next group available