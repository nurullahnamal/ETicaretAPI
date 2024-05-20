using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaretAPI.Application.ViewModels.Products;
using FluentValidation;

namespace ETicaretAPI.Application.Validators.Products
{
    public class CreateProductValidator:AbstractValidator<Vm_Create_Product>
    {
        public CreateProductValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Ürün Adını Boş Geçmeyiniz")
                .MaximumLength(150)
                .MinimumLength(1)
                .WithMessage("Lütfen İzin verilen değerler arasında değer yazını 5-150");

            RuleFor(s => s.Stock)
                .NotEmpty()
                .NotNull()
                .WithMessage("stok değerini boş geçmeyiniz")
                .Must(s =>s>=0)
                .WithMessage("stok biligisini giriniz");



            RuleFor(p => p.Price)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen değerini boş bırakmayınız")
                .Must(s => s >= 0)
                .WithMessage("Lütfen değerini boş bırakmayınız"); 

            //......................
        }
    }
}
