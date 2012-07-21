Feature: UpdateNewsArticleContentPreCommand
	Upon Updating the content of a News Management Article the pre command should be executed.

Scenario: Create UpdateNewsArticleContentPreCommand passing null as the Bus Throws Arguement Null Exception
	Given I have a validation resolver
	And I have a null service bus
	When I create a UpdateNewsArticleContentPreCommand
	Then a null argument exception will be thrown

Scenario: Create UpdateNewsArticleContentPreCommand passing null as the Validation Resolver Throws Arguement Null Exception
	Given I have a null validation resolver
	When I create a UpdateNewsArticleContentPreCommand
	Then a null argument exception will be thrown

Scenario: Create UpdateNewsArticleContentPreCommand passing null as the Service Throws Arguement Null Exception
	Given I have a null service
	When I create a UpdateNewsArticleContentPreCommand
	Then a null argument exception will be thrown

Scenario: Execute UpdateNewsArticleContentPreCommand with a Valid News Management Article
	Given I have a mocked service
	And I have a validation resolver
	And I have a mocked service bus
	And I have a saved news management article with the properties
		| CreatedBy | Title		 | Content		|
		| Jonathan  | Test Title | Test Content |
	And I setup the update content pre command
	When I change the Content to New Content
	And I execute the update content pre command
	Then the update content command result should have executed
	And the update content command result should be valid
	And get by id should have been called on the news management service

Scenario: Execute UpdateNewsArticleContentPreCommand with a invalid News Management Article
	Given I have a mocked service
	And I have a validation resolver
	And I have a mocked service bus
	And I have a saved news management article with the properties
		| CreatedBy | Title		 | Content		|
		| Jonathan  | Test Title | Test Content |
	And I change the Content to New Content
	And I setup the update content pre command
	When I execute the update content pre command
	Then the update content command result should have executed
	And the update content command result should be valid
	And get by id should have been called on the news management service