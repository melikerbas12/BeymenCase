using BeymenCase.Core.Keys;
using BeymenCase.Core.Models;
using BeymenCase.Core.Models.Dtos.Setting;
using BeymenCase.Core.Utilities.Exceptions;
using BeymenCase.Data.UnitOfWork;
using BeymenCase.Service.Contracts;
namespace BeymenCase.Service.Services
{
    public class SettingService : ISettingService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SettingService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BoolRef> Delete(int id, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.SettingRepository.GetByIdAsync(id, cancellationToken);

            if (entity == null)
                throw new NotFoundException(ResponseCode.DatabaseException, ErrorMessageKey.SettingNotFound);

            entity.ModifiedDate = DateTime.Now.ToUniversalTime();

            _unitOfWork.SettingRepository.SoftRemove(entity);
            _unitOfWork.SettingRepository.Update(entity);
            await _unitOfWork.Complete(cancellationToken);

            return true;
        }

        public async Task<SettingDto> GetById(int id, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.SettingRepository.GetByIdAsync(id, cancellationToken);

            if (entity == null)
                throw new NotFoundException(ResponseCode.DatabaseException, ErrorMessageKey.SettingNotFound);

            return entity.Contract();
        }

        public async Task<PagedResult<SettingDto>> GetSettings(int page, int pageSize, string applicationName, string? name, string? type, string? value)
        {
            var entities = await _unitOfWork.SettingRepository.GetSettings(page, pageSize, applicationName, name, type, value);
            if (!entities.Results.Any())
                throw new NotFoundException(ResponseCode.DatabaseException, ErrorMessageKey.SettingNotFound);
            return entities.Contract();
        }

        public async Task<BoolRef> Create(SettingCreateDto model, CancellationToken cancellationToken)
        {
            var entity = model.Contract();

            await _unitOfWork.SettingRepository.AddAsync(entity);
            await _unitOfWork.Complete(cancellationToken);

            return true;
        }

        public async Task<BoolRef> Update(SettingUpdateDto model, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.SettingRepository.GetByIdAsync(model.Id, cancellationToken);

            if (entity == null)
                throw new NotFoundException(ResponseCode.DatabaseException, ErrorMessageKey.SettingNotFound);

            entity.Name = model.Name;
            entity.Type = model.Type;
            entity.Value = model.Value;
            entity.ApplicationName = model.ApplicationName;
            entity.IsActive = model.IsActive;
            entity.ModifiedDate = DateTime.Now.ToUniversalTime();

            _unitOfWork.SettingRepository.Update(entity);
            await _unitOfWork.Complete(cancellationToken);

            return true;
        }
    }
}