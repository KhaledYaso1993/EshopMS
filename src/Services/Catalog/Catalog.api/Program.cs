
var builder = WebApplication.CreateBuilder(args);

//Add services to the container 
builder.Services.AddCarter();

builder.Services.AddMediatR(config => { config.RegisterServicesFromAssembly(typeof(Program).Assembly); });

builder.Services.AddMarten(opt => opt.Connection(builder.Configuration.GetConnectionString("Database")!));

var app = builder.Build();
//configure the Http request Pipline 

app.MapCarter();

app.Run();
