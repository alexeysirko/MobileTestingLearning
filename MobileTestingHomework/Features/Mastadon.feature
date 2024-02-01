Feature: Mastadon


Scenario: Startup/shutdown of applications, searching for items
	When Open Mastadon application
	Then Welcome screen is opened

	When Close Mastadon application
	Then Mastadon application is closed

	When Open Mastadon application
	Then Welcome screen is opened
		
	When Log in the app
	Then Home screen is opened

	When Tap 'Search' tab
	Then Posts screen is opened