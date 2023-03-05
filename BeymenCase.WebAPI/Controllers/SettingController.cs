using BeymenCase.ConfLib.Services;
using BeymenCase.Core.Models;
using BeymenCase.Core.Models.Dtos.Setting;
using BeymenCase.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace BeymenCase.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class SettingController : BaseController
{
    private readonly ISettingService _settingService;
    private readonly IConfigurationReader _configurationReader;
    private readonly ILogger<SettingController> _logger;
    public SettingController(ISettingService settingService, IConfigurationReader configurationReader, ILogger<SettingController> logger)
    {
        _settingService = settingService;
        _configurationReader = configurationReader;
        _logger = logger;
    }

    [HttpGet]
    [ProducesResponseType(typeof(BaseResponse<PagedResult<SettingDto>>), 200)]
    public async Task<IActionResult> GetSettings(int page, int pageSize, string applicationName, string? name, string? type, string? value)
    {
        var response = await _settingService.GetSettings(page, pageSize, applicationName, name, type, value);
        _logger.LogInformation("Data : " + response);
        return Ok(response);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(BaseResponse<SettingDto>), 200)]
    public async Task<IActionResult> Get(int id, CancellationToken cancellationToken)
    {
        var response = await _settingService.GetById(id, cancellationToken);
        return Ok(response);
    }

    [HttpPost]
    [ProducesResponseType(typeof(BaseResponse<BoolRef>), 200)]
    public async Task<IActionResult> Post(SettingCreateDto model, CancellationToken cancellationToken)
    {
        var response = await _settingService.Create(model, cancellationToken);
        _logger.LogInformation("Added : " + model);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(typeof(BaseResponse<BoolRef>), 200)]
    public async Task<IActionResult> Put(SettingUpdateDto model, CancellationToken cancellationToken)
    {
        var response = await _settingService.Update(model, cancellationToken);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(BaseResponse<BoolRef>), 200)]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        var response = await _settingService.Delete(id, cancellationToken);
        return Ok(response);
    }
    [HttpGet("library/{name}")]
    [ProducesResponseType(typeof(BaseResponse<BoolRef>), 200)]
    public async Task<IActionResult> Library(string name)
    {
        var response = await _configurationReader.GetValue<string>(name);
        return Ok(response);
    }
}