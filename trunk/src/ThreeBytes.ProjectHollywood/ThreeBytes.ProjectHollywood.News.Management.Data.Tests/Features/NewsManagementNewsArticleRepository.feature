Feature: NewsManagementNewsArticleRepository
	Data Access tests for NewsManagementNewsArticleRepository

Scenario: Create a News Management Article in a transaction
	Given I have a news management article with the properties
		| CreatedBy | Title		 | Content		|
		| Jonathan  | Test Title | Test Content |
	When I attempt to create the article in a transaction
	Then the repository result will be true
	And the article repository count should be 1
	And the Creator will be Jonathan
	And the Title will be Test Title
	And the Content will be Test Content

Scenario: Create several News Management Articles in a transaction
	Given I have several news management articles with the properties
		| CreatedBy | Title         | Content         |
		| Jonathan  | Test Title 1  | Test Content 1  |
		| Tobin     | Test Title 2  | Test Content 2  |
		| Carl      | Test Title 3  | Test Content 3  |
		| Sara      | Test Title 4  | Test Content 4  |
		| Dan       | Test Title 5  | Test Content 5  |
		| Jon       | Test Title 6  | Test Content 6  |
		| Emma      | Test Title 7  | Test Content 7  |
		| Sorcha    | Test Title 8  | Test Content 8  |
		| Joel      | Test Title 9  | Test Content 9  |
		| Dom       | Test Title 10 | Test Content 10 |
		| Laura     | Test Title 11 | Test Content 11 |
		| Sarah     | Test Title 12 | Test Content 12 |
		| Wayne     | Test Title 13 | Test Content 13 |
		| Eric      | Test Title 14 | Test Content 14 |
		| Gary      | Test Title 15 | Test Content 15 |
		| Peter     | Test Title 16 | Test Content 16 |
		| Julie     | Test Title 17 | Test Content 17 |
		| Mollie    | Test Title 18 | Test Content 18 |
		| George    | Test Title 19 | Test Content 19 |
		| Matthew   | Test Title 20 | Test Content 20 |
	When I attempt to create the articles in a transaction
	Then the repository result will be true
	And the article repository count should be 20
	And there should be an article created by Jonathan with the title Test Title 1 and the content Test Content 1
	And there should be an article created by Tobin with the title Test Title 2 and the content Test Content 2
	And there should be an article created by Carl with the title Test Title 3 and the content Test Content 3
	And there should be an article created by Sara with the title Test Title 4 and the content Test Content 4
	And there should be an article created by Dan with the title Test Title 5 and the content Test Content 5
	And there should be an article created by Jon with the title Test Title 6 and the content Test Content 6
	And there should be an article created by Emma with the title Test Title 7 and the content Test Content 7
	And there should be an article created by Sorcha with the title Test Title 8 and the content Test Content 8
	And there should be an article created by Joel with the title Test Title 9 and the content Test Content 9
	And there should be an article created by Dom with the title Test Title 10 and the content Test Content 10
	And there should be an article created by Laura with the title Test Title 11 and the content Test Content 11
	And there should be an article created by Sarah with the title Test Title 12 and the content Test Content 12
	And there should be an article created by Wayne with the title Test Title 13 and the content Test Content 13
	And there should be an article created by Eric with the title Test Title 14 and the content Test Content 14
	And there should be an article created by Gary with the title Test Title 15 and the content Test Content 15
	And there should be an article created by Peter with the title Test Title 16 and the content Test Content 16
	And there should be an article created by Julie with the title Test Title 17 and the content Test Content 17
	And there should be an article created by Mollie with the title Test Title 18 and the content Test Content 18
	And there should be an article created by George with the title Test Title 19 and the content Test Content 19
	And there should be an article created by Matthew with the title Test Title 20 and the content Test Content 20

Scenario: Create a News Management Article not in a transaction followed by Flushing Changes
	Given I have a news management article with the properties
		| CreatedBy | Title		 | Content		|
		| Jonathan  | Test Title | Test Content |
	When I attempt to create the article not in a transaction
	And I flush the changes
	Then the repository result will be true
	And the article repository count should be 1
	And the Creator will be Jonathan
	And the Title will be Test Title
	And the Content will be Test Content

Scenario: Create several News Management Article not in a transaction followed by Flushing Changes
	Given I have several news management articles with the properties
		| CreatedBy | Title         | Content         |
		| Jonathan  | Test Title 1  | Test Content 1  |
		| Tobin     | Test Title 2  | Test Content 2  |
		| Carl      | Test Title 3  | Test Content 3  |
		| Sara      | Test Title 4  | Test Content 4  |
		| Dan       | Test Title 5  | Test Content 5  |
		| Jon       | Test Title 6  | Test Content 6  |
		| Emma      | Test Title 7  | Test Content 7  |
		| Sorcha    | Test Title 8  | Test Content 8  |
		| Joel      | Test Title 9  | Test Content 9  |
		| Dom       | Test Title 10 | Test Content 10 |
		| Laura     | Test Title 11 | Test Content 11 |
		| Sarah     | Test Title 12 | Test Content 12 |
		| Wayne     | Test Title 13 | Test Content 13 |
		| Eric      | Test Title 14 | Test Content 14 |
		| Gary      | Test Title 15 | Test Content 15 |
		| Peter     | Test Title 16 | Test Content 16 |
		| Julie     | Test Title 17 | Test Content 17 |
		| Mollie    | Test Title 18 | Test Content 18 |
		| George    | Test Title 19 | Test Content 19 |
		| Matthew   | Test Title 20 | Test Content 20 |
	When I attempt to create the articles not in a transaction
	And I flush the changes
	Then the repository result will be true
	And the article repository count should be 20
	And there should be an article created by Jonathan with the title Test Title 1 and the content Test Content 1
	And there should be an article created by Tobin with the title Test Title 2 and the content Test Content 2
	And there should be an article created by Carl with the title Test Title 3 and the content Test Content 3
	And there should be an article created by Sara with the title Test Title 4 and the content Test Content 4
	And there should be an article created by Dan with the title Test Title 5 and the content Test Content 5
	And there should be an article created by Jon with the title Test Title 6 and the content Test Content 6
	And there should be an article created by Emma with the title Test Title 7 and the content Test Content 7
	And there should be an article created by Sorcha with the title Test Title 8 and the content Test Content 8
	And there should be an article created by Joel with the title Test Title 9 and the content Test Content 9
	And there should be an article created by Dom with the title Test Title 10 and the content Test Content 10
	And there should be an article created by Laura with the title Test Title 11 and the content Test Content 11
	And there should be an article created by Sarah with the title Test Title 12 and the content Test Content 12
	And there should be an article created by Wayne with the title Test Title 13 and the content Test Content 13
	And there should be an article created by Eric with the title Test Title 14 and the content Test Content 14
	And there should be an article created by Gary with the title Test Title 15 and the content Test Content 15
	And there should be an article created by Peter with the title Test Title 16 and the content Test Content 16
	And there should be an article created by Julie with the title Test Title 17 and the content Test Content 17
	And there should be an article created by Mollie with the title Test Title 18 and the content Test Content 18
	And there should be an article created by George with the title Test Title 19 and the content Test Content 19
	And there should be an article created by Matthew with the title Test Title 20 and the content Test Content 20

Scenario: Create a News Management Article not in a transaction
	Given I have a news management article with the properties
		| CreatedBy | Title		 | Content		|
		| Jonathan  | Test Title | Test Content |
	When I attempt to create the article not in a transaction
	Then the article repository count should be 0
	And the repository result will be true

Scenario: Create several News Management Articles not in a transaction
	Given I have several news management articles with the properties
		| CreatedBy | Title         | Content         |
		| Jonathan  | Test Title 1  | Test Content 1  |
		| Tobin     | Test Title 2  | Test Content 2  |
		| Carl      | Test Title 3  | Test Content 3  |
		| Sara      | Test Title 4  | Test Content 4  |
		| Dan       | Test Title 5  | Test Content 5  |
		| Jon       | Test Title 6  | Test Content 6  |
		| Emma      | Test Title 7  | Test Content 7  |
		| Sorcha    | Test Title 8  | Test Content 8  |
		| Joel      | Test Title 9  | Test Content 9  |
		| Dom       | Test Title 10 | Test Content 10 |
		| Laura     | Test Title 11 | Test Content 11 |
		| Sarah     | Test Title 12 | Test Content 12 |
		| Wayne     | Test Title 13 | Test Content 13 |
		| Eric      | Test Title 14 | Test Content 14 |
		| Gary      | Test Title 15 | Test Content 15 |
		| Peter     | Test Title 16 | Test Content 16 |
		| Julie     | Test Title 17 | Test Content 17 |
		| Mollie    | Test Title 18 | Test Content 18 |
		| George    | Test Title 19 | Test Content 19 |
		| Matthew   | Test Title 20 | Test Content 20 |
	When I attempt to create the articles not in a transaction
	Then the repository result will be true
	And the article repository count should be 0

Scenario: Create a News Management Article in a transaction with a null CreatedBy Property
	Given I have a news management article with the properties
		| CreatedBy | Title		 | Content		|
		| null      | Test Title | Test Content |
	When I attempt to create the article in a transaction
	Then the article repository count should be 0
	And the repository result will be false

Scenario: Create several News Management Articles in a transaction with some having a null CreatedBy Property
	Given I have several news management articles with the properties
		| CreatedBy | Title         | Content         |
		| Jonathan  | Test Title 1  | Test Content 1  |
		| Tobin     | Test Title 2  | Test Content 2  |
		| Carl      | Test Title 3  | Test Content 3  |
		| Sara      | Test Title 4  | Test Content 4  |
		| Dan       | Test Title 5  | Test Content 5  |
		| Jon       | Test Title 6  | Test Content 6  |
		| Emma      | Test Title 7  | Test Content 7  |
		| Sorcha    | Test Title 8  | Test Content 8  |
		| null      | Test Title 9  | Test Content 9  |
		| null      | Test Title 10 | Test Content 10 |
		| Laura     | Test Title 11 | Test Content 11 |
		| Sarah     | Test Title 12 | Test Content 12 |
		| Wayne     | Test Title 13 | Test Content 13 |
		| Eric      | Test Title 14 | Test Content 14 |
		| Gary      | Test Title 15 | Test Content 15 |
		| Peter     | Test Title 16 | Test Content 16 |
		| Julie     | Test Title 17 | Test Content 17 |
		| Mollie    | Test Title 18 | Test Content 18 |
		| George    | Test Title 19 | Test Content 19 |
		| Matthew   | Test Title 20 | Test Content 20 |
	When I attempt to create the articles in a transaction
	Then the repository result will be false
	And the article repository count should be 0

Scenario: Create a News Management Article in a transaction with a null Title Property
	Given I have a news management article with the properties
		| CreatedBy | Title | Content      |
		| Jonathan  | null  | Test Content |
	When I attempt to create the article in a transaction
	Then the article repository count should be 0
	And the repository result will be false

Scenario: Create several News Management Articles in a transaction with some having a null Title Property
	Given I have several news management articles with the properties
		| CreatedBy | Title         | Content         |
		| Jonathan  | Test Title 1  | Test Content 1  |
		| Tobin     | Test Title 2  | Test Content 2  |
		| Carl      | Test Title 3  | Test Content 3  |
		| Sara      | Test Title 4  | Test Content 4  |
		| Dan       | Test Title 5  | Test Content 5  |
		| Jon       | Test Title 6  | Test Content 6  |
		| Emma      | Test Title 7  | Test Content 7  |
		| Sorcha    | null          | Test Content 8  |
		| Joel      | null          | Test Content 9  |
		| Dom       | Test Title 10 | Test Content 10 |
		| Laura     | Test Title 11 | Test Content 11 |
		| Sarah     | Test Title 12 | Test Content 12 |
		| Wayne     | Test Title 13 | Test Content 13 |
		| Eric      | Test Title 14 | Test Content 14 |
		| Gary      | Test Title 15 | Test Content 15 |
		| Peter     | Test Title 16 | Test Content 16 |
		| Julie     | Test Title 17 | Test Content 17 |
		| Mollie    | Test Title 18 | Test Content 18 |
		| George    | Test Title 19 | Test Content 19 |
		| Matthew   | Test Title 20 | Test Content 20 |
	When I attempt to create the articles in a transaction
	Then the repository result will be false
	And the article repository count should be 0

Scenario: Create a News Management Article in a transaction with a null Content Property
	Given I have a news management article with the properties
		| CreatedBy | Title      | Content |
		| Jonathan  | Test Title | null    |
	When I attempt to create the article in a transaction
	Then the article repository count should be 0
	And the repository result will be false

Scenario: Create several News Management Articles in a transaction with some having a null Content Property
	Given I have several news management articles with the properties
		| CreatedBy | Title         | Content         |
		| Jonathan  | Test Title 1  | Test Content 1  |
		| Tobin     | Test Title 2  | Test Content 2  |
		| Carl      | Test Title 3  | Test Content 3  |
		| Sara      | Test Title 4  | Test Content 4  |
		| Dan       | Test Title 5  | Test Content 5  |
		| Jon       | Test Title 6  | Test Content 6  |
		| Emma      | Test Title 7  | Test Content 7  |
		| Sorcha    | Test Title 8  | Test Content 8  |
		| Joel      | Test Title 9  | null            |
		| Dom       | Test Title 10 | null            |
		| Laura     | Test Title 11 | Test Content 11 |
		| Sarah     | Test Title 12 | Test Content 12 |
		| Wayne     | Test Title 13 | Test Content 13 |
		| Eric      | Test Title 14 | Test Content 14 |
		| Gary      | Test Title 15 | Test Content 15 |
		| Peter     | Test Title 16 | Test Content 16 |
		| Julie     | Test Title 17 | Test Content 17 |
		| Mollie    | Test Title 18 | Test Content 18 |
		| George    | Test Title 19 | Test Content 19 |
		| Matthew   | Test Title 20 | Test Content 20 |
	When I attempt to create the articles in a transaction
	Then the repository result will be false
	And the article repository count should be 0

Scenario: Update a News Management Article in a transaction
	Given I have a saved news management article with the properties
		| CreatedBy | Title		 | Content		|
		| Jonathan  | Test Title | Test Content |
	When I update the news management article to the values below in a transaction
		| CreatedBy | Title		 | Content	   |
		| Tobin     | New Title  | New Content |
	Then the Creator will be Tobin
	And the Title will be New Title
	And the Content will be New Content
	And the repository result will be true

Scenario: Update several News Management Articles in a transaction
	Given I have several saved news management articles with the properties
		| CreatedBy | Title         | Content         |
		| Jonathan  | Test Title 1  | Test Content 1  |
		| Tobin     | Test Title 2  | Test Content 2  |
		| Carl      | Test Title 3  | Test Content 3  |
		| Sara      | Test Title 4  | Test Content 4  |
		| Dan       | Test Title 5  | Test Content 5  |
		| Jon       | Test Title 6  | Test Content 6  |
		| Emma      | Test Title 7  | Test Content 7  |
		| Sorcha    | Test Title 8  | Test Content 8  |
		| Joel      | Test Title 9  | Test Content 9  |
		| Dom       | Test Title 10 | Test Content 10 |
		| Laura     | Test Title 11 | Test Content 11 |
		| Sarah     | Test Title 12 | Test Content 12 |
		| Wayne     | Test Title 13 | Test Content 13 |
		| Eric      | Test Title 14 | Test Content 14 |
		| Gary      | Test Title 15 | Test Content 15 |
		| Peter     | Test Title 16 | Test Content 16 |
		| Julie     | Test Title 17 | Test Content 17 |
		| Mollie    | Test Title 18 | Test Content 18 |
		| George    | Test Title 19 | Test Content 19 |
		| Matthew   | Test Title 20 | Test Content 20 |
	When I update the news management articles to the values below in a transaction using Created By as the identifier
		| CreatedBy | Title          | Content          |
		| Jonathan  | Test Title 10  | Test Content 10  |
		| Tobin     | Test Title 20  | Test Content 20  |
		| Carl      | Test Title 30  | Test Content 30  |
		| Sara      | Test Title 40  | Test Content 40  |
		| Dan       | Test Title 50  | Test Content 50  |
		| Jon       | Test Title 60  | Test Content 60  |
		| Emma      | Test Title 70  | Test Content 70  |
		| Sorcha    | Test Title 80  | Test Content 80  |
		| Joel      | Test Title 90  | Test Content 90  |
		| Dom       | Test Title 100 | Test Content 100 |
		| Laura     | Test Title 110 | Test Content 110 |
		| Sarah     | Test Title 120 | Test Content 120 |
		| Wayne     | Test Title 130 | Test Content 130 |
		| Eric      | Test Title 140 | Test Content 140 |
		| Gary      | Test Title 150 | Test Content 150 |
		| Peter     | Test Title 160 | Test Content 160 |
		| Julie     | Test Title 170 | Test Content 170 |
		| Mollie    | Test Title 180 | Test Content 180 |
		| George    | Test Title 190 | Test Content 190 |
		| Matthew   | Test Title 200 | Test Content 200 |
	Then the repository result will be true
	And the article repository count should be 20
	And there should be an article created by Jonathan with the title Test Title 10 and the content Test Content 10
	And there should be an article created by Tobin with the title Test Title 20 and the content Test Content 20
	And there should be an article created by Carl with the title Test Title 30 and the content Test Content 30
	And there should be an article created by Sara with the title Test Title 40 and the content Test Content 40
	And there should be an article created by Dan with the title Test Title 50 and the content Test Content 50
	And there should be an article created by Jon with the title Test Title 60 and the content Test Content 60
	And there should be an article created by Emma with the title Test Title 70 and the content Test Content 70
	And there should be an article created by Sorcha with the title Test Title 80 and the content Test Content 80
	And there should be an article created by Joel with the title Test Title 90 and the content Test Content 90
	And there should be an article created by Dom with the title Test Title 100 and the content Test Content 100
	And there should be an article created by Laura with the title Test Title 110 and the content Test Content 110
	And there should be an article created by Sarah with the title Test Title 120 and the content Test Content 120
	And there should be an article created by Wayne with the title Test Title 130 and the content Test Content 130
	And there should be an article created by Eric with the title Test Title 140 and the content Test Content 140
	And there should be an article created by Gary with the title Test Title 150 and the content Test Content 150
	And there should be an article created by Peter with the title Test Title 160 and the content Test Content 160
	And there should be an article created by Julie with the title Test Title 170 and the content Test Content 170
	And there should be an article created by Mollie with the title Test Title 180 and the content Test Content 180
	And there should be an article created by George with the title Test Title 190 and the content Test Content 190
	And there should be an article created by Matthew with the title Test Title 200 and the content Test Content 200

Scenario: Update a News Management Article not in a transaction followed by Flushing Changes
	Given I have a saved news management article with the properties
		| CreatedBy | Title		 | Content		|
		| Jonathan  | Test Title | Test Content |
	When I update the news management article to the values below not in a transaction
		| CreatedBy | Title		 | Content	   |
		| Tobin     | New Title  | New Content |
	And I flush the changes
	Then the Creator will be Tobin
	And the Title will be New Title
	And the Content will be New Content
	And the repository result will be true

Scenario: Update several News Management Articles not in a transaction followed by Flushing Changes
	Given I have several saved news management articles with the properties
		| CreatedBy | Title         | Content         |
		| Jonathan  | Test Title 1  | Test Content 1  |
		| Tobin     | Test Title 2  | Test Content 2  |
		| Carl      | Test Title 3  | Test Content 3  |
		| Sara      | Test Title 4  | Test Content 4  |
		| Dan       | Test Title 5  | Test Content 5  |
		| Jon       | Test Title 6  | Test Content 6  |
		| Emma      | Test Title 7  | Test Content 7  |
		| Sorcha    | Test Title 8  | Test Content 8  |
		| Joel      | Test Title 9  | Test Content 9  |
		| Dom       | Test Title 10 | Test Content 10 |
		| Laura     | Test Title 11 | Test Content 11 |
		| Sarah     | Test Title 12 | Test Content 12 |
		| Wayne     | Test Title 13 | Test Content 13 |
		| Eric      | Test Title 14 | Test Content 14 |
		| Gary      | Test Title 15 | Test Content 15 |
		| Peter     | Test Title 16 | Test Content 16 |
		| Julie     | Test Title 17 | Test Content 17 |
		| Mollie    | Test Title 18 | Test Content 18 |
		| George    | Test Title 19 | Test Content 19 |
		| Matthew   | Test Title 20 | Test Content 20 |
	When I update the news management articles to the values below not in a transaction using Created By as the identifier
		| CreatedBy | Title          | Content          |
		| Jonathan  | Test Title 10  | Test Content 10  |
		| Tobin     | Test Title 20  | Test Content 20  |
		| Carl      | Test Title 30  | Test Content 30  |
		| Sara      | Test Title 40  | Test Content 40  |
		| Dan       | Test Title 50  | Test Content 50  |
		| Jon       | Test Title 60  | Test Content 60  |
		| Emma      | Test Title 70  | Test Content 70  |
		| Sorcha    | Test Title 80  | Test Content 80  |
		| Joel      | Test Title 90  | Test Content 90  |
		| Dom       | Test Title 100 | Test Content 100 |
		| Laura     | Test Title 110 | Test Content 110 |
		| Sarah     | Test Title 120 | Test Content 120 |
		| Wayne     | Test Title 130 | Test Content 130 |
		| Eric      | Test Title 140 | Test Content 140 |
		| Gary      | Test Title 150 | Test Content 150 |
		| Peter     | Test Title 160 | Test Content 160 |
		| Julie     | Test Title 170 | Test Content 170 |
		| Mollie    | Test Title 180 | Test Content 180 |
		| George    | Test Title 190 | Test Content 190 |
		| Matthew   | Test Title 200 | Test Content 200 |
	And I flush the changes
	Then the repository result will be true
	And the article repository count should be 20
	And there should be an article created by Jonathan with the title Test Title 10 and the content Test Content 10
	And there should be an article created by Tobin with the title Test Title 20 and the content Test Content 20
	And there should be an article created by Carl with the title Test Title 30 and the content Test Content 30
	And there should be an article created by Sara with the title Test Title 40 and the content Test Content 40
	And there should be an article created by Dan with the title Test Title 50 and the content Test Content 50
	And there should be an article created by Jon with the title Test Title 60 and the content Test Content 60
	And there should be an article created by Emma with the title Test Title 70 and the content Test Content 70
	And there should be an article created by Sorcha with the title Test Title 80 and the content Test Content 80
	And there should be an article created by Joel with the title Test Title 90 and the content Test Content 90
	And there should be an article created by Dom with the title Test Title 100 and the content Test Content 100
	And there should be an article created by Laura with the title Test Title 110 and the content Test Content 110
	And there should be an article created by Sarah with the title Test Title 120 and the content Test Content 120
	And there should be an article created by Wayne with the title Test Title 130 and the content Test Content 130
	And there should be an article created by Eric with the title Test Title 140 and the content Test Content 140
	And there should be an article created by Gary with the title Test Title 150 and the content Test Content 150
	And there should be an article created by Peter with the title Test Title 160 and the content Test Content 160
	And there should be an article created by Julie with the title Test Title 170 and the content Test Content 170
	And there should be an article created by Mollie with the title Test Title 180 and the content Test Content 180
	And there should be an article created by George with the title Test Title 190 and the content Test Content 190
	And there should be an article created by Matthew with the title Test Title 200 and the content Test Content 200

Scenario: Update a Invalid News Management Article in a transaction
	Given I have a saved news management article with the properties
		| CreatedBy | Title		 | Content		|
		| Jonathan  | Test Title | Test Content |
	When I update the news management article to the values below in a transaction
		| CreatedBy | Title		 | Content	   |
		| null      | New Title  | New Content |
	Then the Creator will be Jonathan
	And the Title will be Test Title
	And the Content will be Test Content
	And the repository result will be true
	And the unit of work result will be false

Scenario: Update several Invalid News Management Articles in a transaction
	Given I have several saved news management articles with the properties
		| CreatedBy | Title         | Content         |
		| Jonathan  | Test Title 1  | Test Content 1  |
		| Tobin     | Test Title 2  | Test Content 2  |
		| Carl      | Test Title 3  | Test Content 3  |
		| Sara      | Test Title 4  | Test Content 4  |
		| Dan       | Test Title 5  | Test Content 5  |
		| Jon       | Test Title 6  | Test Content 6  |
		| Emma      | Test Title 7  | Test Content 7  |
		| Sorcha    | Test Title 8  | Test Content 8  |
		| Joel      | Test Title 9  | Test Content 9  |
		| Dom       | Test Title 10 | Test Content 10 |
		| Laura     | Test Title 11 | Test Content 11 |
		| Sarah     | Test Title 12 | Test Content 12 |
		| Wayne     | Test Title 13 | Test Content 13 |
		| Eric      | Test Title 14 | Test Content 14 |
		| Gary      | Test Title 15 | Test Content 15 |
		| Peter     | Test Title 16 | Test Content 16 |
		| Julie     | Test Title 17 | Test Content 17 |
		| Mollie    | Test Title 18 | Test Content 18 |
		| George    | Test Title 19 | Test Content 19 |
		| Matthew   | Test Title 20 | Test Content 20 |
	When I update the news management articles to the values below in a transaction using Created By as the identifier
		| CreatedBy | Title          | Content         |
		| Jonathan  | Test Title 10  | Test Content 10 |
		| Tobin     | Test Title 20  | Test Content 20 |
		| Carl      | Test Title 30  | Test Content 30 |
		| Sara      | Test Title 40  | Test Content 40 |
		| Dan       | Test Title 50  | Test Content 50 |
		| Jon       | Test Title 60  | Test Content 60 |
		| Emma      | Test Title 70  | Test Content 70 |
		| Sorcha    | Test Title 80  | Test Content 80 |
		| Joel      | null           | Test Content 90 |
		| Dom       | null           | Test Content 100 |
		| Laura     | Test Title 110 | Test Content 110 |
		| Sarah     | Test Title 120 | Test Content 120 |
		| Wayne     | Test Title 130 | Test Content 130 |
		| Eric      | Test Title 140 | Test Content 140 |
		| Gary      | Test Title 150 | Test Content 150 |
		| Peter     | Test Title 160 | Test Content 160 |
		| Julie     | Test Title 170 | Test Content 170 |
		| Mollie    | Test Title 180 | Test Content 180 |
		| George    | Test Title 190 | Test Content 190 |
		| Matthew   | Test Title 200 | Test Content 200 |
	Then the repository result will be true
	And the unit of work result will be false
	And the article repository count should be 20
	And there should be an article created by Jonathan with the title Test Title 1 and the content Test Content 1
	And there should be an article created by Tobin with the title Test Title 2 and the content Test Content 2
	And there should be an article created by Carl with the title Test Title 3 and the content Test Content 3
	And there should be an article created by Sara with the title Test Title 4 and the content Test Content 4
	And there should be an article created by Dan with the title Test Title 5 and the content Test Content 5
	And there should be an article created by Jon with the title Test Title 6 and the content Test Content 6
	And there should be an article created by Emma with the title Test Title 7 and the content Test Content 7
	And there should be an article created by Sorcha with the title Test Title 8 and the content Test Content 8
	And there should be an article created by Joel with the title Test Title 9 and the content Test Content 9
	And there should be an article created by Dom with the title Test Title 10 and the content Test Content 10
	And there should be an article created by Laura with the title Test Title 11 and the content Test Content 11
	And there should be an article created by Sarah with the title Test Title 12 and the content Test Content 12
	And there should be an article created by Wayne with the title Test Title 13 and the content Test Content 13
	And there should be an article created by Eric with the title Test Title 14 and the content Test Content 14
	And there should be an article created by Gary with the title Test Title 15 and the content Test Content 15
	And there should be an article created by Peter with the title Test Title 16 and the content Test Content 16
	And there should be an article created by Julie with the title Test Title 17 and the content Test Content 17
	And there should be an article created by Mollie with the title Test Title 18 and the content Test Content 18
	And there should be an article created by George with the title Test Title 19 and the content Test Content 19
	And there should be an article created by Matthew with the title Test Title 20 and the content Test Content 20

Scenario: Update a Invalid News Management Article not in a transaction followed by Flushing Changes
	Given I have a saved news management article with the properties
		| CreatedBy | Title		 | Content		|
		| Jonathan  | Test Title | Test Content |
	When I update the news management article to the values below not in a transaction
		| CreatedBy | Title		 | Content	   |
		| null      | New Title  | New Content |
	And I flush the changes
	Then the Creator will be Jonathan
	And the Title will be Test Title
	And the Content will be Test Content
	And the repository result will be false

Scenario: Update several Invalid News Management Articles not in a transaction followed by Flushing Changes
	Given I have several saved news management articles with the properties
		| CreatedBy | Title         | Content         |
		| Jonathan  | Test Title 1  | Test Content 1  |
		| Tobin     | Test Title 2  | Test Content 2  |
		| Carl      | Test Title 3  | Test Content 3  |
		| Sara      | Test Title 4  | Test Content 4  |
		| Dan       | Test Title 5  | Test Content 5  |
		| Jon       | Test Title 6  | Test Content 6  |
		| Emma      | Test Title 7  | Test Content 7  |
		| Sorcha    | Test Title 8  | Test Content 8  |
		| Joel      | Test Title 9  | Test Content 9  |
		| Dom       | Test Title 10 | Test Content 10 |
		| Laura     | Test Title 11 | Test Content 11 |
		| Sarah     | Test Title 12 | Test Content 12 |
		| Wayne     | Test Title 13 | Test Content 13 |
		| Eric      | Test Title 14 | Test Content 14 |
		| Gary      | Test Title 15 | Test Content 15 |
		| Peter     | Test Title 16 | Test Content 16 |
		| Julie     | Test Title 17 | Test Content 17 |
		| Mollie    | Test Title 18 | Test Content 18 |
		| George    | Test Title 19 | Test Content 19 |
		| Matthew   | Test Title 20 | Test Content 20 |
	When I update the news management articles to the values below not in a transaction using Created By as the identifier
		| CreatedBy | Title          | Content          |
		| Jonathan  | Test Title 10  | Test Content 10  |
		| Tobin     | Test Title 20  | Test Content 20  |
		| Carl      | Test Title 30  | Test Content 30  |
		| Sara      | Test Title 40  | Test Content 40  |
		| Dan       | Test Title 50  | Test Content 50  |
		| Jon       | Test Title 60  | Test Content 60  |
		| Emma      | Test Title 70  | Test Content 70  |
		| Sorcha    | Test Title 80  | Test Content 80  |
		| Joel      | null			 | Test Content 90  |
		| Dom       | null			 | Test Content 100 |
		| Laura     | Test Title 110 | Test Content 110 |
		| Sarah     | Test Title 120 | Test Content 120 |
		| Wayne     | Test Title 130 | Test Content 130 |
		| Eric      | Test Title 140 | Test Content 140 |
		| Gary      | Test Title 150 | Test Content 150 |
		| Peter     | Test Title 160 | Test Content 160 |
		| Julie     | Test Title 170 | Test Content 170 |
		| Mollie    | Test Title 180 | Test Content 180 |
		| George    | Test Title 190 | Test Content 190 |
		| Matthew   | Test Title 200 | Test Content 200 |
	And I flush the changes
	Then the repository result will be false
	And the article repository count should be 20
	And there should be an article created by Jonathan with the title Test Title 1 and the content Test Content 1
	And there should be an article created by Tobin with the title Test Title 2 and the content Test Content 2
	And there should be an article created by Carl with the title Test Title 3 and the content Test Content 3
	And there should be an article created by Sara with the title Test Title 4 and the content Test Content 4
	And there should be an article created by Dan with the title Test Title 5 and the content Test Content 5
	And there should be an article created by Jon with the title Test Title 6 and the content Test Content 6
	And there should be an article created by Emma with the title Test Title 7 and the content Test Content 7
	And there should be an article created by Sorcha with the title Test Title 8 and the content Test Content 8
	And there should be an article created by Joel with the title Test Title 9 and the content Test Content 9
	And there should be an article created by Dom with the title Test Title 10 and the content Test Content 10
	And there should be an article created by Laura with the title Test Title 11 and the content Test Content 11
	And there should be an article created by Sarah with the title Test Title 12 and the content Test Content 12
	And there should be an article created by Wayne with the title Test Title 13 and the content Test Content 13
	And there should be an article created by Eric with the title Test Title 14 and the content Test Content 14
	And there should be an article created by Gary with the title Test Title 15 and the content Test Content 15
	And there should be an article created by Peter with the title Test Title 16 and the content Test Content 16
	And there should be an article created by Julie with the title Test Title 17 and the content Test Content 17
	And there should be an article created by Mollie with the title Test Title 18 and the content Test Content 18
	And there should be an article created by George with the title Test Title 19 and the content Test Content 19
	And there should be an article created by Matthew with the title Test Title 20 and the content Test Content 20

Scenario: Delete a null News Management Article in a transaction
	Given I have a null news management article
	When I attempt to delete the article in a transaction
	Then the article repository count should be 0
	And the repository result will be false

Scenario: Delete several null News Management Articles in a transaction
	Given I have several null news management articles
	When I attempt to delete the articles in a transaction
	Then the article repository count should be 0
	And the repository result will be false

Scenario: Delete a News Management Article in a transaction
	Given I have a saved news management article with the properties
		| CreatedBy | Title | Content |
		| Jonathan  | Test Title | Test Content |
	When I attempt to delete the article in a transaction
	Then the article repository count should be 0
	And the repository result will be true

Scenario: Delete several News Management Articles in a transaction
	Given I have several saved news management articles with the properties
		| CreatedBy | Title         | Content         |
		| Jonathan  | Test Title 1  | Test Content 1  |
		| Tobin     | Test Title 2  | Test Content 2  |
		| Carl      | Test Title 3  | Test Content 3  |
		| Sara      | Test Title 4  | Test Content 4  |
		| Dan       | Test Title 5  | Test Content 5  |
		| Jon       | Test Title 6  | Test Content 6  |
		| Emma      | Test Title 7  | Test Content 7  |
		| Sorcha    | Test Title 8  | Test Content 8  |
		| Joel      | Test Title 9  | Test Content 9  |
		| Dom       | Test Title 10 | Test Content 10 |
		| Laura     | Test Title 11 | Test Content 11 |
		| Sarah     | Test Title 12 | Test Content 12 |
		| Wayne     | Test Title 13 | Test Content 13 |
		| Eric      | Test Title 14 | Test Content 14 |
		| Gary      | Test Title 15 | Test Content 15 |
		| Peter     | Test Title 16 | Test Content 16 |
		| Julie     | Test Title 17 | Test Content 17 |
		| Mollie    | Test Title 18 | Test Content 18 |
		| George    | Test Title 19 | Test Content 19 |
		| Matthew   | Test Title 20 | Test Content 20 |
	When I attempt to delete the articles in a transaction
	Then the repository result will be true
	And the article repository count should be 0

Scenario: Delete a News Management Article not in a transaction followed by Flushing Changes
	Given I have a saved news management article with the properties
		| CreatedBy | Title		 | Content		|
		| Jonathan  | Test Title | Test Content |
	When I attempt to delete the article not in a transaction
	And I flush the changes
	Then the repository result will be true
	And the article repository count should be 0

Scenario: Delete several News Management Articles not in a transaction followed by Flushing Changes
	Given I have several saved news management articles with the properties
		| CreatedBy | Title         | Content         |
		| Jonathan  | Test Title 1  | Test Content 1  |
		| Tobin     | Test Title 2  | Test Content 2  |
		| Carl      | Test Title 3  | Test Content 3  |
		| Sara      | Test Title 4  | Test Content 4  |
		| Dan       | Test Title 5  | Test Content 5  |
		| Jon       | Test Title 6  | Test Content 6  |
		| Emma      | Test Title 7  | Test Content 7  |
		| Sorcha    | Test Title 8  | Test Content 8  |
		| Joel      | Test Title 9  | Test Content 9  |
		| Dom       | Test Title 10 | Test Content 10 |
		| Laura     | Test Title 11 | Test Content 11 |
		| Sarah     | Test Title 12 | Test Content 12 |
		| Wayne     | Test Title 13 | Test Content 13 |
		| Eric      | Test Title 14 | Test Content 14 |
		| Gary      | Test Title 15 | Test Content 15 |
		| Peter     | Test Title 16 | Test Content 16 |
		| Julie     | Test Title 17 | Test Content 17 |
		| Mollie    | Test Title 18 | Test Content 18 |
		| George    | Test Title 19 | Test Content 19 |
		| Matthew   | Test Title 20 | Test Content 20 |
	When I attempt to delete the articles not in a transaction
	And I flush the changes
	Then the repository result will be true
	And the article repository count should be 0

Scenario: Delete a News Management Article not in a transaction
	Given I have a saved news management article with the properties
		| CreatedBy | Title		 | Content		|
		| Jonathan  | Test Title | Test Content |
	When I attempt to delete the article not in a transaction
	Then the repository result will be true
	And the article repository count should be 1

Scenario: Delete several News Management Articles not in a transaction
	Given I have several saved news management articles with the properties
		| CreatedBy | Title         | Content         |
		| Jonathan  | Test Title 1  | Test Content 1  |
		| Tobin     | Test Title 2  | Test Content 2  |
		| Carl      | Test Title 3  | Test Content 3  |
		| Sara      | Test Title 4  | Test Content 4  |
		| Dan       | Test Title 5  | Test Content 5  |
		| Jon       | Test Title 6  | Test Content 6  |
		| Emma      | Test Title 7  | Test Content 7  |
		| Sorcha    | Test Title 8  | Test Content 8  |
		| Joel      | Test Title 9  | Test Content 9  |
		| Dom       | Test Title 10 | Test Content 10 |
		| Laura     | Test Title 11 | Test Content 11 |
		| Sarah     | Test Title 12 | Test Content 12 |
		| Wayne     | Test Title 13 | Test Content 13 |
		| Eric      | Test Title 14 | Test Content 14 |
		| Gary      | Test Title 15 | Test Content 15 |
		| Peter     | Test Title 16 | Test Content 16 |
		| Julie     | Test Title 17 | Test Content 17 |
		| Mollie    | Test Title 18 | Test Content 18 |
		| George    | Test Title 19 | Test Content 19 |
		| Matthew   | Test Title 20 | Test Content 20 |
	When I attempt to delete the articles not in a transaction
	Then the repository result will be true
	And the article repository count should be 20

Scenario: Valid Query Is News Article Created By
	Given I have a saved news management article with the properties
		| CreatedBy | Title		 | Content		|
		| Jonathan  | Test Title | Test Content |
	When I query whether the news article was created by Jonathan
	Then the repository result will be true

Scenario: Invalid Query Is News Article Created By
	Given I have a saved news management article with the properties
		| CreatedBy | Title		 | Content		|
		| Jonathan  | Test Title | Test Content |
	When I query whether the news article was created by Tobin
	Then the repository result will be false

Scenario: Get All News Management Articles When There is only one Item
	Given I have a saved news management article with the properties
		| CreatedBy | Title         | Content         |
		| Jonathan  | Test Title 1  | Test Content 1  |
	When I get all articles
	Then the article list result should contain 1 items
	And there should be an article in the list created by Jonathan with the title Test Title 1 and the content Test Content 1

Scenario: Get All News Management Articles When No Articles Exist
	Given I have no saved news management articles
	When I get all articles
	Then the article list result should contain 0 items

Scenario: Get All News Management Articles
	Given I have several saved news management articles with the properties
		| CreatedBy | Title         | Content         |
		| Jonathan  | Test Title 1  | Test Content 1  |
		| Tobin     | Test Title 2  | Test Content 2  |
		| Carl      | Test Title 3  | Test Content 3  |
		| Sara      | Test Title 4  | Test Content 4  |
		| Dan       | Test Title 5  | Test Content 5  |
		| Jon       | Test Title 6  | Test Content 6  |
		| Emma      | Test Title 7  | Test Content 7  |
		| Sorcha    | Test Title 8  | Test Content 8  |
		| Joel      | Test Title 9  | Test Content 9  |
		| Dom       | Test Title 10 | Test Content 10 |
		| Laura     | Test Title 11 | Test Content 11 |
		| Sarah     | Test Title 12 | Test Content 12 |
		| Wayne     | Test Title 13 | Test Content 13 |
		| Eric      | Test Title 14 | Test Content 14 |
		| Gary      | Test Title 15 | Test Content 15 |
		| Peter     | Test Title 16 | Test Content 16 |
		| Julie     | Test Title 17 | Test Content 17 |
		| Mollie    | Test Title 18 | Test Content 18 |
		| George    | Test Title 19 | Test Content 19 |
		| Matthew   | Test Title 20 | Test Content 20 |
	When I get all articles
	Then the article list result should contain 20 items
	And there should be an article in the list created by Jonathan with the title Test Title 1 and the content Test Content 1
	And there should be an article in the list created by Tobin with the title Test Title 2 and the content Test Content 2
	And there should be an article in the list created by Carl with the title Test Title 3 and the content Test Content 3
	And there should be an article in the list created by Sara with the title Test Title 4 and the content Test Content 4
	And there should be an article in the list created by Dan with the title Test Title 5 and the content Test Content 5
	And there should be an article in the list created by Jon with the title Test Title 6 and the content Test Content 6
	And there should be an article in the list created by Emma with the title Test Title 7 and the content Test Content 7
	And there should be an article in the list created by Sorcha with the title Test Title 8 and the content Test Content 8
	And there should be an article in the list created by Joel with the title Test Title 9 and the content Test Content 9
	And there should be an article in the list created by Dom with the title Test Title 10 and the content Test Content 10
	And there should be an article in the list created by Laura with the title Test Title 11 and the content Test Content 11
	And there should be an article in the list created by Sarah with the title Test Title 12 and the content Test Content 12
	And there should be an article in the list created by Wayne with the title Test Title 13 and the content Test Content 13
	And there should be an article in the list created by Eric with the title Test Title 14 and the content Test Content 14
	And there should be an article in the list created by Gary with the title Test Title 15 and the content Test Content 15
	And there should be an article in the list created by Peter with the title Test Title 16 and the content Test Content 16
	And there should be an article in the list created by Julie with the title Test Title 17 and the content Test Content 17
	And there should be an article in the list created by Mollie with the title Test Title 18 and the content Test Content 18
	And there should be an article in the list created by George with the title Test Title 19 and the content Test Content 19
	And there should be an article in the list created by Matthew with the title Test Title 20 and the content Test Content 20

Scenario: Get All News Management Articles Paged When No Articles Exist
	Given I have no saved news management articles
	When I get all articles paged requesting the first page with a page size of 10
	Then the paged article result should contain 0 items
	And the paged article result page count should be 1
	And the paged article result total item count should be 0
	And the paged article result page number should be 1
	And the paged article result page size should be 10
	And the paged article result has previous page should be false
	And the paged article result has next page should be false
	And the paged article result is first page should be true
	And the paged article result is last page should be true

Scenario: Get All News Management Articles Paged When There is only one Item
	Given I have a saved news management article with the properties
		| CreatedBy | Title         | Content         |
		| Jonathan  | Test Title 1  | Test Content 1  |
	When I get all articles paged requesting the first page with a page size of 10
	Then the paged article result should contain 1 items
	And the paged article result page count should be 1
	And the paged article result total item count should be 1
	And the paged article result page number should be 1
	And the paged article result page size should be 10
	And the paged article result has previous page should be false
	And the paged article result has next page should be false
	And the paged article result is first page should be true
	And the paged article result is last page should be true
	And there should be an article in the paged list created by Jonathan with the title Test Title 1 and the content Test Content 1

Scenario: Get All News Management Articles Paged First Page with Page Size of 10
	Given I have several saved news management articles with the properties
		| CreatedBy | Title         | Content         |
		| Jonathan  | Test Title 1  | Test Content 1  |
		| Tobin     | Test Title 2  | Test Content 2  |
		| Carl      | Test Title 3  | Test Content 3  |
		| Sara      | Test Title 4  | Test Content 4  |
		| Dan       | Test Title 5  | Test Content 5  |
		| Jon       | Test Title 6  | Test Content 6  |
		| Emma      | Test Title 7  | Test Content 7  |
		| Sorcha    | Test Title 8  | Test Content 8  |
		| Joel      | Test Title 9  | Test Content 9  |
		| Dom       | Test Title 10 | Test Content 10 |
		| Laura     | Test Title 11 | Test Content 11 |
		| Sarah     | Test Title 12 | Test Content 12 |
		| Wayne     | Test Title 13 | Test Content 13 |
		| Eric      | Test Title 14 | Test Content 14 |
		| Gary      | Test Title 15 | Test Content 15 |
		| Peter     | Test Title 16 | Test Content 16 |
		| Julie     | Test Title 17 | Test Content 17 |
		| Mollie    | Test Title 18 | Test Content 18 |
		| George    | Test Title 19 | Test Content 19 |
		| Matthew   | Test Title 20 | Test Content 20 |
	When I get all articles paged requesting the first page with a page size of 10
	Then the paged article result should contain 10 items
	And the paged article result page count should be 2
	And the paged article result total item count should be 20
	And the paged article result page number should be 1
	And the paged article result page size should be 10
	And the paged article result has previous page should be false
	And the paged article result has next page should be true
	And the paged article result is first page should be true
	And the paged article result is last page should be false
	And there should be an article in the paged list created by Jonathan with the title Test Title 1 and the content Test Content 1
	And there should be an article in the paged list created by Tobin with the title Test Title 2 and the content Test Content 2
	And there should be an article in the paged list created by Carl with the title Test Title 3 and the content Test Content 3
	And there should be an article in the paged list created by Sara with the title Test Title 4 and the content Test Content 4
	And there should be an article in the paged list created by Dan with the title Test Title 5 and the content Test Content 5
	And there should be an article in the paged list created by Jon with the title Test Title 6 and the content Test Content 6
	And there should be an article in the paged list created by Emma with the title Test Title 7 and the content Test Content 7
	And there should be an article in the paged list created by Sorcha with the title Test Title 8 and the content Test Content 8
	And there should be an article in the paged list created by Joel with the title Test Title 9 and the content Test Content 9
	And there should be an article in the paged list created by Dom with the title Test Title 10 and the content Test Content 10

Scenario: Get All News Management Articles Paged Second Page with Page Size of 10
	Given I have several saved news management articles with the properties
		| CreatedBy | Title         | Content         |
		| Jonathan  | Test Title 1  | Test Content 1  |
		| Tobin     | Test Title 2  | Test Content 2  |
		| Carl      | Test Title 3  | Test Content 3  |
		| Sara      | Test Title 4  | Test Content 4  |
		| Dan       | Test Title 5  | Test Content 5  |
		| Jon       | Test Title 6  | Test Content 6  |
		| Emma      | Test Title 7  | Test Content 7  |
		| Sorcha    | Test Title 8  | Test Content 8  |
		| Joel      | Test Title 9  | Test Content 9  |
		| Dom       | Test Title 10 | Test Content 10 |
		| Laura     | Test Title 11 | Test Content 11 |
		| Sarah     | Test Title 12 | Test Content 12 |
		| Wayne     | Test Title 13 | Test Content 13 |
		| Eric      | Test Title 14 | Test Content 14 |
		| Gary      | Test Title 15 | Test Content 15 |
		| Peter     | Test Title 16 | Test Content 16 |
		| Julie     | Test Title 17 | Test Content 17 |
		| Mollie    | Test Title 18 | Test Content 18 |
		| George    | Test Title 19 | Test Content 19 |
		| Matthew   | Test Title 20 | Test Content 20 |
	When I get all articles paged requesting the second page with a page size of 10
	Then the paged article result should contain 10 items
	And the paged article result page count should be 2
	And the paged article result total item count should be 20
	And the paged article result page number should be 2
	And the paged article result page size should be 10
	And the paged article result has previous page should be true
	And the paged article result has next page should be false
	And the paged article result is first page should be false
	And the paged article result is last page should be true
	And there should be an article created by Laura with the title Test Title 11 and the content Test Content 11
	And there should be an article created by Sarah with the title Test Title 12 and the content Test Content 12
	And there should be an article created by Wayne with the title Test Title 13 and the content Test Content 13
	And there should be an article created by Eric with the title Test Title 14 and the content Test Content 14
	And there should be an article created by Gary with the title Test Title 15 and the content Test Content 15
	And there should be an article created by Peter with the title Test Title 16 and the content Test Content 16
	And there should be an article created by Julie with the title Test Title 17 and the content Test Content 17
	And there should be an article created by Mollie with the title Test Title 18 and the content Test Content 18
	And there should be an article created by George with the title Test Title 19 and the content Test Content 19
	And there should be an article created by Matthew with the title Test Title 20 and the content Test Content 20

Scenario: Get All News Management Articles Paged First Page with Page Size of 15
	Given I have several saved news management articles with the properties
		| CreatedBy | Title         | Content         |
		| Jonathan  | Test Title 1  | Test Content 1  |
		| Tobin     | Test Title 2  | Test Content 2  |
		| Carl      | Test Title 3  | Test Content 3  |
		| Sara      | Test Title 4  | Test Content 4  |
		| Dan       | Test Title 5  | Test Content 5  |
		| Jon       | Test Title 6  | Test Content 6  |
		| Emma      | Test Title 7  | Test Content 7  |
		| Sorcha    | Test Title 8  | Test Content 8  |
		| Joel      | Test Title 9  | Test Content 9  |
		| Dom       | Test Title 10 | Test Content 10 |
		| Laura     | Test Title 11 | Test Content 11 |
		| Sarah     | Test Title 12 | Test Content 12 |
		| Wayne     | Test Title 13 | Test Content 13 |
		| Eric      | Test Title 14 | Test Content 14 |
		| Gary      | Test Title 15 | Test Content 15 |
		| Peter     | Test Title 16 | Test Content 16 |
		| Julie     | Test Title 17 | Test Content 17 |
		| Mollie    | Test Title 18 | Test Content 18 |
		| George    | Test Title 19 | Test Content 19 |
		| Matthew   | Test Title 20 | Test Content 20 |
	When I get all articles paged requesting the first page with a page size of 15
	Then the paged article result should contain 15 items
	And the paged article result page count should be 2
	And the paged article result total item count should be 20
	And the paged article result page number should be 1
	And the paged article result page size should be 15
	And the paged article result has previous page should be false
	And the paged article result has next page should be true
	And the paged article result is first page should be true
	And the paged article result is last page should be false
	And there should be an article in the paged list created by Jonathan with the title Test Title 1 and the content Test Content 1
	And there should be an article in the paged list created by Tobin with the title Test Title 2 and the content Test Content 2
	And there should be an article in the paged list created by Carl with the title Test Title 3 and the content Test Content 3
	And there should be an article in the paged list created by Sara with the title Test Title 4 and the content Test Content 4
	And there should be an article in the paged list created by Dan with the title Test Title 5 and the content Test Content 5
	And there should be an article in the paged list created by Jon with the title Test Title 6 and the content Test Content 6
	And there should be an article in the paged list created by Emma with the title Test Title 7 and the content Test Content 7
	And there should be an article in the paged list created by Sorcha with the title Test Title 8 and the content Test Content 8
	And there should be an article in the paged list created by Joel with the title Test Title 9 and the content Test Content 9
	And there should be an article in the paged list created by Dom with the title Test Title 10 and the content Test Content 10
	And there should be an article created by Laura with the title Test Title 11 and the content Test Content 11
	And there should be an article created by Sarah with the title Test Title 12 and the content Test Content 12
	And there should be an article created by Wayne with the title Test Title 13 and the content Test Content 13
	And there should be an article created by Eric with the title Test Title 14 and the content Test Content 14
	And there should be an article created by Gary with the title Test Title 15 and the content Test Content 15

Scenario: Get All News Management Articles Paged Second Page with Page Size of 15
	Given I have several saved news management articles with the properties
		| CreatedBy | Title         | Content         |
		| Jonathan  | Test Title 1  | Test Content 1  |
		| Tobin     | Test Title 2  | Test Content 2  |
		| Carl      | Test Title 3  | Test Content 3  |
		| Sara      | Test Title 4  | Test Content 4  |
		| Dan       | Test Title 5  | Test Content 5  |
		| Jon       | Test Title 6  | Test Content 6  |
		| Emma      | Test Title 7  | Test Content 7  |
		| Sorcha    | Test Title 8  | Test Content 8  |
		| Joel      | Test Title 9  | Test Content 9  |
		| Dom       | Test Title 10 | Test Content 10 |
		| Laura     | Test Title 11 | Test Content 11 |
		| Sarah     | Test Title 12 | Test Content 12 |
		| Wayne     | Test Title 13 | Test Content 13 |
		| Eric      | Test Title 14 | Test Content 14 |
		| Gary      | Test Title 15 | Test Content 15 |
		| Peter     | Test Title 16 | Test Content 16 |
		| Julie     | Test Title 17 | Test Content 17 |
		| Mollie    | Test Title 18 | Test Content 18 |
		| George    | Test Title 19 | Test Content 19 |
		| Matthew   | Test Title 20 | Test Content 20 |
	When I get all articles paged requesting the second page with a page size of 15
	Then the paged article result should contain 5 items
	And the paged article result page count should be 2
	And the paged article result total item count should be 20
	And the paged article result page number should be 2
	And the paged article result page size should be 15
	And the paged article result has previous page should be true
	And the paged article result has next page should be false
	And the paged article result is first page should be false
	And the paged article result is last page should be true
	And there should be an article created by Gary with the title Test Title 15 and the content Test Content 15
	And there should be an article created by Peter with the title Test Title 16 and the content Test Content 16
	And there should be an article created by Julie with the title Test Title 17 and the content Test Content 17
	And there should be an article created by Mollie with the title Test Title 18 and the content Test Content 18
	And there should be an article created by George with the title Test Title 19 and the content Test Content 19
	And there should be an article created by Matthew with the title Test Title 20 and the content Test Content 20

Scenario: Get Latest News Management Articles Full Take
	Given I have several saved news management articles with the properties
		| CreatedBy | Title         | Content         |
		| Jonathan  | Test Title 1  | Test Content 1  |
		| Tobin     | Test Title 2  | Test Content 2  |
		| Carl      | Test Title 3  | Test Content 3  |
		| Sara      | Test Title 4  | Test Content 4  |
		| Dan       | Test Title 5  | Test Content 5  |
		| Jon       | Test Title 6  | Test Content 6  |
		| Emma      | Test Title 7  | Test Content 7  |
		| Sorcha    | Test Title 8  | Test Content 8  |
		| Joel      | Test Title 9  | Test Content 9  |
		| Dom       | Test Title 10 | Test Content 10 |
	And then I save more news management articles with the properties
		| CreatedBy | Title         | Content         |
		| Laura     | Test Title 11 | Test Content 11 |
		| Sarah     | Test Title 12 | Test Content 12 |
		| Wayne     | Test Title 13 | Test Content 13 |
		| Eric      | Test Title 14 | Test Content 14 |
		| Gary      | Test Title 15 | Test Content 15 |
		| Peter     | Test Title 16 | Test Content 16 |
		| Julie     | Test Title 17 | Test Content 17 |
		| Mollie    | Test Title 18 | Test Content 18 |
		| George    | Test Title 19 | Test Content 19 |
		| Matthew   | Test Title 20 | Test Content 20 |
	When I get the 10 most recent articles
	Then the article list result should contain 10 items
	And there should be an article in the list created by Laura with the title Test Title 11 and the content Test Content 11
	And there should be an article in the list created by Sarah with the title Test Title 12 and the content Test Content 12
	And there should be an article in the list created by Wayne with the title Test Title 13 and the content Test Content 13
	And there should be an article in the list created by Eric with the title Test Title 14 and the content Test Content 14
	And there should be an article in the list created by Gary with the title Test Title 15 and the content Test Content 15
	And there should be an article in the list created by Peter with the title Test Title 16 and the content Test Content 16
	And there should be an article in the list created by Julie with the title Test Title 17 and the content Test Content 17
	And there should be an article in the list created by Mollie with the title Test Title 18 and the content Test Content 18
	And there should be an article in the list created by George with the title Test Title 19 and the content Test Content 19
	And there should be an article in the list created by Matthew with the title Test Title 20 and the content Test Content 20

Scenario: Get Latest News Management Articles Not a Full Take
	Given I have several saved news management articles with the properties
		| CreatedBy | Title         | Content         |
		| Jonathan  | Test Title 1  | Test Content 1  |
		| Tobin     | Test Title 2  | Test Content 2  |
		| Carl      | Test Title 3  | Test Content 3  |
		| Sara      | Test Title 4  | Test Content 4  |
		| Dan       | Test Title 5  | Test Content 5  |
		| Jon       | Test Title 6  | Test Content 6  |
		| Emma      | Test Title 7  | Test Content 7  |
	When I get the 10 most recent articles
	Then the article list result should contain 7 items
	And there should be an article in the list created by Jonathan with the title Test Title 1 and the content Test Content 1
	And there should be an article in the list created by Tobin with the title Test Title 2 and the content Test Content 2
	And there should be an article in the list created by Carl with the title Test Title 3 and the content Test Content 3
	And there should be an article in the list created by Sara with the title Test Title 4 and the content Test Content 4
	And there should be an article in the list created by Dan with the title Test Title 5 and the content Test Content 5
	And there should be an article in the list created by Jon with the title Test Title 6 and the content Test Content 6
	And there should be an article in the list created by Emma with the title Test Title 7 and the content Test Content 7

Scenario: Get Latest News Management Articles No Saved Items
	Given I have no saved news management articles
	When I get the 10 most recent articles
	Then the article list result should contain 0 items

Scenario: Get Most Recent News Management Articles
	Given I have several saved news management articles with the properties
		| CreatedBy | Title         | Content         |
		| Jonathan  | Test Title 1  | Test Content 1  |
		| Tobin     | Test Title 2  | Test Content 2  |
		| Carl      | Test Title 3  | Test Content 3  |
		| Sara      | Test Title 4  | Test Content 4  |
		| Dan       | Test Title 5  | Test Content 5  |
		| Jon       | Test Title 6  | Test Content 6  |
		| Emma      | Test Title 7  | Test Content 7  |
		| Sorcha    | Test Title 8  | Test Content 8  |
		| Joel      | Test Title 9  | Test Content 9  |
		| Dom       | Test Title 10 | Test Content 10 |
	And then I save more news management articles with the properties
		| CreatedBy | Title         | Content         |
		| Laura     | Test Title 11 | Test Content 11 |
		| Sarah     | Test Title 12 | Test Content 12 |
		| Wayne     | Test Title 13 | Test Content 13 |
		| Eric      | Test Title 14 | Test Content 14 |
		| Gary      | Test Title 15 | Test Content 15 |
		| Peter     | Test Title 16 | Test Content 16 |
		| Julie     | Test Title 17 | Test Content 17 |
		| Mollie    | Test Title 18 | Test Content 18 |
		| George    | Test Title 19 | Test Content 19 |
		| Matthew   | Test Title 20 | Test Content 20 |
	When I get the most recent articles using the time the second saved batch occurred
	Then the most recent article list should contain 10 items
	And there should be an article in the most recent list created by Laura with the title Test Title 11 and the content Test Content 11
	And there should be an article in the most recent list created by Sarah with the title Test Title 12 and the content Test Content 12
	And there should be an article in the most recent list created by Wayne with the title Test Title 13 and the content Test Content 13
	And there should be an article in the most recent list created by Eric with the title Test Title 14 and the content Test Content 14
	And there should be an article in the most recent list created by Gary with the title Test Title 15 and the content Test Content 15
	And there should be an article in the most recent list created by Peter with the title Test Title 16 and the content Test Content 16
	And there should be an article in the most recent list created by Julie with the title Test Title 17 and the content Test Content 17
	And there should be an article in the most recent list created by Mollie with the title Test Title 18 and the content Test Content 18
	And there should be an article in the most recent list created by George with the title Test Title 19 and the content Test Content 19
	And there should be an article in the most recent list created by Matthew with the title Test Title 20 and the content Test Content 20