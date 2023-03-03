using BeymenCase.Core.Models;
using BeymenCase.Core.Models.Dtos.Setting;
using BeymenCase.Core.Utilities;
using BeymenCase.Core.Validations;
using BeymenCase.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace BeymenCase.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class SettingController : BaseController
{
    private readonly ISettingService _settingService;

    public SettingController(ISettingService settingService)
    {
        _settingService = settingService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(BaseResponse<PagedResult<SettingDto>>), 200)]
    public async Task<IActionResult> GetSettings(int page, int pageSize, string name, string type, string value)
    {

        var response = await _settingService.GetSettings(page, pageSize, name, type, value);
        return Ok(response);

    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(BaseResponse<SettingDto>), 200)]
    public async Task<IActionResult> Get(int id, CancellationToken cancellationToken)
    {

        var response = await _settingService.GetById(id, cancellationToken);
        return Ok(response);

    }

    [FluentValidate(typeof(SettingCreateDtoValidation))]
    [HttpPost]
    [ProducesResponseType(typeof(BaseResponse<BoolRef>), 200)]
    public async Task<IActionResult> Post(SettingCreateDto model, CancellationToken cancellationToken)
    {

        var response = await _settingService.Create(model, cancellationToken);
        return Ok(response);

    }

    [FluentValidate(typeof(SettingUpdateDtoValidation))]
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
}

