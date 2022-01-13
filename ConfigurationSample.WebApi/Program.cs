using ConfigurationSample.WebApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Workaround to have access to IConfigurationRoot through dependency injection
builder.Services.AddSingleton<IConfigurationRoot>(builder.Configuration);

builder.Services.Configure<ServerNameOptions>(
    builder.Configuration.GetRequiredSection("ServerName"));

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