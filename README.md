# FizzBuzz - Custom Processing Engine API

A C# Web API application built with .NET 10 that implements an enhanced, custom variant of the classic FizzBuzz puzzle architecture.

# Rule Matrix Implemented
- *Multiple of 3*: Outputs Fizz
- *Multiple of 5*: Outputs Buzz
- *Multiple of 3 & 5*: Outputs FizzBuzz
- *Non-Multiples (e.g., 1, 23)*: Logs every mathematical division calculation executed (e.g., Divided X by 3, Divided X by 5)
- *Strings, Blanks, or Nulls (e.g., "A", "")*: Validates and outputs Invalid Item

# Blueprint
- **Single Responsibility Principle (SRP)**: Input validation, mathematical calculation, and string formatting tasks are fully decoupled into dedicated components.
- **Factory & Strategy Design Patterns**: Distinct business rule scenarios are isolated into individual behavioral strategies. An execution factory (`FizzBuzzStrategyFactory`) dynamically evaluates the array elements and dispenses the correct processing strategy component at runtime.
- **Dependency Injection**: Leveraged the native .NET IoC container to cleanly inject interfaces into consumers, ensuring low architectural coupling.
- **Robust Boundary Handling**: Inputs are scrubbed using defensive data validation techniques to prevent unhandled runtime exceptions.
- **Automated xUnit Testing**: Backed by a comprehensive unit test suite leveraging xUnit assertions and behavioral mocking via the Moq framework.

# How to Run and Test the Project Locally

## Prerequisites
- .NET 10 SDK installed on your machine

## Setup Steps
1. Open your terminal or command prompt inside the project folder.
2. Run the application specifying the project configuration:
   ```bash
   dotnet run --project FizzBuzzApi.csproj
   ```
3. Once the terminal displays `Now listening on: http://localhost:5000`, open your web browser and navigate to the interactive testing playground:
   ```text
   http://localhost:5000/swagger
   ```

## How to Execute the Unit Tests
To run the automated xUnit suite and verify behavioral code coverage, execute the following command in your terminal:
```bash
dotnet test
```

# API Testing Verification
Inside the Swagger UI dashboard:
1. Expand the *POST /api/FizzBuzz/process* routing bar.
2. Click *"Try it out"*.
3. Supply this array inside the Request Body:
   ```json
   [ "1", "3", "5", "15", "23", "A", "" ]
   ```
4. Click *"Execute"* to see your verified 200 OK custom calculations populate instantly!