[tao-dotnet-api](https://github.com/noviKorisnik/tao-dotnet-api#readme)
___
### snapshot003
## cleaning
With run of TaoSaver we got our copy of Tao, so we don't need to seek for it on the net... and with that also we don't require use of saver, parser and used library.
```
dotnet remove package HtmlAgilityPack
```
Also delete classes TaoSaver, TaoParser, and WeatherForecast. We'll keep WeatherForecastController for while, just for testing purposes (need to remove references to TaoSaver and WeatherForecast to avoid erros, yes).
## add database
This app can act as the real one if it would work with database, so we will add one.
```
dotnet add package Microsoft.EntityFrameworkCore.InMemory
```
That is some database package we can use now!

The brand new class **TaoContext** will help us to communicate with database. It has defined datasets for our models.

And one extension is added, so we can fill database with data contained in json file. (... I have some doubts that the same can be done somehow better, but it appears that this works so far...)

And, we need to add the following code in **Startup** class, it's method **_ConfigureServices_** so we can use our database context where we need it:
```c#
services.AddDbContext<TaoContext>(opt => opt.UseInMemoryDatabase("TaoInMemory"));
```
This works if we also has this using directive:
```c#
using Microsoft.EntityFrameworkCore;
```
## test it
Now, WeatherForecastController is adapted to test our db collections. We use TaoContext with dependency injection, neat. And one get method per collection. Go, run and test it in swagger before we continue with the next snapshot...
___
| [Previous](https://github.com/noviKorisnik/tao-dotnet-api/tree/snapshot002#readme) | [Home](https://github.com/noviKorisnik/tao-dotnet-api#readme) | [Next](https://github.com/noviKorisnik/tao-dotnet-api/tree/snapshot004#readme) |
| :-: | :-: | :-: |
___
