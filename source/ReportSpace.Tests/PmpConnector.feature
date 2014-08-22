Feature: PmpConnector
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Add two numbers
	Given I have entered 50 into the calculator
	And I have entered 70 into the calculator
	When I press add
	Then the result should be 120 on the screen


Scenario: Get data from PMP url
	Given I create a pmp request for week 14
	When I get the List response 14
	Then the response should contain 73 items
	
