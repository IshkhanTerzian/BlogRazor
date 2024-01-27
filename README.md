# BlogRazor.Web

Welcome to BlogRazor.Web! This web application empowers you to manage blog posts, comments, and likes seamlessly. Whether you're a blogger or a reader, BlogRazor.Web provides a user-friendly experience for all.

## Table of Contents

- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
- [Project Structure](#project-structure)

## Getting Started

### Prerequisites

Before you begin, ensure you have the following prerequisites installed on your system:

- [.NET SDK](https://dotnet.microsoft.com/download)
- [.NET CLI Tools](https://dotnet.microsoft.com/tools)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [Entity Framework Core Tools](https://docs.microsoft.com/en-us/ef/core/cli/dotnet)


### Installation

1. **Clone the repository:**

   ```bash
   git clone https://github.com/ishkhanterzian/BlogRazor.Web.git

## Project Structure

### Data
Data:

Contains database context classes (AuthDbContext and BlogRazorDbContext) responsible for handling authentication and main application data.

### Models

Houses domain models (BlogPost, BlogPostComment, and BlogPostLike) representing core entities within the application.

### Repositories


Implements repositories for various database operations, including user-related functionality.

### Controllers

Contains API controllers handling HTTP requests and interfacing with repositories.

The project structure is designed to provide a clear separation of concerns, making it organized and maintainable. Key components include data models, database context, repositories, and controllers, each contributing to specific aspects of the application's functionality.
