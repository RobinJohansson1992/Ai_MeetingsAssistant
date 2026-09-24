using Ai_MeetingsAssistant.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var aiProvider = builder.Configuration["Ai:Provider"];

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddHttpClient();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

if (aiProvider == "Ollama")
{
    builder.Services.AddScoped<IAiService, OllamaService>();
}
builder.Services.AddScoped<AssistantService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
