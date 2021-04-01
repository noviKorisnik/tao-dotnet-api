[tao-dotnet-api](https://github.com/noviKorisnik/tao-dotnet-api#readme)
___
### snapshot002
## the tao of programming
Just a book, which's content can be found on the net, also not bad to read, and here now as topic to play with to demonstrate some work with data.
## get book text
**HtmlAgilityPack** is one tool to work with html resources. It will be used here to grab book text from the net, parse it in nice structures and save good local copy we can use later.
```
dotnet add package HtmlAgilityPack
```
## some models to represent tao structure
**Tao** represents the whole world in our case and it has books. **Book** can have chapters. **Chapter** has paragraphs. **Paragraph** is with some text, readable. All of that we can find as classes in **_Models_** directory.
## grab, parse, whatever, and save to json
Class **TaoParser** is made to catch one page from the next which has the tao! and then go through it's document nodes to create structure which fits in our model classes. Nothing too fancy and also too specialized for how html is organized on one specific page. At the end, static method _GrabTao_ should be able to return one Tao model with complete structure and text contained in book, wow.

Class **TaoSaver** can _SaveTao_ hopefully in the project root and we could get our local copy. It transforms Tao structure to json and saves it in that way...
## run somehow
Existing **WeatherForecastController** is expanded with default post route, which calls to save Tao, yes.
```
dotnet run
```
And... our api should be running, we can test it somehow, like to go on https://localhost:5001/swagger/index.html - that is swagger, just some cool tool to see what our api exposes and to test how it works - find post method of only controller, expand it, "Try it out" and "Execute" - what happened? Check for **Tao.json** file in project root folder, please.
___
| [Previous](https://github.com/noviKorisnik/tao-dotnet-api/tree/snapshot001#readme) | [Home](https://github.com/noviKorisnik/tao-dotnet-api#readme) | [Next](https://github.com/noviKorisnik/tao-dotnet-api/tree/snapshot003#readme) |
| :-: | :-: | :-: |
___
