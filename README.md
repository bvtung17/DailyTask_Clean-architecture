# Web API TaskDaily Project ( Clean Architeture )
## Purpose of this Project
##### [OJT Team] This is a learning project to prepare for my participation in a big project.
##### Web API Manage daily tasks using CleanArchitecture, User can perform CRUD, GetAll, GetById... ##
## Tech Using
1. Clean Architecture Partten
2. .NET 6
3. PostgreSQL
4. EF Core - Code First
5. MediatR Pipeline Validation
6. CQRS with MediatR Library
7. Fluent Vaidation
8. Repositoy Pattern - Unit Of Work
9. Cashing Memory
10. Auto Mapper
11. Swagger UI

# Overview
## 1.   Clean Architecture
![alt text](https://blog.cleancoder.com/uncle-bob/images/2012-08-13-the-clean-architecture/CleanArchitecture.jpg)

Clean architecture is an architecture that designs software based on dependency rules.
## Project includes architectural layers
### * Domain 
Entities encapsulate Enterprise wide business rules. 
1. Enities 
2. Common
### * Infrastucture
Layer of interaction with DataBase
1. DbContext
2. Repository
3. Unit of work
4. Caching
5. EF Configuation
### * Application
Data processing layer, login business
1. Service
2. Handler
3. Interface
### * API
Layer receives requests and interacts with users

## 2. Controller   



| API Daily Task                               | Description                 | Reqeust Body            | Response Body      |
| :---                                         |    :----                    |   :---:                 |  :----:            |
| Get /get-all-task?take={take}                | Get all tasks               |  int take               | List of Task       |
| Get /get-task-by-id?id={id}                  | Get Daily tasks by id       |  Guid id                | Daily Task Response|
| Get /get-task-by-user-id?userId={userId}     | Get Daily tasks by userId   |  Guid userId            | List of Daily Task |
| Post /create-task                            | Create Daily task           |  TaskDailyDto           | Daily Task Response|
| Put /update-task?id={id}                     | Update Daily task           |  Guid id; TaskDailyDto  | Daily Task Response|
| Delete /delete-task?id=                      | Delete Daily task           |  Guid id                |Daily Task Response |


| API User                                     | Description                 | Reqeust Body           | Response Body      |
| :---                                         |    :----                    |   :---:                |  :----:            |
| Get /get-all-user?take={take}                | Get all user                |  int take              | List of User       |
| Get /get-user-by-id?id={id}                  | Get user by id              |  Guid id               | User Response      |
| Post /create-user                            | Create user                 |  UserDto               | User Response      |
| Put /update-user?id={id}                     | Update user                 |  Guid id; UserDto      | User Response      |
| Delete /delete-user?id=                      | Delete user                 |  Guid id               | User Response      |


### 2. To Use
#### 1. Prerequisites 
    - Visual Studio
    - PostgreSQL
    - Chrome
    - .Net 6 SDK
#### 2. Change connection String In appseting.json
     
          "Server=localhost;Database=Test1;Username=USER_NAME;Password=PASS_WORD"
#### 3. Update DataBase
# Document
### 1. Sequence Diagram 
```mermaid
sequenceDiagram
   
        actor user
        autonumber
        user -> Controller : CRUD Action
        Controller -> MediatR : Send Request
        alt Request valid
            MediatR -> Validation : Validation Behavior
            Validation -> Handler : Command/Query Request
        else Valid Fail
            Validation --> MediatR : Valid Exeption
            MediatR --> Controller : Response
            Controller --> User : Response
        end
        Handler -> Service : CRUD Action
        Service -> UnitOfWork : Get Unit of work
        UnitOfWork -> Repository : Get Repository
        Repository -> DB : CRUD Action 
        DB --> Repository : Response
        Repository --> UnitOfWork :  Response 
        alt Create/Update/Delete
            UnitOfWork -> Db : Save Change
            Db --> UnitOfWork : Response
            UnitOfWork --> Service : Response
        else Get
            UnitOfWork --> Service :  Response
        end
        Service --> Handler :  Response
        Handler --> MediatR :  Response
        MediatR --> Controller :  Response
        Controller --> user :  Response 
```
@TunTun: Thank you! :shipit:

