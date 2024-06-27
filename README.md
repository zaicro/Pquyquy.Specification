# Pquyquy.Specification

Pquyquy.Specification is a .NET library that forms part of the Pquyquy project group. This provides functions to interconnect the application and persistence layers. The idea of this project is to allow greater decoupling between these layers. This project is required for the functioning of the Pquyquy.Persistence.SQL project.

## Table of Contents

- [Installation](#installation)
- [Usage](#usage)
- [License](#license)

## Installation

Currently, the `Pquyquy.Specification` NuGet package is not available in the NuGet Gallery. You will need to download the project source code and generate the NuGet package locally. Follow these steps to get started:

   ```bash
   #1. Clone the repository or download the source code:
   git clone [URL]
   #2. Navigate to the project directory:
   cd Pquyquy.Specification
   #3. Restore dependencies and build the project
   dotnet restore
   dotnet build
   #4. Generate the NuGet package
   dotnet pack -c Release
   #5. The NuGet package (Pquyquy.Specification.[version].nupkg) will be generated in the bin/Release directory of the project. You can then reference this local package in your other projects as needed.
   ```

Currently, the `Pquyquy.Specification.EntityFrameworkCore` NuGet package is not available in the NuGet Gallery. You will need to download the project source code and generate the NuGet package locally. Follow these steps to get started:

   ```bash
   #1. Clone the repository or download the source code:
   git clone [URL]
   #2. Navigate to the project directory:
   cd Pquyquy.Specification.EntityFrameworkCore
   #3. Restore dependencies and build the project
   dotnet restore
   dotnet build
   #4. Generate the NuGet package
   dotnet pack -c Release
   #5. The NuGet package (Pquyquy.Specification.EntityFrameworkCore.[version].nupkg) will be generated in the bin/Release directory of the project. You can then reference this local package in your other projects as needed.
   ```

## Usage

Inject IUnitOfWork, create the UnitOfWork and the necessary repositories.
   
   ```csharp
    public class [name]
    {
        private readonly IUnitOfWork _unitOfWork;

        public [name](IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task [methodName](Query request)
        {
            var repository = _unitOfWork.GetReadRepositoryBase<T>();
            var query = await repository.GetByQueryAsync($"select * from table");
        }
    }
   ```

Pquyquy.Specification Classes:
- IUnitOfWork: Manages transactions and coordinates changes across multiple repositories.
- ICreateRepositoryBase: Provides basic auditing properties for creating entities.
- IDeleteRepositoryBase: Combines AuditableEntity with auditing properties and an integer Id for deleting entities.
- IUpdateRepositoryBase: Defines methods and properties for updating entities with audit tracking.
- IReadRepositoryBase: Combines AuditableEntity with auditing properties and a Guid Id for reading entities.
- ReadSpecification: Encapsulates criteria and conditions for querying entities.

Pquyquy.Specification.EntityFrameworkCore Classes:
- UnitOfWork: Manages transactions and coordinates changes across multiple repositories.
- CreateRepositoryBase: EntityFrameworkCore logic for creating entities.
- DeleteRepositoryBase: EntityFrameworkCore logic for deleting entities.
- UpdateRepositoryBase: EntityFrameworkCore logic for updating entities.
- ReadRepositoryBase: EntityFrameworkCore logic for reading entities.
 
## License

This project is licensed under the MIT License. 