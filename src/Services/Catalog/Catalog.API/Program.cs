var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Add service to the container
builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
})

// Configure the HTTP request pipeline
app.MapCarter();

app.Run();
