namespace WarehouseManagement.Application.Dtos.UserRefreshTokenDto
{
    public class CreateUserRefreshTokenDto
    {
        public string RefreshToken { get; set; }
        public Guid UserId { get; set; }
    }
}
