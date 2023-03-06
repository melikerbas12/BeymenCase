using BeymenCase.Core.Models;
using BeymenCase.Core.Utilities.Exceptions;
using BeymenCase.Data.UnitOfWork;
using BeymenCase.Service.Services;
using BeymenCase.Test.FakerData;
using BeymenCase.Test.Helper;
using MapsterMapper;
using Moq;

namespace BeymenCase.Test.Settings
{
    public class DeleteTest
    {
        private readonly SettingService _settingService;
        private readonly Mock<ISettingService> _settingServiceMock;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly FakerSetting _fakerSetting;
        private readonly IMapper _mapper;

        public DeleteTest()
        {
            var mapper = AddMapsterForUnitTests.GetMapper();
            _fakerSetting = new FakerSetting();
            _settingServiceMock = new Mock<ISettingService>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _settingService = new SettingService(_unitOfWorkMock.Object);
        }

        [Fact]
        public async Task Should_NotFoundException_When_SettingIsNull()
        {

            _unitOfWorkMock.Setup(_unitOfWork => _unitOfWork.SettingRepository.GetByIdAsync(It.IsAny<int>(), default))
                      .ReturnsAsync(() => null);

            await Assert.ThrowsAsync<NotFoundException>(async () => await
                 _settingService.Delete(It.IsAny<int>(), default));
        }

        [Fact]
        public async Task Should_BoolRef_When_RemoveSuccess()
        {
            var setting = _fakerSetting.Setting;

            _unitOfWorkMock.Setup(_unitOfWork => _unitOfWork.SettingRepository.GetByIdAsync(It.IsAny<int>(), default))
                                 .ReturnsAsync(() => setting);

            _unitOfWorkMock.Setup(_unitOfWork => _unitOfWork.SettingRepository.SoftRemove(setting));

            _unitOfWorkMock.Setup(_unitOfWork => _unitOfWork.SettingRepository.Update(setting));

            _unitOfWorkMock.Setup(_unitOfWork => _unitOfWork.Complete(default))
            .ReturnsAsync(() => 1);

            var result = await _settingService.Delete(It.IsAny<int>(), default);

            Assert.NotNull(result);
            Assert.IsType<BoolRef>(result);
        }
    }
}