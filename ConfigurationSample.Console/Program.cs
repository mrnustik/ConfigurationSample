using ConfigurationSample.Console;
using Microsoft.Extensions.Configuration;

#region Configuration building

IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();

configurationBuilder
    .AddJsonFile("appsettings.json")
    .AddXmlFile("appsettings.xml")
    .AddUserSecrets<Program>()
    .AddEnvironmentVariables()
    .AddCommandLine(args);

var configurationRoot = configurationBuilder.Build();

#endregion

#region SingleValue

//One value configured from multiple sources
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("My key configuration");
Console.ForegroundColor = ConsoleColor.Blue;
var myKeyValue = configurationRoot["MyKey"];
Console.WriteLine($"MyKey = {myKeyValue}");

#endregion

#region Sections

//Accessing nested sections 
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("Logging configuration:");
Console.ForegroundColor = ConsoleColor.Blue;
var loggingConfigurationSection = configurationRoot.GetRequiredSection("Logging");
var loggingLogLevelConfigurationSection = loggingConfigurationSection.GetRequiredSection("LogLevel");
var defaultLogLevelConfigurationValue = loggingLogLevelConfigurationSection["Default"];
Console.WriteLine($"Logging:LogLevel:Default = {defaultLogLevelConfigurationValue}");
Console.WriteLine();

#endregion

#region Binding

//Binding existing value to a C# class
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("Binded configuration configuration:");
Console.ForegroundColor = ConsoleColor.Blue;
var serverNameConfigurationSection = configurationRoot.GetRequiredSection("ServerName");
var serverNameOptions = serverNameConfigurationSection.Get<ServerNameOptions>();
Console.WriteLine($"Binded server name options: {serverNameOptions.Name}");

#endregion