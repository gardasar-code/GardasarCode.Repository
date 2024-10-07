[![build](https://github.com/gardasar-code/GardasarCode.Repository/actions/workflows/build.yml/badge.svg)](https://github.com/gardasar-code/GardasarCode.Repository/actions/workflows/build.yml) [![deploy](https://github.com/gardasar-code/GardasarCode.Repository/actions/workflows/deploy.yml/badge.svg)](https://github.com/gardasar-code/GardasarCode.Repository/actions/workflows/deploy.yml) [![NuGet Version](https://img.shields.io/nuget/v/GardasarCode.Repository.svg)](https://www.nuget.org/packages/GardasarCode.Repository/) ![NuGet Downloads](https://img.shields.io/nuget/dt/GardasarCode.Repository) ![GitHub License](https://img.shields.io/github/license/gardasar-code/GardasarCode.Repository)

# GardasarCode.Repository

## Specifications

```csharp
public abstract class UserSpecification
{
    public sealed class GetUserById : BaseSpecification<User>
    {
        public GetUserById(long id, bool asNoTracking)
        {
            AsNoTracking = asNoTracking;
            AddCriteria(i => i.Id == id);
        }
    }
}
```

## Repository

```csharp
var context = new DbContext(options);
var repo = new RepositoryBase<DbContext>(context);
var spec = new UserSpecification.GetUserById(user.Id, true);
var result = await repo.FirstOrDefaultAsync(spec);
```

> **Being supplemented.**
