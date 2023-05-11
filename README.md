# EduLink

## Overview

Our platform connects students with experienced tutors and mentors.
Whether you're looking for a personalized tutoring session,
exam preparation or help with challenging coursework,
our community of educators provides the guidance and support you need.

### Tech stack

[![Made with PostgreSQL](https://img.shields.io/badge/PostgreSQL-15-40668d?style=flat-square&logo=postgresql&logoColor=white)](https://github.com/postgres/postgres "PostgreSQL")
[![Made with .NET](https://img.shields.io/badge/EF_Core-7-4c2dcc?style=flat-square&logo=dotnet&logoColor=white)](https://github.com/dotnet/efcore "EF Core")
[![Made with .NET](https://img.shields.io/badge/ASP.NET_Core-7-4c2dcc?style=flat-square&logo=dotnet&logoColor=white)](https://github.com/dotnet/aspnetcore "ASP.NET Core")
[![Made with React](https://img.shields.io/badge/React-18-387ca0?style=flat-square&logo=react&logoColor=white)](https://github.com/facebook/react "React")

## Getting started developing

### Repository

- Clone this repository: `git clone https://github.com/dariomrk/EduLink.git`

### Code conventions

#### Branches

All lowercase characters, kebab case, separated with forward-slash.  
Naming pattern: `[area]/[task-type]/[issue-id]-[task-name]`, e.g. `frontend/feat/login-screen` or `backend/fix/123-unique-username-validation`.

*Area:*
- nothing if changes are applied to both areas
- `backend` : if changes are applied only to the back-end side
- `frontend`: if changes are applied only to the front-end side

*Task type:*

- `feat`: developing new features (production code change)
- `fix`: squashing bugs (production code change)
- `docs`: changes to the documentation (no production code change)
- `test`: adding unit tests, managing unit tests (no production code change)
- `chore`: refactoring, managing outside dependencies, etc. (possible production code change)
- `temp`: temporary branches, experiments (no production code change)

*Issue-id:* GitHub issue identifier, add if applicable.

*Task name:* Task name or a short description of what you are doing, e.g. `add-confirmation-modal` or `refactor-user-controller`.

### Backend

#### Local setup

1. Move to the `backend` directory
2. In the `backend` root create the `.env` file in accordance with `.env.example` and `appsettings.Development.json`
3. In the Package Manager Console execute: `$env:ASPNETCORE_ENVIRONMENT = "Development"`
4. Set the Default project in the Package Manager Console to `Data`
5. To apply existing migrations execute: `Update-Database`
6. Start the application using the `Development` profile

### Frontend

*TODO*
