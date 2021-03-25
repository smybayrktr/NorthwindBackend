using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator:AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.UnitPrice).NotEmpty(); 
            RuleFor(p => p.ProductName).NotEmpty(); //ProductName boş geçilemez.
            RuleFor(p => p.ProductName).MinimumLength(2); //ProductName min 2 karakter olabilir
            RuleFor(p => p.UnitPrice).GreaterThan(0); //UnitPrice 0dan büyük olmalı
            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryId == 2);
            //Kategori Id si 2 olan ürünlerin fiyatı 10a eşit veya 10dan büyük olmalı
            RuleFor(p => p.ProductName).Must(StartWithA).WithMessage("Ürünler A harfi ile başlamalı");
        }

        private bool StartWithA(string arg) //Kendi kuralımızı oluşturduk.
        {
            return arg.StartsWith("A");
        }
    }
}
