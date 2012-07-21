Feature: DeleteNewsListNewsArticleValidator
	Upon Deletion of a News Management Article these rules should be upheld.

Scenario: Delete a Valid News Management Article
	Given I have a saved news management article with the properties
		| CreatedBy | Title		 | Content		|
		| Jonathan  | Test Title | Test Content |
	When I validate the deletion
	Then the result should be valid

Scenario: Delete a Non Existing News Management Article
	Given I do not have a news management article
	When I validate the deletion
	Then the result should be invalid
	And there should be 1 error
	And there should be an error for General with message News Article does not exist