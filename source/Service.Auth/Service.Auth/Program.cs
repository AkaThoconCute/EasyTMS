using Service.Auth.Insfratructure.Configuration;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDatabaseConfigs();

builder.Services.AddAuthConfigs(builder.Configuration);

builder.Services.AddServiceConfigs();

builder.Services.AddControllers();

builder.Services.AddOpenApi(); // Learn more at https://aka.ms/aspnet/openapi

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
await app.CheckDatabase();

if (app.Environment.IsDevelopment())
{
  app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
