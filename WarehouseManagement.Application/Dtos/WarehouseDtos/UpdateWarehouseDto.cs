namespace WarehouseManagement.Application.Dtos.WarehouseDtos
{
    public class UpdateWarehouseDto : CreateWarehouseDto
    {
        public Guid WarehouseId { get; set; }
    }
}