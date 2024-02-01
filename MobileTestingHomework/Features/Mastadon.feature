Feature: Mastadon

Background:
	Given Open Mastadon application
	Then Welcome screen is opened

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