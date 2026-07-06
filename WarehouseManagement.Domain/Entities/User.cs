namespace WarehouseManagement.Domain.Entities;

/// <summary>
/// کاربر سیستم
/// </summary>
public class User : BaseEntity
{
    public User()
    {
        UserRefreshTokens = new List<UserRefreshToken>();
    }
    public string Username { get; set; }
    public string Phone { get; set; }
    public string PasswordHash { get; set; }
    public string PasswordSalt { get; set; }
    public UserRole Role { get; set; }

    #region Navigation
    public ICollection<UserRefreshToken> UserRefreshTokens { get; set; }
    #endregion
}

