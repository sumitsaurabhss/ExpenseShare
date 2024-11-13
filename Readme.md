# ExpenseShare Application

## Overview

ExpenseShare is a web application to manage and track shared expenses. The application allows users to create groups, add expenses, and settle dues.

## Prerequisites

Before you begin, ensure you have met the following requirements:
- Node.js and npm installed
- Angular CLI installed
- .NET Core SDK installed
- SQL Server or any other database set up and configured

## Backend Setup

1. **Go to solution folder:**

   ```bash
   cd <...>/ExpenseShare
   ```

2. **Restore packages:**

   ```bash
   dotnet restore
   ```
   
3. **Update Database Connection String:**
   Update the connection string in appsettings.json to point to your database.

4. **Apply Migrations:**

   ```bash
   dotnet ef database update
   ```
   
5. **Run the application:**

   ```bash
   dotnet run
   ```
   

## Frontend Setup

1. **Navigate to the UI directory:**

   ```bash
   cd ExpenseShare.UI
   ```

2. **Install dependencies:**

   ```bash
   npm install
   ```

3. **Update API Endpoint**
   Update the environment.ts file to point to your backend API endpoint if necessary.

4. **Run the application:**

   ```bash
   npm install
   ```

5. **Access the application:**
   Open your browser and navigate to http://localhost:4200.