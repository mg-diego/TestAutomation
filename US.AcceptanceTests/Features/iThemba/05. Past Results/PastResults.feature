@iThemba
@AfterScenarioWithGoToBloodResults
Feature: PastResults


@BeforeScenarioWithResetApp
Scenario: As a user I can open and exit from Past Results
	Given The user 'UserMultipleResults' login in the iThemba app
	And The user opens the Past Results menu option
	When The user closes the Past Results menu option

@BeforeScenarioWithResetApp
Scenario Outline: As a user I can see all my results at Past Results
	Given The user '<user>' login in the iThemba app
	When The user opens the Past Results menu option
	Then The user '<user>' Past Results page is opened

	Examples: 
	| user							  |
	| User49						  |
	| UserMultipleResults			  |
	| ResultsOnTheWayMultiple		  |

@BeforeScenarioWithResetApp
Scenario Outline: As a user I can see my barcodes at Past Results
	Given The user '<user>' login in the iThemba app
	When The user opens the Past Results menu option
	And The user clicks in Show Barcode
	Then The user '<user>' barcode is opened

	Examples: 
	| user							  |
	| User49						  |
	| UserWithMultipleImportResults   |
	| UserWithMultipleInvalidResults  |
	| UserMultipleResults			  |
	| ResultsOnTheWayMultiple		  |

@BeforeScenarioWithResetApp
Scenario: As a user I can close my barcodes at Past Results
	Given The user 'UserMultipleResults' login in the iThemba app
	When The user opens the Past Results menu option
	And The user clicks in Show Barcode
	And The user clicks in Close Barcode
	Then The user 'UserMultipleResults' Past Results page is opened
