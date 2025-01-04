# Mo7tawa .NET Core Application

This is a sample .NET Core web application developed for the **Mo7tawa Senior Software Engineer Assessment**. The application showcases the use of .NET Core for building a web API with functionality for user authentication and interaction with a database.

---

## Table of Contents

- [Prerequisites](#prerequisites)
- [Installation](#installation)
  - [Step 1: Setup Database]
  - [Step 2: Install EF Core Tools]
  - [Step 3: Database Update]
- [Usage]
  - [Signup]
  - [Login]
  - [Swagger Authorization]
---

## Prerequisites

Before running this application, ensure you have the following installed on your system:

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) or later
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or another IDE that supports .NET Core development
- [SQL Server](https://www.microsoft.com/en-us/sql-server) (or any other database of your choice)

Additionally, make sure that **Entity Framework Core tools** are available in your environment to manage database migrations.

---

## Installation

Follow these steps to set up and run the application on your local machine:

### Step 1: Setup Database

1. The database for this project is named **`Mo7tawa`**. You can either:
   - Create a new database with this name, or
   - Choose a custom name for the database, ensuring to update the connection string in the `appsettings.json` file accordingly.

2. In the `appsettings.json` file, locate the **DefaultConnection** string and modify it with your own connection string. Example:
   
   "ConnectionStrings": {
     "DefaultConnection": "YOUR_CONNECTION_STRING_HERE"
   }

### Step 2: Install EF Core Tools
Simply building the solutions will download all of the required nugets.

### Step 3: Database Update
Go to the package manager console and run the following command:  **dotnet ef database update**.  
If dotnet was not found on your pc, you can fix this by running : **dotnet tool install --global dotnet-ef**


### 4. Use the Signup Endpoint to Get a Working Username and Password

To create a new user, you need to use the **Signup** endpoint. This endpoint requires the following parameters:

- `username` (string): The desired username for the new user.
- `email` (string): The email address of the user.
- `password` (string): The password for the user account.


### 5. Use the Login Endpoint to Get a Working Token

Once you have successfully signed up and created a user, you can now log in to your account and obtain an authentication token (JWT). This token is required to authenticate your requests to protected API endpoints.

To log in, use the **Login** endpoint by providing the following credentials:

- **`username`** (string): The username of the user you created during the signup process.
- **`password`** (string): The password you provided during the signup process.


### 6. In the Swagger Menu: Click on the Green Authorize Button, and Add in Your Token

Once you have obtained the JWT token from the login endpoint, you need to authorize your API requests using this token in Swagger. This will allow you to access all protected endpoints, such as those for managing books.

Follow these steps to authorize in Swagger:

1. **Open Swagger UI**: In your browser, go to the Swagger UI interface of the application. It is typically accessible at `/swagger` when the application is running locally (e.g., `http://localhost:5000/swagger`).

2. **Click the Authorize Button**: In the top-right corner of the Swagger UI, you will see a green **Authorize** button. Click on it to open the authorization dialog.

3. **Enter Your JWT Token**: 
    - In the dialog box that appears, there will be a field labeled **`Bearer`**.
    - Paste the JWT token you received during the login step into this field.

4. **Click Authorize**: After entering the token, click the **Authorize** button in the dialog.

5. **Access Protected Endpoints**: Once successfully authorized, you will have access to all the API endpoints, including the **Book** endpoints, which require authentication. 

Now you can interact with the protected API, such as adding, updating, or fetching books. Any subsequent requests you make from Swagger will automatically include your JWT token for authorization.
