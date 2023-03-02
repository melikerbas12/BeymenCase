using System;

namespace BeymenCase.Core.Models.Dtos
{
    public abstract class BaseDateDtoModel
    {
        public bool IsActive { get; set; } = true;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

    }
}