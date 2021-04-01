[tao-dotnet-api](https://github.com/noviKorisnik/tao-dotnet-api#readme)
___
### snapshot005
## cors
I hope we managed to provide some neat service. It would be nice if it could be used. Well, for some security concerns, default usage of service is restricted to the same domain where the service is hosted itself. So, if we want to provide additional usage, it could be done using cross-origin resource sharing (cors). The new definition goes again to Startup and it's ConfigureServices (there is added address of client which should use this service - another project, it will be linked somehow to this one). In pair with that in Configure method is needed that middleware layer UseCors is included, those layers should be stacked in specific order, cors goes after routing...
## db bootstrap revisited
Good, better db bootstrap has been found! This is added to Startup:
``` c#
private void bootstrapDb()
{
    DbContextOptionsBuilder<TaoContext> builder =
        new DbContextOptionsBuilder<TaoContext>();
    builder.UseInMemoryDatabase("TaoInMemory");
    TaoContext context = new TaoContext(builder.Options);
    context.BootstrapTaoDb();
}
```
... and it is called at the end of Configure method, which is called at the end of application boot process.

TaoContext constructor does not have some silly code any more, and BootstrapTaoDb method is executed only once during startup proces, so if it fails, app will end... however, without data in database the whole app does not make any sense, so it sounds OK.
## handling bad request
Minor changes in controller - if something goes wrong, Bad request response is returned instead of ugly exception whatsoever... like this one:
``` c#
[HttpGet()]
public ActionResult<TaoDto> GetTao()
{
    try
    {
        return _service.GetTao();
    }
    catch
    {
        return BadRequest();
    }
}
```
___
| [Previous](https://github.com/noviKorisnik/tao-dotnet-api/tree/snapshot004#readme) | [Home](https://github.com/noviKorisnik/tao-dotnet-api#readme) |
| :-: | :-: |
___
