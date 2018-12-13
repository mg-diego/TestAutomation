Feature: Barcodes


#POST /registration (barcode)
@Before_Scenario_clean_DB
Scenario: Registration - Register new barcode
	Given a successful login
	When request to register barcode '555555'
	Then the response contains '555555' barcode 

#POST /registration (barcode)
@Before_Scenario_clean_DB
Scenario: Registration - Register duplicated barcode
	Given a successful login
	And request to register barcode '555555'
	When request to register barcode '555555'
	Then The status code is '500'
	And The reponse contains error code '4097'

#POST /registration (barcode)
Scenario: Registration - Register new barcode without token authorization
	When request to register new barcode without token
	Then The status code is '401'

#POST /registration (barcode)
@Before_Scenario_clean_DB
Scenario: Registration - Register duplicated barcode without token authorization
	Given an invalid login
	And request to register new barcode without token
	When request to register same barcode without token
	Then The status code is '401'



#GET /barcodes
@Before_Scenario_clean_DB
Scenario: Barcodes - Get registered barcodes
	Given a successful login
	Given request to register barcode '555555'
	And The status code is '200'
	When request to get registered barcodes
	Then the response contains '555555' barcode



