using WebApiAutores;

var builder = WebApplication.CreateBuilder(args);

var startUp = new StartUp(builder.Configuration);

startUp.CofigureServices(builder.Services);

var app = builder.Build();

startUp.Cofigure(app, app.Environment);

app.Run();