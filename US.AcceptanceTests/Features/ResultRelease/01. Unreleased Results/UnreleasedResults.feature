@ResultRelease
@AfterscenarioWithResetBrowser
Feature: Unreleased Results



Scenario: As a user I can open Unreleased Result tab
	Given The user 'doctor' login in the Result Release
	When The user opens Unreleased Result
	Then The Unreleased Result tab is opened

Scenario: As a user I can filter by an existing Barcode
	Given The user 'doctor' login in the Result Release
	When The user filter by existing 'HRMP2941Q' barcode
	Then Only the 'HRMP2941Q' barcode appears

Scenario: As a user I can clear my filter
	Given The user 'doctor' login in the Result Release
	And The user filter by non existing 'asdf' barcode
	When The user clicks in Clear Filter
	Then The user can see all the barcodes

Scenario: As a user I can select all the Barcodes
	Given The user 'doctor' login in the Result Release
	When The user clicks in select all barcodes checkbox
	Then All the barcodes of the page are selected

Scenario: As a user I can go to next page of Barcodes
	Given The user 'doctor' login in the Result Release
	When The user clicks in go to Next page
	Then The Next page is opened

Scenario: As a user I can go to previous page of Barcodes
	Given The user 'doctor' login in the Result Release
	And The user clicks in go to Next page
	When The user clicks in go to Previous page
	Then The Previous page is opened

@PENDING
Scenario: As a user I can see the Barcodes list alphabetically ordered
	Given The user 'doctor' login in the Result Release
	When The user clicks in go to Previous page
	Then The Previous page is opened


Scenario: As a user the current page number is stored even if I navigate
	Given The user 'doctor' login in the Result Release
	And The user clicks in go to Next page
	And The user opens Search Barcode
	When The user opens Unreleased Result
	Then The Next page is opened 
