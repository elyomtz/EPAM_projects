Feature: SearchRemoteJobs

Find remote job in EPAM's website

@SearchRemoteJobs
Scenario: Searching for a position based on criteria
	Given I start the browser and go to "https://www.epam.com"
	When I click on the "Careers" link
	And I click on the button "Start your search here"
	And I enter any programming language "<programming_language>" in the field "Search by Role or Keyword"
	And I select a country "<country>" in the field "Choose your country"
	And I Select option "Remote"
	And I click on the button "Search"
    And I click on latest element in the list of results
	Then I expand the element and validate that programming language "<programming_language>" from search is present

	Examples: 
	|programming_language  |  country  |
	|.net				   | Mexico    | 
	| java                 | Argentina |	