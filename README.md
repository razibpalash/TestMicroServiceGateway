# Microservice Project - ApiGateway, Auth.Api, Card.Api

## Overview

This project consists of a microservice architecture with three main components:

* **ApiGateway**: Serves as the gateway for routing and aggregating requests using **YARP (Yet Another Reverse Proxy)**.
* **Auth.Api**: Manages authentication and authorization, including JWT-based token generation.
* **Card.Api**: Handles card-related operations such as creation, retrieval, and management.

## Technologies Used

* **.NET 9**
* **ASP.NET Core**
* **YARP (Yet Another Reverse Proxy)** for the API Gateway
* **JWT** for secure authentication
* **Entity Framework Core** for data access
* **SQL Server** for data storage

## Project Structure

```
project-root/
├── ApiGateway/
├── Auth.Api/
├── Card.Api/
└── README.md
```

## ApiGateway

ApiGateway is configured using **YARP** to route requests to the appropriate microservices.

### Configuration

Update the `appsettings.json` file in the **ApiGateway** project:

```json
{
  "ReverseProxy": {
    "Routes": {
      "auth": {
        "ClusterId": "authCluster",
        "Match": {
          "Path": "/auth/{**catchAll}"
        },
        "Transforms": [
          { "PathRemovePrefix": "/auth" }
        ]
      },
      "card": {
        "ClusterId": "cardCluster",
        "Match": {
          "Path": "/card/{**catchAll}"
        },
        "Transforms": [
          { "PathRemovePrefix": "/card" }
        ]
      }
    },
    "Clusters": {
      "authCluster": {
        "Destinations": {
          "authApi": {
            "Address": "http://localhost:5001/"
          }
        }
      },
      "cardCluster": {
        "Destinations": {
          "cardApi": {
            "Address": "http://localhost:5002/"
          }
        }
      }
    }
  }
}

```

## Auth.Api

Responsible for user authentication and authorization.

### Features

* User Registration
* User Login
* JWT Token Generation

### Endpoints

* `POST /auth/register`
* `POST /auth/login`

## Card.Api

Manages card information and operations.

### Features

* Create Card
* Get Card Details
* Update Card Information

### Endpoints

* `POST /card`
* `GET /card/{id}`

## Running the Project

To run the entire microservice system:

1. Build the services:

   ```bash
   dotnet build
   ```
2. Access the services via ApiGateway:

   * Auth API: `http://localhost:8000/auth`
   * Card API: `http://localhost:8000/card`

