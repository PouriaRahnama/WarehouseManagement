using FluentValidation;

namespace WarehouseManagement.Application.Validators.ProductDtoValidators
{
    public class UpdateProductDtoValidator : AbstractValidator<UpdateProductDto>
    {
        public UpdateProductDtoValidator()
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
                 .GreaterThanOrEqualTo(5)
                 .WithMessage("حداقل موجودی نمی‌تواند کمتراز 5 باشد.");

            RuleFor(x => x.UnitOfMeasure)
                .IsInEnum()
                .WithMessage("واحد اندازه‌گیری معتبر نیست.");

            RuleFor(x => x.Price).NotEmpty().WithMessage("وارد کردن قیمت محصول الزامی است.")
                .NotNull().WithMessage("وارد کردن قیمت محصول الزامی است.")
                .GreaterThan(0).WithMessage("قیمت وارد شده باید معتبر و بزرگتر از صفر باشد.");

            RuleFor(x => x.ProductId)
                 .NotNull().WithMessage("شناسه محصول الزامی است.")
                 .NotEmpty().WithMessage("شناسه محصول الزامی است.");

        }
    }
}
