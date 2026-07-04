namespace WarehouseManagement.Application.Dtos.UserDtos
{
    public class RegisterUserAccountDto
    {
        [Required(ErrorMessage = "نام کاربری الزامی است")]
        [DisplayName("نام کاربری")]
        public string Username { get; set; }

        [Required(ErrorMessage = "شماره تلفن الزامی است")]
        [DisplayName("شماره تلفن")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "رمز عبور الزامی است")]
        [DisplayName("رمز عبور")]
        public string Password { get; set; }
    }

}
