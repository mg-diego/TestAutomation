@iThemba
@Story:ScanBarcode

Feature: ScanBarcode
	As a user i want a clear indication when i scan a barcode that i am doing it correctly

@BeforeScenarioWithUniqueLogin
@AfterScenarioWithGoToBloodResults
Scenario: User can open the camera to scan a Barcode
	Given The user opens the iThemba app menu
	When The user opens Barcode Scan menu option
	Then The mobile camera is opened


@BeforeScenarioWithUniqueLogin
@AfterScenarioWithGoToBloodResults
Scenario: User can exit the camera by pressing Android native Back button
	Given The user opens the iThemba app menu
	And The user opens Barcode Scan menu option
	When The user clicks on Android back button
	Then The Blood Results is opened