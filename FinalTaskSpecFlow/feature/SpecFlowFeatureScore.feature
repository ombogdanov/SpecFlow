Feature: CheckScoresOfTheCommands
	as a user
	I want to see list of the scores of the championship
	When I navigate to Football Scores & Fixtures Page

@mytag
Scenario Outline: CheckScoresOfTheCommands
	Given User goes to bbc main page
	And User goes to sport page
	And User navigates to Football
	And User navigates to Scores & Fixtures page
	And User enter the name of the "<championship>" in searchInput
	When User click on the date  "<month>" and "<year>"
	Then User can see scores of the "<command1_Name>" - "<command1_Score>" and "<command2_Name>" - "<command2_Score>"
Examples: 
| championship                            | month| year   | command1_Name       | command1_Score | command2_Name        | command2_Score |
| Scottish Championship                   | OCT  |  2021  | Arbroath            | 4              | Dunfermline          | 2              |
| Scottish Premiership                    | JAN  |  2021  | Celtic			    | 1              | St Mirren            | 2              |
| womens Champions League                 | AUG  |  2021  | Arsenal Women		| 3              | Slavia Prague Women  | 0              |
| Womens European Championship qualifying | APR  |  2021  | Northern Ireland    | 2              | Ukraine              | 0              |

Scenario Outline: CheckScoresOfTheCommandsEqualOnTheTeamScorePage
	Given User goes to bbc main page
	And User goes to sport page
	And User navigates to Football
	And User navigates to Scores & Fixtures page
	And User enter the name of the "<championship>" in searchInput
	And User click on the date  "<month>" and "<year>"
	When User click on the scores of the "<command1_Name>" - "<command1_Score>" and "<command2_Name>" - "<command2_Score>"
	Then User can see the same scores of the "<command1_Name>" - "<command1_Score>" and "<command2_Name>" - "<command2_Score>"
Examples: 
| championship                            | month| year   | command1_Name       | command1_Score | command2_Name        | command2_Score |
| Scottish Championship                   | OCT  |  2021  | Arbroath            | 4              | Dunfermline          | 2              |
| Scottish Premiership                    | JAN  |  2021  | Celtic			    | 1              | St Mirren            | 2              |
| womens Champions League                 | AUG  |  2021  | Arsenal Women		| 3              | Slavia Prague Women  | 0              |
| Womens European Championship qualifying | APR  |  2021  | Northern Ireland    | 2              | Ukraine              | 0              |