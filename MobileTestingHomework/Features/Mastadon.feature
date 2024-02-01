Feature: Mastadon


Scenario: Startup/shutdown of applications, searching for items
	When I open Mastadon application
	Then Welcome screen is opened

	When I close Mastadon application
	Then Mastadon application is closed

	When I open Mastadon application
	Then Welcome screen is opened
		
	When I log in the app
	Then Home screen is opened