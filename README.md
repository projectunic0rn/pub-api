<p align="center">
  <img src="https://sharedstorage2.blob.core.windows.net/pub/main-logo.png" alt="Project Unicorn">
</p>

<p align="center">
  <a href="https://dev.azure.com/project-unicorn/pub/_apis/build/status/projectunic0rn.pub-api?branchName=master">
    <img src="https://dev.azure.com/project-unicorn/pub/_apis/build/status/projectunic0rn.pub-api?branchName=master" alt="Travis CI">
  </a>

  <a href="https://projectunicorn.net/">
    <img src="https://img.shields.io/badge/website-https://projectunicorn.net/-blue.svg" alt="Project Unicorn">
  </a>
</p>

<br />

## Quick start

```bash
git clone https://github.com/projectunic0rn/pub-api.git
cd pub-api/src/Pub

# Install dependencies
dotnet restore

# Run tests
dotnet test

# Develop
dotnet run --project API
```

## Directory Layout


    .
    ├── .github                 # GitHub files
    ├── docs                    # Documentation files
    ├── src                      
    │   ├── Pub          
    │   |   ├── API              # Service layer, code describing rest endpoints
    │   |   ├── Domain           # Domain layer, code describing domain objects/logic/validation
    │   |   ├── Infrastructure   # Persistence layer, code persisting to storage or message bus
    │   |   └── Tests            # Automated tests
    ├── infrastructure           # Infrastructure as code deployment scripts                      
    ├── ci                       # Continuous integration, build scripts                      
    └── README.md

## Documentation
- [Docs](./docs)
- [Contributing Guide](./CONTRIBUTING.md)
