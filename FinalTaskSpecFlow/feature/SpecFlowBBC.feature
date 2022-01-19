Feature: SpecFlowBBC
	As a user
	I want go to bbc site
	And check functionality

@mytag
Scenario: Check name of the main page
	Given User goes to bbc main page
	When User clicks news button
	Then User can see main news equals <nameOtTheMainArticle>
	Examples: 
	| nameOtTheMainArticle							 |
	|Tonga undersea cable may take four weeks to repair |

@mytag
Scenario: Check names of the secondary news
	Given User goes to bbc main page
	When User clicks news button
	Then User can see the seconds articls name is 
	| Value													|
|Tonga undersea cable may take four weeks to repair|
|WHO warns Covid not over amid Europe case records|
|US envoy in Ukraine as Russian tensions rise|
|'World's most valuable house' - which no one wanted to buy|
|US Capitol riot committee targets Rudy Giuliani|
|Ex-rebel hostage to run for Colombian presidency|
|Arrest over Australian child found dead in barrel|
|Backlash as US billionaire dismisses Uyghur abuse|
|US officers charged with fatally shooting girl|
|The row over Hong Kong's condemned hamsters|
|Saudis warned of jail time for posting rumours|
|Mobile firms agree another 5G delay at US airports|
|Irish police arrest man over Ashling Murphy killing|

