Feature: Generic Repository
	In order to create an application I need to access data
	I want to be able to select data

Scenario: Insert Single Record
	Given I have created a person generic repository
	And I have saved the following person using the generic repository
		| FirstName | LastName |
		| Jonathan  | Stowell  |
	When I select all records using the generic repository
	Then the result set should contain 1 records
	And  the result set should contain Jonathan as a first name
	And  the result set should contain Stowell as a surname

Scenario: Insert Multiple Records
	Given I have created a person generic repository
	And I have saved the following people using the generic repository
		| FirstName | LastName |
		| Jonathan  | Stowell  |
		| Carl      | Saunders |
		| Tobin     | Saunders |
		| Kamen     | Staykov  |
	When I select all records using the generic repository
	Then the result set should contain 4 records
	And  the result set should contain Jonathan as a first name
	And  the result set should contain Stowell as a surname

Scenario: Delete Single Record
	Given I have created a person generic repository
	And I have saved the following people using the generic repository
		| FirstName | LastName |
		| Jonathan  | Stowell  |
		| Carl      | Saunders |
		| Tobin     | Saunders |
		| Kamen     | Staykov  |
	When I delete the following person using the generic repository
		| FirstName | LastName |
		| Tobin     | Saunders |
	Then the result set should contain 3 records
	And  the result set should not contain Tobin as a first name Saunders as a surname

Scenario: Delete Multiple Records
	Given I have created a person generic repository
	And I have saved the following people using the generic repository
		| FirstName | LastName |
		| Jonathan  | Stowell  |
		| Carl      | Saunders |
		| Tobin     | Saunders |
		| Kamen     | Staykov  |
	When I delete the following people using the generic repository
		| FirstName | LastName |
		| Tobin     | Saunders |
		| Kamen     | Staykov  |
	Then the result set should contain 2 records
	And  the result set should not contain Tobin as a first name Saunders as a surname
	And  the result set should not contain Kamen as a first name Staykov as a surname

Scenario: Select All Records
	Given I have created a person generic repository
	And I have saved the following people using the generic repository
		| FirstName | LastName |
		| Jonathan  | Stowell  |
		| Carl      | Saunders |
		| Tobin     | Saunders |
		| Kamen     | Staykov  |
	When I select all records using the generic repository
	Then the result set should contain 4 records
	And  the result set should contain Jonathan as a first name
	And  the result set should contain Stowell as a surname

Scenario: Select All Records Paged
	Given I have created a person generic repository
	And I have saved the following people using the generic repository
		| FirstName | LastName |
		| Jonathan  | Stowell  |
		| Carl      | Saunders |
		| Tobin     | Saunders |
		| Kamen     | Staykov  |
	When I select all records paged with a page size of 2 using the generic repository
	Then the result set should contain 2 pages
	And  the result set should contain 2 paged items
	And  the result set should contain 0 new items
	And  the result set should contain 4 total items
	And  the result set should contain the page number of 1
	And  the result set should contain the page size of 2
	And  the result set should not contain a previous page
	And  the result set should contain a next page
	And  the result set should be the first page
	And  the result set should not be the last page

Scenario: Update Single Record
	Given I have created a person generic repository
	And I have saved the following person using the generic repository
		| FirstName | LastName |
		| Jonathan  | Stowell  |
	When I update the record Jonathan, Stowell using the generic repository to:
		| FirstName | LastName |
		| Jon       | Stowell  |
	Then the result should be true
	And  when I query for Jon, Stowell with the generic repository they will exist