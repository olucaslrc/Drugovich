using Drugovich.Domain.Models.Enums;

namespace Drugovich.Domain.Entities
{
    public class Manager : EntityBase
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public LevelEnum Level { get; set; }
        public string? Password { get; set; }
    }
}
