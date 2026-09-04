Feature: SearchWords

Finding some words using Search function in EPAM's website

@SearchWords
Scenario: Searching some words in EPAM's website
	Given I open the browser and navigate to "https://www.epam.com"
	When I find a magnifier icon and click on it
	And I enter the words "BLOCKCHAIN"/"Cloud"/"Automation" on the search box and click the Find button
	Then I validate that the words "BLOCKCHAIN"/"Cloud"/"Automation" appear on the results