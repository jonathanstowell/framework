Feature: Read Only Generic Service Tests

Scenario: Select All Records
	Given I have created a person read only service
	And I have saved the following people using the read only service
		| FirstName | LastName |
		| Jonathan  | Stowell  |
		| Carl      | Saunders |
		| Tobin     | Saunders |
		| Kamen     | Staykov  |
	When I select all records using the read only service
	Then the result set should contain 4 records
	And  the result set should contain Jonathan as a first name
	And  the result set should contain Stowell as a surname