Feature: Analytics

#POST /events
Scenario: Events - Send new event with successful login
	Given a successful login
	When request to send new event is called
	Then The status code is '200'

#POST /events
Scenario: Events - Send new event with invalid login
	Given an invalid login
	When request to send new event is called
	Then The status code is '401'

#POST /events
Scenario: Events - Add a new event
	Given a successful login
	When request to send new event with source_id 'testing-source_id'
	And resquest to search for date from '2018/08/01' to '2018/10/10'
	Then response contains an event with source_id 'testing-source_id'


#GET /events/search (dates)
Scenario: Search - Search for events
	Given a successful login
	When resquest to search for date from '2018/08/01' to '2018/10/10'
	Then The status code is '200'
	And the events are inside the search range from '2018/08/01' to '2018/10/10'

#GET /events/search (dates)
Scenario: Search - Search using wrong dates
	Given a successful login
	When resquest to search using wrong dates format
	Then The status code is '200'
	And the response is empty