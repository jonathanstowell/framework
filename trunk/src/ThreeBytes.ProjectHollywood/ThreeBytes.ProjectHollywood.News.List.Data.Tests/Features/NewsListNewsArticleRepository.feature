Feature: NewsListNewsArticleRepository
	Data Access tests for NewsManagementNewsArticleRepository

Scenario: Create a News List Article in a transaction
	Given I have a news list article with the properties
		| CreatedBy | Title		 | Content		|
		| Jonathan  | Test Title | Test Content |
	When I attempt to create the article in a transaction
	Then the repository result will be true
	And the article repository count should be 1
	And the Creator will be Jonathan
	And the Title will be Test Title
	And the Content will be Test Content

Scenario: Create a News List Article not in a transaction followed by Flushing Changes
	Given I have a news list article with the properties
		| CreatedBy | Title		 | Content		|
		| Jonathan  | Test Title | Test Content |
	When I attempt to create the article in a transaction
	And I flush the changes
	Then the repository result will be true
	And the article repository count should be 1
	And the Creator will be Jonathan
	And the Title will be Test Title
	And the Content will be Test Content

Scenario: Create a News List Article not in a transaction
	Given I have a news list article with the properties
		| CreatedBy | Title		 | Content		|
		| Jonathan  | Test Title | Test Content |
	When I attempt to create the article not in a transaction
	Then the article repository count should be 0
	And the repository result will be true

Scenario: Create a News List Article in a transaction with a null CreatedBy Property
	Given I have a news list article with the properties
		| CreatedBy | Title		 | Content		|
		| null      | Test Title | Test Content |
	When I attempt to create the article in a transaction
	Then the article repository count should be 0
	And the repository result will be false

Scenario: Create a News List Article in a transaction with a null Title Property
	Given I have a news list article with the properties
		| CreatedBy | Title | Content      |
		| Jonathan  | null  | Test Content |
	When I attempt to create the article in a transaction
	Then the article repository count should be 0
	And the repository result will be false

Scenario: Create a News List Article in a transaction with a null Content Property
	Given I have a news list article with the properties
		| CreatedBy | Title      | Content |
		| Jonathan  | Test Title | null    |
	When I attempt to create the article in a transaction
	Then the article repository count should be 0
	And the repository result will be false

Scenario: Update a News List Article in a transaction
	Given I have a saved news list article with the properties
		| CreatedBy | Title		 | Content		|
		| Jonathan  | Test Title | Test Content |
	When I update the news list article to the values below in a transaction
		| CreatedBy | Title		 | Content	   |
		| Tobin     | New Title  | New Content |
	Then the Creator will be Tobin
	And the Title will be New Title
	And the Content will be New Content
	And the repository result will be true

Scenario: Update a News List Article not in a transaction followed by Flushing Changes
	Given I have a saved news list article with the properties
		| CreatedBy | Title		 | Content		|
		| Jonathan  | Test Title | Test Content |
	When I update the news list article to the values below not in a transaction
		| CreatedBy | Title		 | Content	   |
		| Tobin     | New Title  | New Content |
	And I flush the changes
	Then the Creator will be Tobin
	And the Title will be New Title
	And the Content will be New Content
	And the repository result will be true

Scenario: Update a Invalid News List Article in a transaction
	Given I have a saved news list article with the properties
		| CreatedBy | Title		 | Content		|
		| Jonathan  | Test Title | Test Content |
	When I update the news list article to the values below in a transaction
		| CreatedBy | Title		 | Content	   |
		| null      | New Title  | New Content |
	Then the Creator will be Jonathan
	And the Title will be Test Title
	And the Content will be Test Content
	And the repository result will be true
	And the unit of work result will be false

Scenario: Update a Invalid News List Article not in a transaction followed by Flushing Changes
	Given I have a saved news list article with the properties
		| CreatedBy | Title		 | Content		|
		| Jonathan  | Test Title | Test Content |
	When I update the news list article to the values below not in a transaction
		| CreatedBy | Title		 | Content	   |
		| null      | New Title  | New Content |
	And I flush the changes
	Then the Creator will be Jonathan
	And the Title will be Test Title
	And the Content will be Test Content
	And the repository result will be false

Scenario: Delete a null News List Article in a transaction
	Given I have a null news list article
	When I attempt to delete the article in a transaction
	Then the article repository count should be 0
	And the repository result will be false

Scenario: Delete a News List Article in a transaction
	Given I have a saved news list article with the properties
		| CreatedBy | Title | Content |
		| Jonathan  | Test Title | Test Content |
	When I attempt to delete the article in a transaction
	Then the article repository count should be 0
	And the repository result will be true