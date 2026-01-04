var builder = WebApplication.CreateBuilder(args);

//Add services to the container 
var app = builder.Build();
//configure the Http request Pipline 

app.Run();
