[tao-dotnet-api](https://github.com/noviKorisnik/tao-dotnet-api)
___
### snapshot003
## cleaning
With run of TaoSaver we got our copy of Tao, so we don't need to seek for it on the net... and with that also we don't require use of saver, parser and used library.
```
dotnet remove package HtmlAgilityPack
```
Also delete classes TaoSaver, TaoParser, and WeatherForecast. We'll keep WeatherForecastController for while, just for testing purposes (need to remove references to TaoSaver and WeatherForecast to avoid erros, yes).
___
| [Previous](https://github.com/noviKorisnik/tao-dotnet-api/tree/snapshot002)| [Home](https://github.com/noviKorisnik/tao-dotnet-api) | [Next](https://github.com/noviKorisnik/tao-dotnet-api/tree/snapshot004) |
| :-: | :-: | :-: |
___