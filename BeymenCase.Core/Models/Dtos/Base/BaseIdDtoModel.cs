using System;
namespace BeymenCase.Core.Models.Dtos
{
    public abstract class BaseIdDtoModel
    {
        public int Id { get; set; }
        public bool IsActive { get; set; } = true;
    }
}