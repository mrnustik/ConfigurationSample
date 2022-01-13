using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ConfigurationSample.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ConfigurationController : ControllerBase
{
    private readonly IConfigurationRoot _configurationRoot;
    private readonly ServerNameOptions _serverNameOptions;

    public ConfigurationController(IOptions<ServerNameOptions> serverNameOptions, IConfigurationRoot configurationRoot)
    {
        _configurationRoot = configurationRoot;
        _serverNameOptions = serverNameOptions.Value;
    }

    [HttpGet("/server-name")]
    public ActionResult<string> GetServerName()
    {
        return Ok(_serverNameOptions.Name);
    }

    [HttpGet("/options")]
    public ActionResult<ICollection<IConfigurationSection>> GetAllOptions()
    {
        return Ok(_configurationRoot.GetChildren());
    }
}