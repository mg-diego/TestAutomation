@iThemba
@AfterScenarioWithGoToBloodResults
Feature: BloodResults
	As a user I want to have my Blood Results

@BeforeScenarioWithUniqueLogin
Scenario: User can open the Blood Results menu option
	Given The user opens the iThemba app menu
	When The user opens the Blood Results menu option
	Then The Blood Results is opened

@BeforeScenarioWithResetApp
Scenario: As a user without any barcode I can see the Scan the first Barcode page
	Given The user 'NoResult' login in the iThemba app
	And The user opens the iThemba app menu
	When The user opens the Blood Results menu option
	Then The Scan the first Barcode page is opened

@BeforeScenarioWithResetApp
Scenario: As a user without any barcode I can go to Barcode Scan
	Given The user 'NoResult' login in the iThemba app
	And The user opens the iThemba app menu
	And The user opens the Blood Results menu option
	When The user clicks in Go to Scanner
	Then The mobile camera is opened

@BeforeScenarioWithResetApp
Scenario: As a user with a barcode without result I can see the Your results are on the way page
	Given The user 'ResultsOnTheWay' login in the iThemba app
	And The user opens the iThemba app menu
	When The user opens the Blood Results menu option
	Then The 'ResultsOnTheWay' Blood Results page is opened

@BeforeScenarioWithResetApp
Scenario: As a user with a barcode without result I can go to Community Chats
	Given The user 'ResultsOnTheWay' login in the iThemba app
	And The user opens the iThemba app menu
	And The user opens the Blood Results menu option
	When The user clicks in Go to Community
	Then The Chat with Communities is opened


@BeforeScenarioWithResetApp
Scenario Outline: As a user with a 50-1000 cp/ml I can see my results at Blood Results
	Given The user '<user>' login in the iThemba app
	And The user opens the iThemba app menu
	When The user opens the Blood Results menu option
	Then The '<user>' Blood Results page is opened

	Examples: 
	| user     |
	| User50   |
	| User1000 |


@BeforeScenarioWithResetApp	
Scenario: As a user with less than 50 cp/ml I can see my results at Blood Results
	Given The user 'User49' login in the iThemba app
	And The user opens the iThemba app menu
	When The user opens the Blood Results menu option
	Then The 'User49' Blood Results page is opened
	
@BeforeScenarioWithResetApp
Scenario: As a user with more than 1000 cp/ml I can see my results at Blood Results
	Given The user 'User1001' login in the iThemba app
	And The user opens the iThemba app menu
	When The user opens the Blood Results menu option
	Then The 'User1001' Blood Results page is opened

@BeforeScenarioWithResetApp
Scenario: As a user that recovers Network I can see Blood Results again
    Given The user 'User49' login in the iThemba app and loses Network
	When The user recovers Network and click in Try Again
	Then The 'User49' Blood Results page is opened

@BeforeScenarioWithResetApp
Scenario: As a user I can remain in the application after using Android native BACK button
	Given The user 'User49' login in the iThemba app
	And The user clicks on Android back button
	When The user clicks in NO button from Exit pop up message
	Then The Blood Results is opened

@BeforeScenarioWithResetApp
Scenario: As a user I can see a banner with my results on the way
	Given The user 'ResultsOnTheWayMultiple' login in the iThemba app
	And The user opens the iThemba app menu
	When The user opens the Blood Results menu option
	Then The Results on the way banner appears

@BeforeScenarioWithResetApp
Scenario: As a user I can close the banner with my results on the way
	Given The user 'ResultsOnTheWayMultiple' login in the iThemba app
	When The user closes the Results on the Way banner
	And The user opens the iThemba app menu
	And The user opens the Blood Results menu option
	Then The Results on the way banner doesn't appear

@BeforeScenarioWithResetApp
Scenario: As a user I can open and exit from Past Results
	Given The user 'UserMultipleResults' login in the iThemba app
	And The user opens the Past Results menu option
	When The user closes the Past Results menu option
	Then The Blood Results is opened

@BeforeScenarioWithResetApp
Scenario Outline: As a user I can see all my results at Past Results
	Given The user '<user>' login in the iThemba app
	When The user opens the Past Results menu option
	Then The user '<user>' Past Results page is opened

	Examples: 
	| user     |
	| User49   |
	| User50   |
	| User1000 |
	| User1001 |
	| UserMultipleResults |
	| ResultsOnTheWayMultiple |

@BeforeScenarioWithResetApp
Scenario Outline: As a user I can see my barcodes at Past Results
	Given The user '<user>' login in the iThemba app
	When The user opens the Past Results menu option
	And The user clicks in Show Barcode
	Then The user '<user>' barcode is opened

	Examples: 
	| user     |
	| User49   |
	| User50   |
	| User1000 |
	| User1001 |
	| UserMultipleResults |
	| ResultsOnTheWayMultiple |

@BeforeScenarioWithResetApp
Scenario: As a user I can close my barcodes at Past Results
	Given The user 'UserMultipleResults' login in the iThemba app
	When The user opens the Past Results menu option
	And The user clicks in Show Barcode
	And The user clicks in Close Barcode
	Then The user 'UserMultipleResults' Past Results page is opened


