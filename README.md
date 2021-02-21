# Web API Documentations

### Migrations
##### Add Migrations
##### Through Terminal Wizard: 
Start the WebBackend project from the UI or by running `dotnet run` in the WebBackend directory, 
you will be asked to enter a Migration name within 3 seconds, 
if you have any migrations to create, enter `y`. 

**The project will start normally after 3 seconds if
no action was occurred.**
A migration file will be created in project ``Migrations``, and will be applied to the database
on the next project startup. The file will be added automatically 
to the staging area of git, on your local machine.

--- 

##### Through Terminal Manually:
To Add Migrations for your entities changes, execute in the terminal 

`dotnet ef migrations add <migrationOrChangeName> --project DbEntities`


##### Update Database
The database is updated automatically on the startup of WebBackend.csproj

To update the Database from the added migrations manually, execute the following

`dotnet ef database update --project DbEntites`

**Note:** The project name after --project can change, depending on where the migrations are located

---