Feature: Uses cases
	

@Before_Scenario_clean_DB
Scenario: user receives the results of a barcode
	Given request to get registered barcodes 
	And the response does not contain '555555' barcode
	And request to register barcode '555555'
	And the response contains '555555' barcode
	And request to get results for barcode '555555'
	And the response is empty
	When request to release results for barcode '555555'
	Then The status code is '200'
	And response contains the result for barcode '555555'


@Before_Scenario_release_a_result_DB
Scenario: user unreleases result of a barcode
	Given request to get registered barcodes 
	And the response does not contain '555555' barcode
	And request to register barcode '555555'
	And the response contains '555555' barcode
	And request to get results for barcode '555555'
	#And the response is empty
	When request to unrelease results for barcode '555555'
	Then The status code is '200'
	And response contains the result for barcode '555555'
