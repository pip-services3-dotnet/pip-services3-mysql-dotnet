# <img src="https://uploads-ssl.webflow.com/5ea5d3315186cf5ec60c3ee4/5edf1c94ce4c859f2b188094_logo.svg" alt="Pip.Services Logo" width="200"> <br/> MySQL components for .Net Changelog

## <a name="3.5.0"></a> 3.5.0 (2023-12-15)

### Breaking Changes
* Migrate to .NET 8.0

## <a name="3.4.0"></a> 3.4.0 (2022-08-04)

### Breaking Changes
* Migrate to .NET 6.0

## <a name="3.3.1"></a> 3.3.1 (2021-12-21)

### Bug Fixes
* Fixed OFFSET parameter for requests

## <a name="3.3.0"></a> 3.3.0 (2021-09-01)

### Breaking Changes
* Migrate to .NET Core 5.0

## <a name="3.2.0"></a> 3.2.0 (2021-06-10) 

### Features
* Updated references as PipServices3.Components have got minor changes

## <a name="3.1.1"></a> 3.1.1 (2021-05-31)

### Features
* Added MySQL connection via SSH tunnel

## <a name="3.1.0"></a> 3.1.0 (2021-02-19) 

### Features
* Renamed AutoCreateObject to EnsureSchema
* Added DefineSchema method that shall be overriden in child classes
* Added ClearSchema method

### Breaking changes
* Method AutoCreateObject is deprecated and shall be renamed to EnsureSchema

## <a name="3.0.1"></a> 3.0.1 (2020-10-27)

### Features
* added convert to json

### Bug Fixes
* fixed error message
* fixed project version

## <a name="3.0.0"></a> 3.0.0 (2020-10-22)

Initial public release

### Features
* Added DefaultSqlServerFactory
* Added SqlServerConnectionResolver
* Added IdentifiableJsonSqlServerPersistence
* Added IdentifiableSqlServerPersistence
* Added IndexOptions
* Added SqlServerConnection
* Added SqlServerPersistence

### Bug Fixes
No fixes in this version

