@ResultRelease

Feature: SearchBarcode

@AfterscenarioWithResetBrowser
Scenario: As a user I can open Search Barcode tab
	Given The user 'doctor' login in the Result Release
	When The user opens Search Barcode
	Then The Search Barcode tab is opened

@AfterScenarioWithUnreleaseBarcode
Scenario: As a user I can release an existing Barcode
	Given The user 'doctor' login in the Result Release
	And The user opens Search Barcode
	When The user releases the 'BBEV0503K' barcode
	Then The barcode 'BBEV0503K' is released

@AfterScenarioWithReleaseBarcode
Scenario: As a user I can unrelease an existing Barcode
	Given The user 'doctor' login in the Result Release
	And The user opens Search Barcode
	When The user unreleases the '$KUCS0928U' barcode
	Then The barcode '$KUCS0928U' is unreleased

@AfterscenarioWithResetBrowser
Scenario: As a user I can't release an already released Barcode
	Given The user 'doctor' login in the Result Release
	And The user opens Search Barcode
	When The user releases the '$BDZT8867J' barcode
	Then The barcode '$BDZT8867J' is not released

@AfterscenarioWithResetBrowser
Scenario: As a user I can't unrelease an already unreleased Barcode
	Given The user 'doctor' login in the Result Release
	And The user opens Search Barcode
	When The user unreleases the 'ATHU7356A' barcode
	Then The barcode 'ATHU7356A' is not unreleased
