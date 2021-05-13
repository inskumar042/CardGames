

<!-- PROJECT CARD GAME -->





<!-- PROJECT LOGO -->
<br />
<p align="center">


  <h3 align="center">PROJECT CARD GAME</h3>

  <p align="center">
    Programming Challenge: Card Game!
    <br />
    <br />
    <br />
    <a href="https://github.com/inskumar042/CardGames">View Demo</a>
  </p>
</p>



<!-- TABLE OF CONTENTS -->
<details open="open">
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#about-the-project">About The Project</a>
      <ul>
        <li><a href="#built-with">Built With</a></li>
      </ul>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#prerequisites">Prerequisites</a></li>
        <li><a href="#installation">Installation</a></li>
        <li><a href="#Using-Miscrosoft-Visual-Studio-2019-editor">Using Miscrosoft Visual Studio 2019 editor</a></li>
        <li><a href="#Using-Command-Prompt">Using Command Prompt</a></li>
      </ul>
    </li>
  </ol>
</details>



<!-- ABOUT THE PROJECT -->
## About The Project



Program for a game of Cards.Each card shows a number from 1 to 10. Each number is in the deck four times for a total of 40 cards. At the
beginning of the game, the deck is shuffled.
Each Player will recieve a stack from the shuffled deck of cards as their draw pile. The draw pile is kept facedown in front of the player. Each player also keeps a discard pile
Each turn, both players draw the top card. If there are no more cards in the draw pile, shuffle the discard pile
and use those cards as the new draw pile. Once a player has no cards in either their draw or discard pile, that
player loses.
The players present their drawn card and compare the values. The player with the higher value card, takes
both cards and adds them to their discard pile, next to the draw pile. If the cards show the same value, the
winner of the next turn wins these cards as well.


### Built With

* [Microsoft Visual Studio 2019 - .NET Framework 5.0](https://docs.microsoft.com/en-us/dotnet/core/dotnet-five)




<!-- GETTING STARTED -->
## Getting Started



### Prerequisites

Pull the code from git.
git location:https://github.com/inskumar042/CardGames


### Installation


### Using Miscrosoft Visual Studio 2019 editor

Open the project solution file in Visual Studios
Build -> Build Solution

Run Unit Tests Open Test Explorer window

Tests -> Run All Tests -Hit F5 or Debug -> Start Debugging


### Using Command Prompt

cd to the folder containing the solution file and the project file
 
 Build:
 dotnet build CardGame.csproj

 Run Unit Tests
 dotnet test TestCardGame.csproj

 Run:
 dotnet run CardGame

