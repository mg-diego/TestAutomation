Feature: Reporting

#GET /testtypes
Scenario: GET - Test types
	Given a successful login
	When request to get the 'testtypes'
	Then The response contains the current test types

#GET /sites
Scenario: GET - Sites
	Given a successful login
	When request to get the 'sites'
	Then The response contains the current sites

#GET /devices
Scenario: GET - Devices
	Given a successful login
	When request to get the 'devices'
	Then The response contains all the devices





#POST /processingtimeweekly + date range
Scenario Outline: POST - 
	Given a successful login
	When request to post '<endpoint>' from '<from_date>' to '<to_date>'
	Then The response contains the '<endpoint>' from '<from_date>' to '<to_date>' 

Examples: 
	| endpoint             | from_date                | to_date                  |
	| processingtimeweekly | 2016-01-01T00:00:00.000Z | 2018-04-26T23:59:59.999Z |




# INVALID DATES RANGE
#POST /{endpoint} + date range
Scenario Outline: POST - Invalid date range
	Given a successful login
	When request to post '<endpoint>' from '<from_date>' to '<to_date>'
	Then response contains the result '<response>'

Examples: 
	| endpoint             | from_date                | to_date                  | response |
	| sitedata             | 2019-01-01T00:00:00.000Z | 2018-04-26T23:59:59.999Z |    []    |
	| qualitycontrol       | 2019-01-01T00:00:00.000Z | 2018-04-26T23:59:59.999Z |    []    |
	| processingtime       | 2019-01-01T00:00:00.000Z | 2018-04-26T23:59:59.999Z |    []    |
	| processingtimeweekly | 2019-01-01T00:00:00.000Z | 2018-04-26T23:59:59.999Z |   null   |



# INVALID DEVICES
Scenario Outline: POST - Invalid device type
	Given a successful login
	When request to post '<endpoint>' for device '<deviceType>'
	Then response contains the result '<response>'

Examples: 
	| endpoint             | deviceType | response |
	| sitedata             | invalid    | []       |
	| qualitycontrol       | invalid    | []       |
	| processingtime       | invalid    | []       |
	| processingtimeweekly | invalid    | null     |


# INVALID SITES
Scenario Outline: POST - Invalid Sites
	Given a successful login
	When request to post '<endpoint>' for site '<site>'
	Then response contains the result '<response>'

Examples: 
	| endpoint             | site    | response |
	| sitedata             | invalid | []       |
	| qualitycontrol       | invalid | []       |
	| processingtime       | invalid | []       |
	| processingtimeweekly | invalid | null     |


# INVALID TEST TYPES
Scenario Outline: POST - Invalid test types
	Given a successful login
	When request to post '<endpoint>' for testType '<testType>'
	Then response contains the result '<response>'

Examples: 
	| endpoint             | testType | response |
	| sitedata             | invalid  | []       |
	| qualitycontrol       | invalid  | []       |
	| processingtime       | invalid  | []       |
	| processingtimeweekly | invalid  | null     |

