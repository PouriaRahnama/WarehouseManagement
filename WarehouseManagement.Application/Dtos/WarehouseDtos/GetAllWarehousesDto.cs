namespace WarehouseManagement.Application.Dtos.WarehouseDtos
{
    public class GetAllWarehousesDto
    {
        public Guid WarehouseId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime? CreatedDateTime { get; set; }
    }
}