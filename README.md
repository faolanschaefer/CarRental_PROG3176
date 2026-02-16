# Project Overview

A car rental platform demonstrating Domain Driven Design principles, developed for the Distributed Applications Development course at Conestoga College.

# Assignment 1

## Architecture Overview

This project demonstrates Domain Driven Design, maintaining a strict separation of concerns between business rules and system functionality. 

## Architecture Layers

The project is split into 4 distinct layers: 

- The **Domain Layer** encapsulates core business logic and entities as the core basis for the system.
- The **Application Layer** coordinates tasks and delegates work to domain objects. 
- The **Infrastructure Layer** handles data persistence and interaction with backend data structures.
- The **Web API Layer** exposes service functionality to the web by mapping REST endpoints to application layer operations.

## Domain Model & Business Rules

The inventory service revolves around a `Vehicle` entity which serves as an aggregate root, collecting key data from across the inventory database. 

The `Vehicle` entity combines the `Inventory`, `Vehicle`, `VehicleLocation`, `VehicleStatus`, and `VehicleType` entities from the SQL database into a single easily accessible class with built-in validation based on core business rules.

Business rules implemented:

- A vehicle cannot be rented if it is already rented
- A vehicle cannot be rented if it is reserved
- A vehicle cannot be rented if it is under service
- A reserved vehicle cannot be marked as available without explicit release

## Run Instructions

To run the inventory service implemented in Assignment 1:

- Ensure your system supports .NET 10
- Ensure the database connection in `VehicleInventory.WebAPI/appsettings.json` is configured to use an existing database
- Open `CarRental.slx` in Visual Studio or open a new terminal in the solution directory
- Run `dotnet build VehicleInventory.WebAPI/VehicleInventory.WebAPI.csproj` to build the project
- Run `dotnet run --project VehicleInventory.WebAPI` to start the web API
- Open `https://localhost:53342/swagger/index.html` in a browser to access the Swagger console

## Known Limitations

There is currently no API functionality for updating reference entities (vehicle, location, status, type) in the database. Any inventory records created or updated must reference existing items.
