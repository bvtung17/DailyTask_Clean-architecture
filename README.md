# Web API TaskDaily Project ( Clean Architeture )
## Tech Using
1. .NET 6
2. PostgreSQL
3. EF Core 
4. MediatR
5. FluentVaidation
6. Auto Mapper

### 1. Introduction
### 2. To Use
#### 1. Require 
    - Visual Studio
    - PostgreSQL
    - Chrome
    - .Net 6
#### 2. Change connection String In appseting.json
    - 
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
# Over View (CLean Architecture)
![alt text](https://blog.cleancoder.com/uncle-bob/images/2012-08-13-the-clean-architecture/CleanArchitecture.jpg)
### Domain
Entities encapsulate Enterprise wide business rules. 
### Infrastucture
Layer of interaction with DataBase
### Application
Data processing layer, login business
### API
Layer receives requests and interacts with users
