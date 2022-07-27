# UnitTesting
Simple example of using unit tests for .NET Framework 6.0 application. It tests controller and repository separately for their features to work correctly.
## Application description
The application itself is simple example of repository pattern.
- GameCharacter

    Simple class with unique name and level.    
- GameCharacterRepository

    Repository for GameCharacters, uses private HashSet to store characters.
- GameCharacterController

    Controller, which in this application can only access repository, handles its exceptions and returns text info back.
## Testing
There are 3 tested features in both controller and repository:
- Adding character
- Deleting character
- Finding character by name

These features are tested for correct behaviour in case of both correct and incorrect input.
## Start-up
Using MS Visual Studio 2022 or Jetbrains Rider 2021.3.4:
1. Open UnitTesting.sln file using one of these IDEs
2. Choose **GameCharacterTests** project
3. Choose Test -> Run All Tests (Visual Studio) / Tests -> Run Unit Tests (Rider)
