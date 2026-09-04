Feature: ArticleMatches

Validation of article names from Insights menu

@ValidateArticleMatches
Scenario: Validate title of the article matches with title in carousel
	Given I initialize the browser and open the website "https://www.epam.com"
	When I select "Insights" from the top menu
	And I swipe the carousel two or more times <times>
	And I click the button "Read More"
	Then I validate that the name of the article matches with the one of the carousel

	Examples: 
	| times |
	| 2		|
	| 4		|