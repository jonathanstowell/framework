Feature: Read Only Generic Repository
	In order to create an application I need to access data
	I want to be able to select data

Scenario: Select All Records
	Given I have created a person read only repository
	And I have saved the following people using the read only repository
		| FirstName | LastName |
		| Jonathan  | Stowell  |
		| Carl      | Saunders |
		| Tobin     | Saunders |
		| Kamen     | Staykov  |
	When I select all records using the read only repository
	Then the result set should contain 4 records
	And  the result set should contain Jonathan as a first name
	And  the result set should contain Stowell as a surname