Feature: NewsManagementNewsArticleService
	Data Access tests for NewsManagementNewsArticleService

Scenario: Create a Valid News Management Article
	Given I have a news management article with the properties
		| CreatedBy | Title		 | Content		|
		| Jonathan  | Test Title | Test Content |
	When I attempt to create the article
	Then the article service count should be 1
	And the service result will be true
	And the Creator will be Jonathan
	And the Title will be Test Title
	And the Content will be Test Content

Scenario: Create several News Management Articles
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
	When I attempt to create the articles
	Then the service result will be true
	And the article service count should be 20
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

Scenario: Create a News Management Article with a null CreatedBy Property
	Given I have a news management article with the properties
		| CreatedBy | Title		 | Content		|
		| null      | Test Title | Test Content |
	When I attempt to create the article
	Then the article service count should be 0
	And the service result will be false

Scenario: Create several News Management Articles with some having a null CreatedBy Property
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
	When I attempt to create the articles
	Then the service result will be false
	And the article service count should be 0

Scenario: Create a News Management Article with a null Title Property
	Given I have a news management article with the properties
		| CreatedBy | Title | Content      |
		| Jonathan  | null  | Test Content |
	When I attempt to create the article
	Then the article service count should be 0
	And the service result will be false

Scenario: Create several News Management Articles some having a null Title Property
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
	When I attempt to create the articles
	Then the service result will be false
	And the article service count should be 0

Scenario: Create a News Management Article with a null Content Property
	Given I have a news management article with the properties
		| CreatedBy | Title      | Content |
		| Jonathan  | Test Title | null    |
	When I attempt to create the article
	Then the article service count should be 0
	And the service result will be false

Scenario: Create several News Management Articles with some having a null Content Property
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
	When I attempt to create the articles
	Then the service result will be false
	And the article service count should be 0

Scenario: Update a News Management Article
	Given I have a saved news management article with the properties
		| CreatedBy | Title		 | Content		|
		| Jonathan  | Test Title | Test Content |
	When I update the news management article to the values below
		| CreatedBy | Title		 | Content	   |
		| Tobin     | New Title  | New Content |
	Then the Creator will be Tobin
	And the Title will be New Title
	And the Content will be New Content
	And the service result will be true
	And the article service count should be 1

Scenario: Update several News Management Articles
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
	When I update the news management articles to the values below using Created By as the identifier
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
	Then the service result will be true
	And the article service count should be 20
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

Scenario: Update a Invalid News Management Article
	Given I have a saved news management article with the properties
		| CreatedBy | Title		 | Content		|
		| Jonathan  | Test Title | Test Content |
	When I update the news management article to the values below
		| CreatedBy | Title		 | Content	   |
		| null      | New Title  | New Content |
	Then the Creator will be Jonathan
	And the Title will be Test Title
	And the Content will be Test Content
	And the service result will be false

Scenario: Update several Invalid News Management Articles
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
	When I update the news management articles to the values below using Created By as the identifier
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
	Then the service result will be false
	And the article service count should be 20
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

Scenario: Delete a null News Management Article
	Given I have a null news management article
	When I attempt to delete the article
	Then the article service count should be 0
	And the service result will be false

Scenario: Delete several null News Management Articles in a transaction
	Given I have several null news management articles
	When I attempt to delete the articles
	Then the article service count should be 0
	And the service result will be false

Scenario: Delete a News Management Article
	Given I have a saved news management article with the properties
		| CreatedBy | Title | Content |
		| Jonathan  | Test Title | Test Content |
	When I attempt to delete the article
	Then the article service count should be 0

Scenario: Delete several News Management Articles
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
	When I attempt to delete the articles
	Then the service result will be true
	And the article service count should be 0

Scenario: Valid Query Is News Article Created By
	Given I have a saved news management article with the properties
		| CreatedBy | Title		 | Content		|
		| Jonathan  | Test Title | Test Content |
	When I query whether the news article was created by Jonathan
	Then the service result will be true

Scenario: Invalid Query Is News Article Created By
	Given I have a saved news management article with the properties
		| CreatedBy | Title		 | Content		|
		| Jonathan  | Test Title | Test Content |
	When I query whether the news article was created by Tobin
	Then the service result will be false