Feature: NewsManagementController

Scenario: Create News Management Controller passing null as the Validation Resolver Throws Arguement Null Exception
	Given I have a null service
	When I create a NewsManagementController
	Then a null argument exception will be thrown

Scenario: Create News Management Controller passing null as the Current User Details Throws Arguement Null Exception
	Given I have a null current user details
	When I create a NewsManagementController
	Then a null argument exception will be thrown

Scenario: News Management Controller GET Create Action Returns Partial Create View
	Given I have a mocked service
	And I have a mocked current user details
	And I have a news management article with the properties
		| Title		 | Content		|
		| Test Title | Test Content |
	And I have a News Management Controller
	When I execute the Create GET action
	Then the Create partial view should be rendered

Scenario: News Management Controller POST Create Action Returns Valid Validation Json Result
	Given I have a mocked service
	And I have a mocked current user details
	And I have a validation resolver
	And I have a mocked service bus
	And the current user is jonathan
	And I have a news management article with the properties
		| Title		 | Content		|
		| Test Title | Test Content |
	And I have a News Management Controller
	When I execute the Create POST action
	Then a json result will be returned
	And it will contain a validation result
	And the result will be valid

Scenario: News Management Controller POST Create Action Returns Invalid Validation Json Result
	Given I have a mocked service
	And I have a mocked current user details
	And I have a validation resolver
	And I have a mocked service bus
	And the current user is jonathan
	And I have a news management article with the properties
		| Title		 | Content		|
		|			 | Test Content |
	And I have a News Management Controller
	When I execute the Create POST action
	Then a json result will be returned
	And it will contain a validation result
	And the result will be invalid

Scenario: News Management Controller POST Rename Action Returns Valid Validation Json Result
	Given I have a mocked service
	And I have a mocked current user details
	And I have a validation resolver
	And I have a mocked service bus
	And I have a saved news management article with the properties
		| Id								   | CreatedBy | Title		| Content |
		| 4f80bc4a-384d-45fc-881a-432b2075d746 | Jonathan  | Test Title | Test Content |
	And I have a News Management Controller
	When I execute the Rename POST action with id as 4f80bc4a-384d-45fc-881a-432b2075d746 and title as New Title
	Then a json result will be returned
	And it will contain a validation result
	And the result will be valid

Scenario: News Management Controller POST Rename Action Returns Invalid Validation Json Result
	Given I have a mocked service
	And I have a mocked current user details
	And I have a validation resolver
	And I have a mocked service bus
	And I have a saved news management article with the properties
		| Id								   | CreatedBy | Title		| Content |
		| 4f80bc4a-384d-45fc-881a-432b2075d746 | Jonathan  | Test Title | Test Content |
	And I have a News Management Controller
	When I execute the Rename POST action with id as 4f80bc4a-384d-45fc-881a-432b2075d746 and title as nothing
	Then a json result will be returned
	And it will contain a validation result
	And the result will be invalid

Scenario: News Management Controller POST UpdateContent Action Returns Valid Validation Json Result
	Given I have a mocked service
	And I have a mocked current user details
	And I have a validation resolver
	And I have a mocked service bus
	And I have a saved news management article with the properties
		| Id								   | CreatedBy | Title		| Content |
		| 4f80bc4a-384d-45fc-881a-432b2075d746 | Jonathan  | Test Title | Test Content |
	And I have a News Management Controller
	When I execute the UpdateContent POST action with id as 4f80bc4a-384d-45fc-881a-432b2075d746 and content as New Content
	Then a json result will be returned
	And it will contain a validation result
	And the result will be valid

Scenario: News Management Controller POST UpdateContent Action Returns Invalid Validation Json Result
	Given I have a mocked service
	And I have a mocked current user details
	And I have a validation resolver
	And I have a mocked service bus
	And I have a saved news management article with the properties
		| Id								   | CreatedBy | Title		| Content |
		| 4f80bc4a-384d-45fc-881a-432b2075d746 | Jonathan  | Test Title | Test Content |
	And I have a News Management Controller
	When I execute the UpdateContent POST action with id as 4f80bc4a-384d-45fc-881a-432b2075d746 and content as nothing
	Then a json result will be returned
	And it will contain a validation result
	And the result will be invalid

Scenario: News Management Controller GET Edit Action Returns Partial Edit View
	Given I have a mocked service
	And I have a mocked current user details
	And I have a News Management Controller
	When I execute the Edit GET action
	Then the Edit partial view should be rendered

Scenario: News Management Controller GET Delete Action Returns Delete Partial View
	Given I have a mocked service
	And I have a mocked current user details
	And I have a News Management Controller
	When I execute the Delete GET action
	Then the Delete partial view should be rendered

Scenario: News Management Controller POST Delete Action Returns Valid Validation Json Result
	Given I have a mocked service
	And I have a mocked current user details
	And I have a validation resolver
	And I have a mocked service bus
	And I have a saved news management article with the properties
		| Id								   | CreatedBy | Title		| Content |
		| 4f80bc4a-384d-45fc-881a-432b2075d746 | Jonathan  | Test Title | Test Content |
	And I have a News Management Controller
	When I execute the Delete POST action with id as 4f80bc4a-384d-45fc-881a-432b2075d746
	Then a json result will be returned
	And it will contain a validation result
	And the result will be valid

Scenario: News Management Controller POST Delete Action Returns Invalid Validation Json Result
	Given I have a mocked service
	And I have a mocked current user details
	And I have a validation resolver
	And I have a mocked service bus
	And I do not have a saved news management article with the identifier 4f80bc4a-384d-45fc-881a-432b2075d746
	And I have a News Management Controller
	When I execute the Delete POST action with id as 4f80bc4a-384d-45fc-881a-432b2075d746
	Then a json result will be returned
	And it will contain a validation result
	And the result will be invalid

Scenario: News Management Controller GetNewsArticleForUpdateOrDelete Action Returns News Management Article Json Result
	Given I have a mocked service
	And I have a mocked current user details
	And I have a validation resolver
	And I have a mocked service bus
	And I have a saved news management article with the properties
		| Id								   | CreatedBy | Title		| Content |
		| 4f80bc4a-384d-45fc-881a-432b2075d746 | Jonathan  | Test Title | Test Content |
	And I have a News Management Controller
	When I execute the GetNewsArticleForUpdateOrDelete GET action with id as 4f80bc4a-384d-45fc-881a-432b2075d746
	Then a json result will be returned
	And it will contain a news management article
	And the json news management article Id will be 4f80bc4a-384d-45fc-881a-432b2075d746
	And the json news management article CreatedBy will be Jonathan
	And the json news management article Title will be Test Title
	And the json news management article Content will be Test Content

Scenario: News Management Controller GetNewsArticleForUpdateOrDelete Action Returns a null Json Result
	Given I have a mocked service
	And I have a mocked current user details
	And I have a validation resolver
	And I have a mocked service bus
	And I do not have a saved news management article with the identifier 4f80bc4a-384d-45fc-881a-432b2075d746
	And I have a News Management Controller
	When I execute the GetNewsArticleForUpdateOrDelete GET action with id as 4f80bc4a-384d-45fc-881a-432b2075d746
	Then a json result will be returned
	And the json result it will be null