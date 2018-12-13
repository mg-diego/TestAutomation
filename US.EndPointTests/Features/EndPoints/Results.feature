Feature: Results

# GET /playground/results
Scenario: Playground - Get unreleased results
	Given a successful login
	When request to get unreleased results
	Then the response contains a list of unreleased results

# GET /playground/search/{barcode_id}
@Before_Scenario_unrelease_a_result_DB
#404 Not Found
Scenario: Playground - Get search
	Given a successful login
	When request to search for barcode '555555'
	Then The status code is '200'

# GET /playground/results/{barcode_id}
Scenario: Playground - Search result for barcode
	Given a successful login
	When request to get playground result from barcode '555555'
	Then the response contains result for barcode '555555'

# GET /playground/results/{barcode_id}
Scenario: Playground - Search result for non existing barcode
	Given a successful login
	When request to get playground result from barcode '-1asd1-1asd1-1asd-1asd'
	Then the response is empty

# POST /playground/results/release
@Before_Scenario_unrelease_a_result_DB
Scenario: Playground - release a result
	Given a successful login
	When request to release results for barcode '555555'
	Then response contains already released 'false' for barcode '555555'

# POST /playground/results/release
Scenario: Playground - release a non existing result
	Given a successful login
	When request to release results for barcode ''
	Then The status code is '404'

# POST /playground/results/release
@Before_Scenario_release_a_result_DB
Scenario: Playground - release a released result
	Given a successful login
	When request to release results for barcode '555555'
	Then response contains already released 'true' for barcode '555555'

# POST /playground/results/unrelease/{barcode_id}
@Before_Scenario_release_a_result_DB
Scenario: Playground - unrelease a result
	Given a successful login
	When request to unrelease results for barcode '555555'
	Then response contains the result 'Unreleased Ok'

# POST /playground/results/unrelease/{barcode_id}
@Before_Scenario_unrelease_a_result_DB
Scenario: Playground - unrelease an unreleased result
	Given a successful login
	When request to unrelease results for barcode '555555'
	Then response contains the result 'Already unreleased'

# POST /playground/results/unrelease/{barcode_id}
Scenario: Playground - unrelease a non existing result
	Given a successful login
	When request to unrelease results for barcode ''
	Then The status code is '404'

# POST /playground/results/changebarcode
@After_Scenario_change_result_barcode_DB
Scenario: Playground - Change to a new barcode
	Given a successful login
	And request to get playground result from barcode '888888'
	And the response is empty
	When request to change barcode '777777' to barcode '888888'
	Then The status code is '200'
	When request to get playground result from barcode '888888'
	Then the response contains '888888' barcode

# POST /playground/results/changebarcode
Scenario: Playground - Change non existing barcode
	Given a successful login
	When request to change barcode 'adasdasdsad' to barcode 'adsasdas'
	Then The status code is '404'

# POST /playground/results/changebarcode
Scenario: Playground - Change to an existing barcode
	Given a successful login
	When request to change barcode '777777' to barcode '777777'
	Then The status code is '400'
	And response contains the result 'New barcode already exists'



# POST /register
@before_clean_result_from_db
Scenario: Register - Add a result in result table
	Given App token is generated for 'ExportClient' client
	When request to register result with value '50000' for barcode 'NEW_RESULT_ENDPOINT'
	Then The status code is '200'

# POST /register
@before_clean_result_from_db
Scenario: Register - Add an existing result
	Given App token is generated for 'ExportClient' client
	When request to register result with value '50000' for barcode 'NEW_RESULT_ENDPOINT'
	And The status code is '200'
	And request to register second result for barcode 'NEW_RESULT_ENDPOINT'
	Then response contains the result 'An error occurred while updating the entries. See the inner exception for details.'

# POST /register
Scenario: Register - Forbidden (403)
	Given App token is generated for 'ReportingApi' client
	When request to register result with value '50000' for barcode 'asd'
	And The status code is '403'



# GET /results/all
Scenario: Results - Get All
	Given App token is generated for 'ReportingApi' client
	When request to get all read results
	Then the response contains a list of all results

# GET /results/barcode
@Before_Scenario_clean_DB
Scenario: Results - Barcode
	Given App token is generated for 'ReportingApi' client
	And a successful login
	And request to register barcode '555555'
	And The status code is '200'
	When request to get barcode '555555'
	Then response contains the result '555555'

# POST /results/search (deviceType, sites, from, to, testTypes)
Scenario: Results - Search
	Given App token is generated for 'ReportingApi' client
	When request to post results search
	Then The response contains results search

# POST /results/ (barcode)
Scenario: Results - Get results from barcode
	Given a successful login
	When request to get results from barcode '777777'
	Then response contains the result 'en_777777'

# POST /results/ (barcode)
Scenario: Results - Get results from non existing barcode
	Given a successful login
	When request to get results from barcode '-1asd1-1asd1-1asd-1asd'
	Then the response is empty

# POST /results/ (barcode)
Scenario: Results - Get results without authorization
	Given an invalid login
	When request to get results from barcode '-1asd1-1asd1-1asd-1asd'
	Then The status code is '401'








