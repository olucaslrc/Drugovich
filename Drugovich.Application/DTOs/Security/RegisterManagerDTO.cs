using Drugovich.Domain.Models.Enums;

namespace Drugovich.Application.DTOs.Security
{
    public class RegisterManagerDTO
    {
        public string? Name { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public LevelEnum Level { get; set; }
    }
}
