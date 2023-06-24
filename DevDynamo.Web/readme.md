## EF Add Migrations

Compare and find diff (code vs database).
Generates C# migration scripts.

Run this code this project that host the DbContext

```
> dotnet ef migrations add <name>
> dotnet ef migrations remove // undo previous migration
```

#### Sample
```
> dotnet ef migrations add Initial
```

## EF Update database
Convert C# migration script => SQL script => Excecute.
Keep log in __EFMigrationHistory table
```
> dotnet ef database update
```

### EF CLI Tool
```
> set DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=True
> dotnet tool install dotnet-ef -g
```

---

### REST APIs

#### Projects
```
GET /api/v1/projects
```
```
GET /api/v1/projects/5
```

```
POST /api/v1/projects
```

Request payload:
```
{
  "name": "Demo 1",
  "workflow": "Default"
}

```
Response:
```
201 Created
```
```
400 Bad Request
{
   "error": "Workflow Default is not found"
}
```

