Feature: RenameNewsArticleTitlePreCommand
	Upon Renaming of a News Management Article the pre command should be executed.

Scenario: Create RenameNewsArticleTitlePreCommand passing null as the Bus Throws Arguement Null Exception
	Given I have a validation resolver
	And I have a null service bus
	When I create a RenameNewsArticleTitlePreCommand
	Then a null argument exception will be thrown

Scenario: Create RenameNewsArticleTitlePreCommand passing null as the Validation Resolver Throws Arguement Null Exception
	Given I have a null validation resolver
	When I create a RenameNewsArticleTitlePreCommand
	Then a null argument exception will be thrown

Scenario: Create RenameNewsArticleTitlePreCommand passing null as the Service Throws Arguement Null Exception
	Given I have a null service
	When I create a RenameNewsArticleTitlePreCommand
	Then a null argument exception will be thrown

Scenario: Execute RenameNewsArticleTitlePreCommand with a Valid News Management Article
	Given I have a mocked service
	And I have a validation resolver
	And I have a mocked service bus
	And I have a saved news management article with the properties
		| CreatedBy | Title		 | Content		|
		| Jonathan  | Test Title | Test Content |
	And I setup the rename pre command
	When I rename the Title to Tobin
	And I execute the rename pre command
	Then the rename command result should have executed
	And the rename command result should be valid

Scenario: Execute RenameNewsArticleTitlePreCommand with an Invalid News Management Article
	Given I have a mocked service
	And I have a validation resolver
	And I have a mocked service bus
	And I have a saved news management article with the properties
		| CreatedBy | Title		 | Content		|
		| Jonathan  | Test Title | Test Content |
	And I rename the Title to nothing
	And I setup the rename pre command
	When I execute the rename pre command
	Then the rename command result should have executed
	And the rename command result should be invalid