namespace Drugovich.Application.DTOs.App
{
    public class CustomerDTO
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public Guid? FK_CustomerGroup { get; set; }
    }
}