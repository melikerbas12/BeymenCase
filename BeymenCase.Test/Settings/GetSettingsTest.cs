using BeymenCase.Core.Models;
using BeymenCase.Core.Models.DataModels;
using BeymenCase.Core.Models.Dtos.Setting;
using BeymenCase.Core.Utilities.Exceptions;
using BeymenCase.Data.UnitOfWork;
using BeymenCase.Service.Services;
using BeymenCase.Test.FakerData;
using BeymenCase.Test.Helper;
using MapsterMapper;
using Moq;

namespace BeymenCase.Test.Settings
{
    public class GetSettingsTest
    {
        private readonly SettingService _settingService;
        private readonly Mock<ISettingService> _settingServiceMock;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly FakerSetting _fakerSetting;
        private readonly IMapper _mapper;

        public GetSettingsTest()
        {
            var mapper = AddMapsterForUnitTests.GetMapper();
            _fakerSetting = new FakerSetting();
            _settingServiceMock = new Mock<ISettingService>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _settingService = new SettingService(_unitOfWorkMock.Object);
        }

        [Fact]
        public async Task Should_NotFoundException_When_SettingsAreNull()
        {
            var page = _fakerSetting.Page;
            var pageSize = _fakerSetting.PageSize;
            var setting = _fakerSetting.Setting;

            _unitOfWorkMock.Setup(_unitOfWork => _unitOfWork.SettingRepository.GetSettings(page, pageSize, setting.ApplicationName, setting.Name, setting.Type, setting.Value))
                      .ReturnsAsync(new PagedResult<Setting>());

            await Assert.ThrowsAsync<NotFoundException>(async () => await
                 _settingService.GetSettings(page, pageSize, setting.ApplicationName, setting.Name, setting.Type, setting.Value));
        }

        [Fact]
        public async Task Should_PagedResult_When_GetSettingsSuccess()
        {
            var page = _fakerSetting.Page;
            var pageSize = _fakerSetting.PageSize;
            var setting = _fakerSetting.Setting;
            var pagedSettings = _fakerSetting.PagedSetting;

            _unitOfWorkMock.Setup(_unitOfWork => _unitOfWork.SettingRepository.GetSettings(page, pageSize, setting.ApplicationName, setting.Name, setting.Type, setting.Value))
                      .ReturnsAsync(pagedSettings);

            var result = await _settingService.GetSettings(page, pageSize, setting.ApplicationName, setting.Name, setting.Type, setting.Value);

            Assert.NotNull(result);
            Assert.IsType<PagedResult<SettingDto>>(result);
        }
    }
}