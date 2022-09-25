# Standards & Patterns

## Overview
In our day and age, millions of applications have been developed and are frequently utilized. The capacity of a developer to read and understand code is more significant than their ability to produce code. An ASP.NET Core MVC Web Application is handed in that will need to be enhanced and improved. Architectural patterns must be understood as well as pay specific attention to implementing coding principles and design patterns.

## Manual
- Stakeholders will be able to use the API from Azure or they can download the code from my GitHub repository and execute it from Visual Studio.
- When they execute it, it will lead them to their desired browser.
- You will find the Home, Register, Login tabs.
- Whereby they must register before utilizing it. 
- When you register, you must provide your email address and password.
- There you will find the Home, Zones, Categories, Devices, and Logout tab.
- You can either add new items, edit and delete items.

## Register 
<img src="/Images/Register.png" alt="Regsiter">

## Log in 
<img src="/Images/LogIn.png" alt="Log in">

## Home After Loggin in
<img src="/Images/Home.png" alt="Home">

### Credentials to use:
- Before the user can use any of the tabs the have to log in since each and every page is Authorized. You can log in with the following Credentials:

| Credentials   | User            | Alternatively         |
| :------------ |:---------------:| :--------------:|
| Username      | john@gmail.com  | sue@gmail.com   |   
| Password      |NrdgmeQAEj.Q6f.  | FV9PHyvin.n9ZBg |


## Phase 1 - GitHub Administration
- While I'm in training, I have created & configured my GitHub repository.

## Phase 2 - Project Setup
- I have forked the existing GitHub repository.
- The development branch has been created.
- Added a connection string to the appsettings.json file

## Phase 3 - Design Pattern Implementation
## Design Patterns
Repositories are classes or components that encapsulate the logic required to access data sources. 
They centralize common data access functionality, providing better maintainability and decoupling the infrastructure or technology used to access databases from the domain model layer.An abstraction layer between the data access layer and the business logic layer of an application
A more loosely coupled approach to data access. 
Create the data access logic in a separate class, or set of classes, called a repository with the responsibility of persisting the application's business model.
-  Repository classes have been created for Devices, Zones and Categories.
<img src="/Images/Repository.png" alt="Repo">

### Tier 2 Implementation
- A layer (Repository) will be created in between the DbContext and the Controller protect the two from each other and cause less coupled implementation that is easier to maintain.
- The code that will be in the controllers will be moved to the Repositories and it be making use of the DbContext and implementing the code. 
- The Controllers will just call the methods from the Repositories.
- All the repositories will inherit from the same interface (IGenericRepository) since they all have the same methods.
- All the methods woll be moved to the IGenericRepository 
- The interface will be used by all the entities to interact with the DbContext
<img src="/Images/Interfaces.png" alt="Interfaces">

| Repository           | Description |
| -------------------- | ---------------------------------------------------------------------------------------------------------- |
| GenericRepository    | Implements all methods.                                                                                    |
| IGenericRepository   | Abstract the implementation, it inherits all the methods. Used by all entities to interact with DbContext. |
| CategoriesRepository | Uses the DbConext and inherits the methods.                                                                |
| ICategoriesRepository| Inherits the IGenericRepository interface.                                                                 |
| CategoriesController | Instatiates the categoryRepository.                                                                        |

## Dependency Injection
Dependency injection is a design pattern in which an object does not create it dependent classes, but asks for it.

<img src="/Images/DependencyInjection.png" alt="Depedency">

