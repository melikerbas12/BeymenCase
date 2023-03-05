using BeymenCase.ConfLib;
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
    public SettingController(ISettingService settingService,IConfigurationReader configurationReader)
    {
        _settingService = settingService;
        _configurationReader = configurationReader;
    }

    [HttpGet]
    [ProducesResponseType(typeof(BaseResponse<PagedResult<SettingDto>>), 200)]
    public async Task<IActionResult> GetSettings(int page, int pageSize, string applicationName, string? name, string? type, string? value)
    {
        var response = await _settingService.GetSettings(page, pageSize, applicationName, name, type, value);
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
    [HttpGet("library")]
    [ProducesResponseType(typeof(BaseResponse<BoolRef>), 200)]
    public async Task<IActionResult> Library()
    {
        var response = await _configurationReader.GetValue<string>("SiteName");
        return Ok(response);
    }
}