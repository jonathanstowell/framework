Feature: CreateNewsManagementNewsArticleValidator
	Upon Creation of a News Management Article these rules should be upheld.

Scenario: Create a Valid News Management Article
	Given I have a news management article with the properties
		| CreatedBy | Title		 | Content		|
		| Jonathan  | Test Title | Test Content |
	When I validate the creation
	Then the result should be valid

Scenario: Create a Invalid News Management Article with a empty CreatedBy property
	Given I have a news management article with the properties
		| CreatedBy | Title		 | Content		|
		|		    | Test Title | Test Content |
	When I validate the creation
	Then the result should be invalid
	And there should be 2 errors
	And there should be an error for CreatedBy with message 'Created By' should not be empty.
	And there should be an error for CreatedBy with message 'Created By' must be between 1 and 35 characters. You entered 0 characters.

Scenario: Create a Invalid News Management Article with a empty Title property
	Given I have a news management article with the properties
		| CreatedBy | Title		 | Content		|
		| Jonathan  |			 | Test Content |
	When I validate the creation
	Then the result should be invalid
	And there should be 2 errors
	And there should be an error for Title with message 'Title' should not be empty.
	And there should be an error for Title with message 'Title' must be between 1 and 100 characters. You entered 0 characters.

Scenario: Create a Invalid News Management Article with a empty Content property
	Given I have a news management article with the properties
		| CreatedBy | Title		 | Content	|
		| Jonathan  | Test Title |			|
	When I validate the creation
	Then the result should be invalid
	And there should be 1 error
	And there should be an error for Content with message 'Content' should not be empty.

Scenario: Create a Invalid News Management Article with a CreatedBy property longer than 35 characters
	Given I have a news management article with the properties
		| CreatedBy                                          | Title	  | Content      |
		| ThisStringWillBeLongerThanThirtyFiveCharactersLong | Test Title | Test Content |
	When I validate the creation
	Then the result should be invalid
	And there should be 1 error
	And there should be an error for CreatedBy with message 'Created By' must be between 1 and 35 characters. You entered 50 characters.

Scenario: Create a Invalid News Management Article with a Title property longer than 100 characters
	Given I have a news management article with the properties
		| CreatedBy | Title																									| Content		|
		| Jonathan  | biqoxsuhouhhcarjygwofxyzigirlfktaepvznsiwsemqqpcbsznlqpfzjhobdyiahnxjdoqyhmxgoogipmvlkzlziahvfurwdgxc | Test Content  |
	When I validate the creation
	Then the result should be invalid
	And there should be 1 error
	And there should be an error for Title with message 'Title' must be between 1 and 100 characters. You entered 101 characters.