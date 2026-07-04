namespace WarehouseManagement.Application.Dtos.UserDtos
{
    public class LoginUserAccountDto
    {
        [Required(ErrorMessage = "نام کاربری الزامی است")]
        [DisplayName("نام کاربری")]
        public string Username { get; set; }

        [Required(ErrorMessage = "رمز عبور الزامی است")]
        [DisplayName("رمز عبور")]
        public string Password { get; set; }
    }

}
