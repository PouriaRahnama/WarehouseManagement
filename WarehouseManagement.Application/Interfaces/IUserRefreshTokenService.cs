using WarehouseManagement.Application.Dtos.UserDtos;
using WarehouseManagement.Application.Dtos.UserRefreshTokenDto;

namespace WarehouseManagement.Application.Interfaces
{
    public interface IUserRefreshTokenService
    {
        Task<Guid> CreateAsync(CreateUserRefreshTokenDto createUserRefreshTokenDto);
        Task<TokenInfoDto> GenerateNewUserTokenAsync(string refreshToken);
        Task<bool> RevokeAsync(string refreshToken);
    }
}
