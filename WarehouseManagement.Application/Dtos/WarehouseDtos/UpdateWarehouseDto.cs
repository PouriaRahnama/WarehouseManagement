namespace WarehouseManagement.Application.Dtos.WarehouseDtos
{
    public class UpdateWarehouseDto : CreateWarehouseDto
    {
        [Required(ErrorMessage = "شناسه انبار الزامی است.")]
        public Guid WarehouseId { get; set; }
    }
}