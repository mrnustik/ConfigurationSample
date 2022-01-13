using Microsoft.Extensions.Configuration;

IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();

configurationBuilder
    .AddJsonFile("appsettings.json")
    .AddXmlFile("appsettings.xml")
    .AddUserSecrets<Program>()
    .AddEnvironmentVariables()
    .AddCommandLine(args);

var configurationRoot = configurationBuilder.Build();

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("Logging configuration:");
Console.ForegroundColor = ConsoleColor.Blue;
var loggingConfigurationSection = configurationRoot.GetRequiredSection("Logging");
var loggingLogLevelConfigurationSection = loggingConfigurationSection.GetRequiredSection("LogLevel");
var defaultLogLevelConfigurationValue = loggingLogLevelConfigurationSection["Default"];
Console.WriteLine($"Logging:LogLevel:Default = {defaultLogLevelConfigurationValue}");
Console.WriteLine();


Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("My key configuration");
Console.ForegroundColor = ConsoleColor.Blue;
var myKeyValue = configurationRoot["MyKey"];
Console.WriteLine($"MyKey = {myKeyValue}");