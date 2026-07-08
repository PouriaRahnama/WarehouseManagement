namespace WarehouseManagement.Application.GridifyMappers
{
    public class UserGridifyMapper : GridifyMapper<GetAllUserAccountsDto>
    {
        public UserGridifyMapper()
        {
            AddMap("phone", p => p.Phone);
            AddMap("userId", p => p.UserId);
            AddMap("username", p => p.Username);
            AddMap("role", p => p.Role);
        }
    }
}
