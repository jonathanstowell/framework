Feature: UpdateNewsListNewsArticleValidator
	Upon Updating of a News Management Article these rules should be upheld.

Scenario: Attempt to Update a Invalid News Management Article with a empty CreatedBy property
	Given I have a saved news management article with the properties
		| CreatedBy | Title		 | Content		|
		| Jonathan  | Test Title | Test Content |
	When I change the Creator to nothing
	And I validate the reauthoring
	Then the result should be invalid
	And there should be 1 error
	And there should be an error for CreatedBy with message It is not possible to update the Creator of a Article

Scenario: Rename a Valid News Management Article
	Given I have a saved news management article with the properties
		| CreatedBy | Title		 | Content		|
		| Jonathan  | Test Title | Test Content |
	When I rename the Title to New Title
	And I validate the renaming
	Then the result should be valid

Given I have a saved news management article with the properties
		| CreatedBy | Title		 | Content		 |
		| Jonathan  | Test Title | Test Content  |
	When I rename the Title to biqoxsuhouhhcarjygwofxyzigirlfktaepvznsiwsemqqpcbsznlqpfzjhobdyiahnxjdoqyhmxgoogipmvlkzlziahvfurwdgxc
	And I validate the renaming
	Then the result should be invalid
	And there should be 1 error
	And there should be an error for Title with message 'Title' must be between 1 and 100 characters. You entered 101 characters.

Scenario: Rename a News Management Article with a empty Title property
	Given I have a saved news management article with the properties
		| CreatedBy | Title		 | Content		 |
		| Jonathan  | Test Title | Test Content  |
	When I rename the Title to nothing
	And I validate the renaming
	Then the result should be invalid
	And there should be 2 errors
	And there should be an error for Title with message 'Title' should not be empty.
	And there should be an error for Title with message 'Title' must be between 1 and 100 characters. You entered 0 characters.

Scenario: Update the Content of a Valid News Management Article
	Given I have a saved news management article with the properties
		| CreatedBy | Title		 | Content		|
		| Jonathan  | Test Title | Test Content |
	When I change the Content to New Content
	And I validate the content update
	Then the result should be valid

Scenario: Create a Invalid News Management Article with a empty Content property
	Given I have a saved news management article with the properties
		| CreatedBy | Title		 | Content		|
		| Jonathan  | Test Title | Test Content |
	When I change the Content to nothing
	And I validate the content update
	Then the result should be invalid
	And there should be 1 error
	And there should be an error for Content with message 'Content' should not be empty.