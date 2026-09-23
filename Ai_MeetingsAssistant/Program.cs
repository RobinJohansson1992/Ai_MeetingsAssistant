using Ai_MeetingsAssistant.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var aiProvider = builder.Configuration["Ai:Provider"];

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddHttpClient();

if (aiProvider == "Ollama")
{
    builder.Services.AddScoped<AIiService, OllamaService>();
}

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
