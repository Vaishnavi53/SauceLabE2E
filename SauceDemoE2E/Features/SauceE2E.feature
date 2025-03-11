Feature: SauceE2E

A short summary of the feature

@order1
Scenario: aLogin
	Given user is on the login page
	When user enters the "<usrname>" and "<passwd>" in the text fields
	When user clicks submit button
	Then user is navigated to home page
Examples:
 
| usrname       | passwd       |
 
| standard_user | secret_sauce |


@order2
Scenario: bItem is added to the cart
	Given Given the user is logged in 
	When the user clicks the product wants
	And user clicks the add to cart button 
	And user clicks cart icon
	Then cart should show the product added

@order3
Scenario: cCompleting checkout
	Given user is in chcekout page
	When user proceeds to checkout
	And enters "<first name>"  "<last name>" and "<postal code>"
	And user continues by clicking continue
	And user click finish
	Then the message Thank you for your order! should be displayed 
Examples: 
| first name | last name   | postal code |
| vaishnavi  | manjalagiri | 671552      |

