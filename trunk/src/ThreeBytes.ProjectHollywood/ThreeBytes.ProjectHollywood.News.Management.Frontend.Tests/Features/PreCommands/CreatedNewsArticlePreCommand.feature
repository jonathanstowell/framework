Feature: CreatedNewsArticlePreCommand
	Upon Creation of a News Management Article the pre command should be executed.

Scenario: Create CreatedNewsArticlePreCommand passing null as the Validation Resolver Throws Arguement Null Exception
	Given I have a null validation resolver
	When I create a CreatedNewsArticlePreCommand
	Then a null argument exception will be thrown

Scenario: Create CreatedNewsArticlePreCommand passing null as the Bus Throws Arguement Null Exception
	Given I have a validation resolver
	And I have a null service bus
	When I create a CreatedNewsArticlePreCommand
	Then a null argument exception will be thrown

Scenario: Execute CreatedNewsArticlePreCommand with a Valid News Management Article
	Given I have a validation resolver
	And I have a mocked service bus
	And I have a news management article with the properties
		| CreatedBy | Title		 | Content		|
		| Jonathan  | Test Title | Test Content |
	And I setup the create pre command
	When I execute the create pre command
	Then the create command result should have executed
	And the create command result should be valid

Scenario: Execute CreatedNewsArticlePreCommand with an Invalid News Management Article
	Given I have a validation resolver
	And I have a mocked service bus
	And I have a news management article with the properties
		| CreatedBy | Title		 | Content		|
		| Jonathan  |            | Test Content |
	And I setup the create pre command
	When I execute the create pre command
	Then the create command result should have executed
	And the create command result should be invalid