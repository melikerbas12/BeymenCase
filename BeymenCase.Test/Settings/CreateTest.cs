using BeymenCase.Core.Models;
using BeymenCase.Core.Models.DataModels;
using BeymenCase.Core.Models.Dtos.Setting;
using BeymenCase.Data.Repositories;
using BeymenCase.Data.UnitOfWork;
using BeymenCase.Service.Services;
using BeymenCase.Test.FakerData;
using BeymenCase.Test.Helper;
using MapsterMapper;
using Moq;

namespace BeymenCase.Test.Settings
{
    public class CreateTest
    {
        private readonly SettingService _settingService;
        private readonly Mock<ISettingService> _settingServiceMock;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly FakerSetting _fakerSetting;
        private readonly IMapper _mapper;

        public CreateTest()
        {
            var mapper = AddMapsterForUnitTests.GetMapper();
            _fakerSetting = new FakerSetting();
            _settingServiceMock = new Mock<ISettingService>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _settingService = new SettingService(_unitOfWorkMock.Object);
        }

        [Fact]
        public async Task Should_BoolRef_When_AddAsyncSuccess()
        {
            var settingCreateDto = _fakerSetting.CreateDto;
            var setting = _fakerSetting.Setting;

            _unitOfWorkMock.Setup(_unitOfWork => _unitOfWork.SettingRepository.AddAsync(It.IsAny<Setting>()))
                      .ReturnsAsync(() => setting);

            _unitOfWorkMock.Setup(_unitOfWork => _unitOfWork.Complete(default))
            .ReturnsAsync(() => 1);

            var result = await _settingService.Create(settingCreateDto, default);

            Assert.NotNull(result);
            Assert.IsType<BoolRef>(result);
        }
    }
}