# HIC Timer App

This is an Angular 16 app displaying an in-browser timer along with a table of data returned from a back-end server. The back-end server consists of a .Net 6 Web API application.

## Installation

Prerequisites: Visual Studio 2022

Clone the repo and pull the latest code for both the 'master' and 'main' branches. Map the code in 'master' to a folder 'angularapp' in your local git setup. Opening Visual Studio 2022, build the project and then click on the 'Start' button. 
The Angular App should open up in a browser window, and you will be able to observe the Timer-Table interaction.

## Description

In the Angular App portion of this full-stack application, there is a 'Table' that displays a list of Inventory items and a 'Timer'. The 'Timer' will countdown from 10 to 0, at 1 second intervals, and once it reaches 0 it will increment the count of one of the Inventory Items in the table. It will then reset itself to 10 and begin the countdown again. The Inventory Item Ids chosen are randomized, and the count of the selected item will increase by 1 each time the countdown timer resets.

This page is readonly, there is no user interaction required. The data displayed is stored in an SQLLite database attached to the project, and will still be available after the application is closed.
