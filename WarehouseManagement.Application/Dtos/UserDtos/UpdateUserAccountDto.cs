namespace WarehouseManagement.Application.Dtos.UserDtos
{
    public class UpdateUserAccountDto
    {
        [Required(ErrorMessage = "شناسه کاربر الزامی است")]
        [DisplayName("شناسه کاربر")]
        public Guid UserId { get; set; }

        [Required(ErrorMessage = "نام کاربری الزامی است")]
        [DisplayName("نام کاربری")]
        public string Username { get; set; }

        [Required(ErrorMessage = "شماره تلفن الزامی است")]
        [DisplayName("شماره تلفن")]
        public string Phone { get; set; }
    }
}
