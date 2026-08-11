using FluentValidation;

namespace WarehouseManagement.Application.Validators.ProductDtoValidators
{
    public class CreateProductDtoValidator : AbstractValidator<CreateProductDto>
    {
        public CreateProductDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("وارد کردن نام محصول الزامی است.")
                .NotNull()
                .WithMessage("وارد کردن نام محصول الزامی است.")
                .MaximumLength(350)
                .WithMessage("نام محصول نمی‌تواند بیشتر از ۳۵۰ کاراکتر باشد.");

            RuleFor(x => x.MinimumStock)
                 .NotNull()
                 .WithMessage("حداقل موجودی الزامی است.")
                 .GreaterThanOrEqualTo(0)
                 .WithMessage("حداقل موجودی نمی‌تواند منفی باشد.");

            RuleFor(x => x.UnitOfMeasure)
                .IsInEnum()
                .WithMessage("واحد اندازه‌گیری معتبر نیست.");
        }
    }
}
