Feature: DeletedNewsArticlePreCommand
	Upon Deletion of a News Management Article the pre command should be executed.

Scenario: Create DeletedNewsArticlePreCommand passing null as the Bus Throws Arguement Null Exception
	Given I have a validation resolver
	And I have a null service bus
	When I create a DeletedNewsArticlePreCommand
	Then a null argument exception will be thrown

Scenario: Create DeletedNewsArticlePreCommand passing null as the Validation Resolver Throws Arguement Null Exception
	Given I have a null validation resolver
	When I create a DeletedNewsArticlePreCommand
	Then a null argument exception will be thrown

Scenario: Create DeletedNewsArticlePreCommand passing null as the Service Throws Arguement Null Exception
	Given I have a null service
	When I create a DeletedNewsArticlePreCommand
	Then a null argument exception will be thrown

Scenario: Execute DeletedNewsArticlePreCommand with a Valid News Management Article
	Given I have a validation resolver
	And I have a mocked service
	And I have a mocked service bus
	And I have a saved news management article with the properties
		| CreatedBy | Title | Content |
		| Jonathan  | Test Title | Test Content |
	And I setup the deletion pre command
	When I execute the deletion pre command
	Then the deletion command result should have executed
	And the deletion command result should be valid

Scenario: Execute DeletedNewsArticlePreCommand without a saved News Management Article
	Given I have a validation resolver
	And I have a mocked service
	And I have a mocked service bus
	And I do not have a saved news management article with the identifier 4f80bc4a-384d-45fc-881a-432b2075d746
	And I initialise the DeletedNewsArticlePreCommand to delete the news management article with the identifier 4f80bc4a-384d-45fc-881a-432b2075d746
	When I execute the deletion pre command
	Then the deletion command result should have executed
	And the deletion command result should be invalid