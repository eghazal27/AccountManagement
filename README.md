# Project Name

This project is a solution developed using various technologies to provide APIs and services following the Clean Architecture design pattern. It uses a combination of pgAdmin, PostgreSQL, Prisma, .NET 7, Dapper, and Docker.

## Technology Used

- **pgAdmin**: pgAdmin is used for faster development and data manipulation and handling.
- **PostgreSQL**: PostgreSQL is used as the database management system instead of traditional SQL databases for easier accessibility and simplicity.
- **Prisma**: Prisma is used to generate data in PostgreSQL. Note that Prisma could have been replaced by EntityFramework.
- **.NET 7**: The project is developed using .NET 7, which provides a framework for building APIs and services.
- **Dapper**: Dapper is used for communicating with the database. Note that Dapper could have been replaced by EntityFramework.
- **Docker**: Docker is used to initiate database and API instances by creating Docker images using Docker Compose.

## Steps to Run the Solution

To run the application, follow these steps:

1. Clone the repository to your local machine.

2. **Solution Setup**:
   - Navigate to the project root folder.
   - Run `docker-compose up` to generate the database using Docker Compose.

3. **Database Setup**:
   - Install pgAdmin from the official website: [Download pgAdmin](https://www.pgadmin.org/download/pgadmin-4-windows/).
   - Install Prisma globally using the following command: `npm install -g prisma`.
   - Navigate to the `./db` folder in the project directory.
   - Run the following command to generate the database tables and structure: `prisma migrate dev`.

4. **Run the Application**:
   - Build the solution using .NET 7.
   - Run the application to start the API and services.
   - Application can be ran using IIS express, or using docker compose up. 

5. Use pgAdmin to check the data and perform data manipulation tasks.

Note: Make sure you have the necessary prerequisites installed on your machine, including Docker, .NET 7, and Node.js.

## Additional Information
N/A
