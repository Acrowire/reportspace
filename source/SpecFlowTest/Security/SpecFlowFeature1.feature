Feature: SpecFlowFeature1
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers


@CreateAdminAccount
Scenario: Create Admin Accounts
	Given I create an Admin account
	When I save the an Admin account
	Then the Admin account should be store in the database.


@mytag
Scenario: Add two numbers
	Given I have entered 50 into the calculator
	And I have entered 70 into the calculator
	When I press add
	Then the result should be 120 on the screen
