# JWTAuthToken

JWTAuthToken is a sample project demonstrating JWT (JSON Web Token) authentication in an ASP.NET Core application. It provides user registration, login, and token generation functionality.

## Table of Contents

- [About](#about)
- [Features](#features)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
- [Usage](#usage)
- [Contributing](#contributing)
- [License](#license)

## About

JWTAuthToken is a simple ASP.NET Core project showcasing how to implement JWT-based user authentication. It allows users to register, log in, and obtain a JWT token for authentication.

## Features

- User registration with password hashing
- User login with JWT token generation
- Demonstrates JWT-based authentication in ASP.NET Core

## Getting Started

Follow the instructions below to set up and run the JWTAuthToken project on your local machine.

### Prerequisites

- [.NET Core SDK](https://dotnet.microsoft.com/download) installed on your machine.
- An integrated development environment (IDE) like Visual Studio or Visual Studio Code.

### Installation

1. Clone the repository:

   ```bash
   git clone https://github.com/your-username/JWTAuthToken.git

## Usage

To use the JWTAuthToken API, you can perform the following actions:

Register a user by making a POST request to /api/Auth/register.
Log in with a registered user by making a POST request to /api/Auth/login.
Ensure that you provide a valid username and password in the request body to use the authentication functionality.

## Contributing

We welcome contributions to the JWTAuthToken project. To contribute, please follow these guidelines:

Fork the repository.
Create a new branch for your feature or bug fix.
Make your changes and ensure that the code passes any tests.
Commit your changes and create a pull request.
