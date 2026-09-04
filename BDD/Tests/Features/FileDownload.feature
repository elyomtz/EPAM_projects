Feature: FileDownload

Download PDF file from Policies section in EPAM's website

@FileDownload
Scenario: Validate file download function works as expected
	Given I open the browser and I access the website "https://www.epam.com"
	When I click on the "Code of Ethical Conduct (PDF)" in "Policies" section
	And I wait for a document to be downloaded
	Then I validate that the document is downloaded and named "Code-Of-Ethical-Conduct.pdf"
