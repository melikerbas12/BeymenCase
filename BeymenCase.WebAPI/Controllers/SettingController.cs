using BeymenCase.Core.Models;
using BeymenCase.Core.Models.Dtos.Setting;
using BeymenCase.Service.Services;
using Microsoft.AspNetCore.Mvc;
using SahaBT.Retro.Core.Utilities;
using SahaBT.Retro.Core.Validations.Agreements;

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
    public async Task<IActionResult> Get(int id)
    {

        var response = await _settingService.GetById(id);
        return Ok(response);

    }

    [FluentValidate(typeof(SettingCreateDtoValidation))]
    [HttpPost]
    [ProducesResponseType(typeof(BaseResponse<BoolRef>), 200)]
    public async Task<IActionResult> Post(SettingCreateDto model)
    {

        var response = await _settingService.Insert(model);
        return Ok(response);

    }

    [FluentValidate(typeof(SettingUpdateDtoValidation))]
    [HttpPut]
    [ProducesResponseType(typeof(BaseResponse<BoolRef>), 200)]
    public async Task<IActionResult> Put(SettingUpdateDto model)
    {

        var response = await _settingService.Update(model);
        return Ok(response);

    }

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(BaseResponse<BoolRef>), 200)]
    public async Task<IActionResult> Delete(int id)
    {

        var response = await _settingService.Delete(id);
        return Ok(response);

    }
}

