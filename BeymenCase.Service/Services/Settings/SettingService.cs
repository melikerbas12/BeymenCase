using BeymenCase.Core.Contracts;
using BeymenCase.Core.Keys;
using BeymenCase.Core.Models;
using BeymenCase.Core.Models.DataModels;
using BeymenCase.Core.Models.Dtos.Setting;
using BeymenCase.Core.Utilities.Exceptions;
using BeymenCase.Data.UnitOfWork;
using BeymenCase.Service.Utilities.Helpers;

namespace BeymenCase.Service.Services
{
    public class SettingService : ISettingService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SettingService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BoolRef> Delete(int id)
        {
            var entity = await _unitOfWork.SettingRepository.GetByIdAsync(id);

            if (entity == null)
                throw new NotFoundException(ResponseCode.DatabaseException, ErrorMessageKey.SettingNotFound);

            entity.ModifiedDate = DateTime.Now;

            _unitOfWork.SettingRepository.SoftRemove(entity);
            _unitOfWork.SettingRepository.Update(entity);
            await _unitOfWork.Complete();

            return true;
        }

        public async Task<SettingDto> GetById(int id)
        {
            var entity = await _unitOfWork.SettingRepository.GetByIdAsync(id);

            if (entity == null)
                throw new NotFoundException(ResponseCode.DatabaseException, ErrorMessageKey.SettingNotFound);

            return entity.Contract();
        }

        public async Task<PagedResult<SettingDto>> GetSettings(int page, int pageSize, string name, string type, string value)
        {
            var entities = await _unitOfWork.SettingRepository.GetSettings(page, pageSize, name, type, value);
            return entities.Contract();
        }

        public async Task<BoolRef> Insert(SettingCreateDto model)
        {
            var entity = model.Contract();

            await _unitOfWork.SettingRepository.AddAsync(entity);
            await _unitOfWork.Complete();

            return true;
        }

        public async Task<BoolRef> Update(SettingUpdateDto model)
        {
            var entity = await _unitOfWork.SettingRepository.GetByIdAsync(model.Id);

            if (entity == null)
                throw new NotFoundException(ResponseCode.DatabaseException, ErrorMessageKey.SettingNotFound);

            var setting = MappingHelper.ConvertDtoModel<SettingUpdateDto, Setting>(model, entity);
            setting.ModifiedDate = DateTime.Now;

            _unitOfWork.SettingRepository.Update(setting);
            await _unitOfWork.Complete();

            return true;
        }
    }
}