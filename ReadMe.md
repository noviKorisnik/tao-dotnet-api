[tao-dotnet-api](https://github.com/noviKorisnik/tao-dotnet-api)
___
### snapshot004
## repository
We added class **TaoRepository** to operate over database context. Since our example is rather simple and limited only to read operation from now on (we already put all data in database, no more changes), we are here with single repository which handles all model clases.

It has three get methods to retrieve class item with it's ancsestors and children (paragraphs are considered as primitives which have no meaning out of their chapter).

We also need to register repository in service collection, so class can be used for dependency injection. That is done in **Startup** class, method **_ConfigureServices_**, with added line:
``` c#
services.AddScoped<TaoRepository>();
```
## data transfer objects
The new classes, parallel to our models, are introduced. Those are data transfer objects (DTO) with sole purpose to be used for data transfer, something that can easely serialized and that contains only those fields we want to expose to outer world.

At this example, they are much look like their 'originals'... just to note they don't have to.
## mapper
The idea is that we get object from database and transform it to DTO. To ease the process, we introduce mapper, which can do assigning matching properties with less code.

## service
## controller
___
| [Previous](https://github.com/noviKorisnik/tao-dotnet-api/tree/snapshot003)| [Home](https://github.com/noviKorisnik/tao-dotnet-api) | [Next](https://github.com/noviKorisnik/tao-dotnet-api/tree/snapshot005) |
| :-: | :-: | :-: |
___