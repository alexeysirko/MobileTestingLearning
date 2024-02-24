Feature: Mastadon

Background:
	Given Open Mastadon application
	Then Welcome screen is opened

@HW2
Scenario: Startup/shutdown of applications, searching for items
	When Close Mastadon application
	Then Mastadon application is closed

	When Open Mastadon application
	Then Welcome screen is opened
		
	When Log in the app
	Then Home screen is opened

	When Tap 'Search' tab
	Then Posts screen is opened

	When Open the first post
	Then The first post is opened

@HW2
Scenario: Interaction with elements
	When Log in the app
	Then Home screen is opened

	When Tap 'Search' tab
	Then Posts screen is opened
		And Posts have the Displayed state

	When Get the position of a search field
	Then Search field doesn't have the '0':'0' position value

	When Tap the search field by the position
		And Enter 'tests' to the search field
	Then Search result is not empty

	When Open the Posts with # search results
	Then Post screen with provided # is opened

	When Scroll down to the '4' post

@HW2
Scenario: Contexts
	When Log in the app
	Then Home screen is opened

	When Tap 'Search' tab
	Then Posts screen is opened

	Given Get the current context
	When Check if there are other contexts
	 And If those contexts are there, switch to them

@HW3
Scenario: Swipes, Appium visibility
	When Log in the app
	Then Home screen is opened

	When Tap 'Search' tab
	Then Posts screen is opened

	When Scroll to post '4' with Swipe
	Then Post '4' is Displayed

	When Go back to the first post using scrollToElement
	Then Post '1' is Displayed

	When Swipe to post '20' with Appium