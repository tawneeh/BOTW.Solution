# _Breath of the Wild_

#### _Many to Many Database Relationship Practice for Epicodus_ 
#### _DATE 01.06.2021_

#### By _**Tawnee Harris, Patrick Osten and Jerrod Styrk**_

## Description

This application...

## Setup/Installation Requirements

Software Requirements
* An internet browser of your choice; I prefer Chrome
* A code editor; I prefer VSCode
* .NET Core
* MySQL
* MySQL Workbench

Open by Downloading or Cloning
* Navigate to <>
* Download this repository to your computer by clicking the green Code button and 'Download Zip'
* Or clone the repository

AppSettings
* This project requires an AppSettings file. Create your `appsettings.json` file in the main `BOTW` directory. 
* Format your `appsettings.json` file as follows including your unique password that was created at MySqlWorkbench installation:
```
{
  "ConnectionStrings":{
      "DefaultConnection": "Server=localhost;Port=3306;database=botw;uid=root;pwd=<YourPassword>;"
  }
}
```
* Update the Server, Port, and User ID as needed.

Import Database using Entity Framework Core
* Navigate to UniversityRegistrar.Solution/UniversityTracker and type `dotnet ef migrations add <MigrationName>` into the terminal
* Then, type `dotnet ef database update` into the terminal to create your database tables.

DB SQL Schema Snippet
* Paste this Schema Create Statement into your SQL Workbench to create this database and its tables.
```

```

SQL Database Design
<center>
<img style="width: 50% height: 50%" src="./ReadMeAssets/">
</center>

Launch this Application
* Navigate to BOTW.Solution/BOTW and type `dotnet restore` into the terminal
* Then, in the same project folder, type `dotnet build` into the terminal followed by `dotnet run`
* Peruse this application at your leisure

## Known Bugs

This application has no known bugs. 

## Support and contact details

* Please feel free to reach out to Tawnee anytime at <tawneeh@icloud.com> 
* Or Patrick Osten at <posten.coding@gmail.com>
* Or Jerrod Styrk at <jstyrk@citadel.edu>

## Technologies Used

* [Bootstrap Components](https://getbootstrap.com/docs/3.3/components/)
* C#
* Razor
* Entity Framework Core
* MySql
* MySql Workbench

### License

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

Copyright (c) 2020 **_Tawnee Harris, Patrick Osten and Jerrod Styrk_**

Co-authored-by: Jerrod Styrk <jstyrk@citadel.edu>
Co-authored-by: Patrick Osten <posten.coding@gmail.com>