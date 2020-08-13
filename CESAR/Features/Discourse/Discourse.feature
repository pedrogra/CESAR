@discourse
Feature: Discourse
	
Scenario: WEB_1
	Given I Navigate to "https://www.discourse.org/" and click on "Demo"
	When I scrolldown until the bottom of the page.
	Then I print the expect information.
	