
# NZWalks API

This is an API built using ASP.NET Core that allows you to manage user authentication, regions, and walks for the NZWalks platform.

## Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- Visual Studio or Visual Studio Code with C# extension.

## Setup

To get started with this project:

1. Clone the repository:
    ```bash
    git clone <[repository-url](https://github.com/MahmoodElbadri/NZWalks.Api.git)>
    cd NZWalks.Api
    ```

2. Install the necessary dependencies:
    ```bash
    dotnet restore
    ```

3. Run the application:
    ```bash
    dotnet run
    ```

## API Endpoints

### Authentication

#### 1. Register User
- **Endpoint**: `POST /api/auth/Register`
- **Request Body**:
  ```json
  {
    "UserName": "user@example.com",
    "Password": "password123",
    "Roles": ["Admin"]
  }
  ```
- **Response**: `200 OK` or `400 Bad Request`

#### 2. Login User
- **Endpoint**: `POST /api/auth/Login`
- **Request Body**:
  ```json
  {
    "Username": "user@example.com",
    "Password": "password123"
  }
  ```
- **Response**: `200 OK` with JWT token or `400 Bad Request`

### Regions

#### 1. Get All Regions
- **Endpoint**: `GET /api/regions`
- **Response**: `200 OK` with list of regions.

#### 2. Get Region by ID
- **Endpoint**: `GET /api/regions/{id:guid}`
- **Response**: `200 OK` with region data or `404 Not Found`

#### 3. Add Region
- **Endpoint**: `POST /api/regions`
- **Request Body**:
  ```json
  {
    "Name": "New Zealand",
    "Area": "10000"
  }
  ```
- **Response**: `201 Created` with region data.

#### 4. Update Region
- **Endpoint**: `PUT /api/regions/{id:guid}`
- **Request Body**:
  ```json
  {
    "Name": "Updated Region",
    "Area": "20000"
  }
  ```
- **Response**: `200 OK` with updated region data or `404 Not Found`.

#### 5. Delete Region
- **Endpoint**: `DELETE /api/regions/{id:guid}`
- **Response**: `200 OK` with deleted region data or `404 Not Found`.

### Walks

#### 1. Create Walk
- **Endpoint**: `POST /api/walks`
- **Request Body**:
  ```json
  {
    "Name": "Walk Name",
    "RegionId": "b7fa5f82-ded2-4f23-9df0-3b9004565c9e",
    "Length": 10,
    "Difficulty": "Easy"
  }
  ```
- **Response**: `200 OK` with created walk data.

#### 2. Get All Walks
- **Endpoint**: `GET /api/walks`
- **Query Parameters**: `filterOn`, `track`, `sortBy`, `isAscending`, `pageNumber`, `pageSize`
- **Response**: `200 OK` with list of walks.

#### 3. Get Walk by ID
- **Endpoint**: `GET /api/walks/{id:guid}`
- **Response**: `200 OK` with walk data or `404 Not Found`.

#### 4. Update Walk
- **Endpoint**: `PUT /api/walks/{id:guid}`
- **Request Body**:
  ```json
  {
    "Name": "Updated Walk",
    "Length": 12,
    "Difficulty": "Moderate"
  }
  ```
- **Response**: `200 OK` with updated walk data or `404 Not Found`.

#### 5. Delete Walk
- **Endpoint**: `DELETE /api/walks/{id:guid}`
- **Response**: `200 OK` with deleted walk data or `404 Not Found`.

## Models

### RegisterAddRequest
```csharp
public class RegisterAddRequest
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public List<string> Roles { get; set; }
}
```

### LoginRequestDto
```csharp
public class LoginRequestDto
{
    public string Username { get; set; }
    public string Password { get; set; }
}
```

### WalksAddRequest
```csharp
public class WalksAddRequest
{
    public string Name { get; set; }
    public Guid RegionId { get; set; }
    public double Length { get; set; }
    public string Difficulty { get; set; }
}
```

### RegionAddRequest
```csharp
public class RegionAddRequest
{
    public string Name { get; set; }
    public double Area { get; set; }
}
```

## Technologies Used

- **ASP.NET Core** - Framework for building the API.
- **Identity** - Authentication and authorization via ASP.NET Core Identity.
- **JWT (JSON Web Tokens)** - Used for user authentication and secure API access.
- **AutoMapper** - For mapping between domain models and DTOs.
- **Entity Framework Core** - ORM for data access.
- **Swagger** - For API documentation.

## Contributing

If you'd like to contribute to this project, feel free to open an issue or submit a pull request.
