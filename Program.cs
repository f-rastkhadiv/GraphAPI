var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Register the repository for dependency injection
builder.Services.AddSingleton<IGraphRepository, GraphRepository>();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


// Ensure the HTTPS redirection middleware is added
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();