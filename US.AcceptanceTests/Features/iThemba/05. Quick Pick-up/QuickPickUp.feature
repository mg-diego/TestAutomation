@iThemba
@BeforeScenarioWithResetApp
@AfterScenarioWithGoToBloodResults

@Story:Quick_Pick-up

Feature: QuickPickUp
	As a user when i have a viral load lower then 400 i can see my Quick Pick-up in the drawer app to be able to show it to the nurse


Scenario Outline: As a user with less than 400 vl I can view VIP Clinic Pass at menu
	Given The user '<user>' login in the iThemba app
	When The user opens the iThemba app menu
	Then The Quick Pick-up menu is visible

	Examples: 
	| user   |
	| User49 |
	| User50 |


Scenario Outline: As a user with more than 400 vl I can't view VIP Clinic Pass at menu
	Given The user '<user>' login in the iThemba app
	When The user opens the iThemba app menu
	Then The Quick Pick-up menu is not visible

	Examples: 
	| user       |
	| User1001	 |


Scenario Outline: As a user with less than 400 vl I can access VIP Clinic Pass section
	Given The user '<user>' login in the iThemba app
	And The user opens the iThemba app menu
	When The user opens the Quick Pick-up menu option
	Then The Quick Pick-up page of the '<user>' is opened

	Examples: 
	| user   |
	| User49 |
	| User50 |


Scenario Outline: As a user with Quick Pick-up I can see all my last results
	Given The user '<user>' login in the iThemba app
	And The user opens the iThemba app menu
	And The user opens the Quick Pick-up menu option
	When The user click in Show All Past Results
	Then The All Past Results of the '<user>' is opened

    Examples: 
	| user   |
	| User49 |
	| User50 |

