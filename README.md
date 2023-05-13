# Project Name

This project is a solution developed using various technologies to provide APIs and services following the Clean Architecture design pattern. It includes a new Angular app called "my-angular-app." The Angular app is a basic application designed to add and list customers. It should be updated to allow for updating existing customer information and display customers by default.

## Technology Used

- **.NET 7**: The project is developed using .NET 7, which provides a framework for building APIs and services.
- **Entity Framework (EF)**: EF is used as the Object-Relational Mapping (ORM) tool for communicating with the database.
- **Docker**: Docker is used to create Docker images and run the application in containers.
- **Angular**: The project includes an Angular app named "my-angular-app" for the frontend.

## Steps to Run the Solution

To run the application, follow these steps:

1. Clone the repository to your local machine.

2. **Run the Application**:
   - Build the solution using .NET 7.
   - Run the application to start the API and services.
   - docker-compose can be used as well. using `docker-compose up` command (Since a valid docker file is created.)

3. **Run the Angular App**:
   - Navigate to the "my-angular-app" directory.
   - Install the dependencies using `npm install`.
   - Run the Angular app using `ng serve` or `npm start`.
   - Make sure to replace the API URL by a valid one. API URL stored in `user.service.ts` (To be moved later to configuration file)

4. **CI/CD**
   - A new pipeline created (compatible with CodeFresh) under `infra\cf-pipeline.yaml`.
   - Pipeline should generate a basic artifact of the API.
   - Should be updated once a valid docker container registry and K8S cluster available for the CD part.

## Additional Information

- The Angular app provides a basic user interface (UI) for adding and listing customers. Please note that no validation is currently implemented in the UI. Additional validation should be added, especially for existing customers, to ensure data integrity.

- Due to time shortage, the current implementation uses EF with an in-memory database. This is for demonstration and development purposes only. In a production environment, a persistent database should be used, such as PostgreSQL or SQL Server, and the connection string and configuration should be updated accordingly.
