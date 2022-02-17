# TicTacToe in C# 
###### Console Edition and AutoCAD Edition

## Overview
In order to learn C# I created TicTacToe in the language. First I created it in in a console app to get the basic understanding of the language. Then, I moved on to making the game display in AutoCAD. I am looking to make a large scale project in AutoCAD and thought that this would be a great way to start understanding the ObjectARX SDK.

### Console Edition
* __TicTacToe.cs:__ Contains the main function that is run when the game is first called.
* __Board.cs:__ Contains the necessary functions for displaying the board to the player, checking for a winner, and displaying if a player has won or there was a tie.
* __Player.cs:__ Contains the code to get user input to choose which square to claim and taking turns between the two players.

### AutoCAD Edition
* __Commands.cs:__ This contains all of the commands that can be run from inside of AutoCAD and the functions that they will call. The command "TICTACTOE" will call the TicTacToe function and start the game!
* __Active.cs:__ This is a static helper class. It instantiates three variables that are called repeatedly, being the active Document, Database, and Editor.
* __DrawObjects.cs:__ This is another static helper class. True to it's name, it is reponsible for drawing lines and text in AutoCAD. Not as true to it's name, it also contains functions to get user selection, erase all objects, and set text size.
* __Board.cs:__ This class does the same thing as in the console edition, but through calls to draw objects in AutoCAD.
* __Player.cs:__ This class does the same thing as in the console edition, but through calls to select objects in AutoCAD.

[TicTacToe in C# Demo](https://youtu.be/vnAH61DUbGA)

## Development Environment
* __Visual Studio Community (IDE):__ An IDE with strong support for C# and including external files in your project.
* __.NET 6.0 (C#):__ A development framework with long term support that includes C# (used for console edition).
* __.NET 4.8 (C#):__ The .NET framework currently supported by AutoCAD. (used for AutoCAD edition).
* __AutoCAD 2022:__ Student trial of AutoCAD to test the development of plugins.
* __ObjectARX SDK:__ A software development kit that assists in developing plugins for AutoCAD.

## Useful Websites
* [W3 Schools: C#](https://www.w3schools.com/cs/index.php)
* [Geeks for Geeks: C#](https://www.geeksforgeeks.org/csharp-programming-language/)
* [Microsoft .NET Documentation](https://docs.microsoft.com/en-us/dotnet/)
* [AutoDesk .NET Forum](https://forums.autodesk.com/t5/net/bd-p/152)
* [Arnold Higuit's C# AutoCAD Programming Tutorial](https://www.youtube.com/c/ArnoldHiguit)

## Future Work
* Figure out how to change text size
* Change DrawLine to DrawPolyline so that I can controll width of lines
* Figure out how to make letters not crash the console edition
* Combine Active and DrawObjects and come up with a better name.