# CalcOperations.Starship
Application to calc amount of stops to resupply a starship given a distance to run in MegaLights

## Requirements
.NET Core 3.1

## Instructions for use
- Clone this repository with command "git clone https://github.com/brunoedsm/CalcOperations.Starship.git"
- Inside of root folder CalcOperations.Starship, to restore all project dependencies run command "dotnet restore"
- After restore dependencies, build the solution with "dotnet build"
- If you want use client application run command "dotnet run --project src/CalcOperations.Starship.Client", or, if only test simply "dotnet test"

## Project Structure

### CalcOperations.Starship.Business
This class library is composed by all components responsible to supply the business need:
/Builders
- StopCalculationResultBuilder.cs -> To build a object expected composed by Starship Name and Total Stops, applying calc based on hours/consumable by starship
/Entities
- StarshipResponse.cs -> Class that represent the HTTP response from external API of starships
- StarshipResult.cs -> Class that represent one starship unity inside in HTTP Response of external API
- StopCalculationResult.cs -> Class that represent the model expected to be presented by any client
/Extensions
- StringToHourExtension.cs -> Extension to convert the text unity time given by external API to hours
/Services
- ExternalStarshipService.cs -> Service to consume external API of starships
- StopCalculationService.cs -> Service to process a list of starships with their names and amount of stops given a distance in MegaLights to run

### CalcOperations.Starship.Client
Simple console/terminal application to serve as interface between user input and business layer, accepting distance and displaying results on screen

### CalcOperations.Starship.Business.Test
XUnit application to test Business layer to ensure that all components are working as expected

## Contact
Any doubts, i'm still available on e-mail brunoedsm@gmail.com or Skype ID brunoedsm
