@trivago
Feature: Trivago
	
Scenario: WEB_2
	Given I navigate to "http://www.trivago.com.br" and search for "Natal"
	Then I sort my result by "Somente distância" and click on the map button.
	And I print the expect result for Hotel number 2.
	
	