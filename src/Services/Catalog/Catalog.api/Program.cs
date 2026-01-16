var builder = WebApplication.CreateBuilder(args);
var assembly = typeof(Program).Assembly;
//Add services to the container 
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(assembly);
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));

});
builder.Services.AddValidatorsFromAssembly(assembly);

builder.Services.AddCarter();

builder.Services.AddMarten(opt => opt.Connection(builder.Configuration.GetConnectionString("Database")!));

builder.Services.AddExceptionHandler<CustomExceptionHandler>();
var app = builder.Build();
//configure the Http request Pipline 

app.MapCarter();

app.UseExceptionHandler(options => { });

app.Run();
