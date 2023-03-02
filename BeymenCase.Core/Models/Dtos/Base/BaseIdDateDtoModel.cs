using System;

namespace BeymenCase.Core.Models.Dtos
{
    public abstract class BaseIdDateDtoModel
    {
        public int Id { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

    }
}