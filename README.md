# Configuration sample

[![.NET](https://github.com/mrnustik/ConfigurationSample/actions/workflows/dotnet.yml/badge.svg)](https://github.com/mrnustik/ConfigurationSample/actions/workflows/dotnet.yml)

This solutions contains two sample projects for showing the powers of .NET `Micrososoft.Extensions.Configuration`
package:

- `ConfigurationSample.Console` is a console app that directly creates the configuration builder with custom order of
  configuration sources
- `ConfigurationSample.WebApi` is a ASP.NET Core Web API with the default `IConfigurationBuilder` settings provided by
  the `WebApplicationBuilder`