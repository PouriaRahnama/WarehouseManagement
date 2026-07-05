namespace WarehouseManagement.Application.Dtos.UserDtos
{
    public class GetUserAccountDetailsDto
    {
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; }
        public DateTime? CreatedDateTime { get; set; }
    }
}
