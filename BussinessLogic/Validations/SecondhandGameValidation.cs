using System;
using DataAccess.Abstract;
using Entity.POCO;
using FluentValidation;

namespace BussinessLogic.Validations
{
    public class SecondhandGameValidation: AbstractValidator<SecondhandGame>
    {
        private readonly ISecondhandGameDAL secondhandGameDAL;

        public SecondhandGameValidation(ISecondhandGameDAL secondhandGameDAL)
        {
            RuleFor(x => x.GameName).NotNull().WithMessage("Ad Alanı Boş Geçilemez!");
            RuleFor(x => x.SecondhandGameImages).NotNull().WithMessage("Görsel Alanı Boş Geçilemez!");
            RuleFor(x => x.Price).NotNull().WithMessage("Fiyat Alanı Boş Geçilemez!");
            RuleFor(x => x.Description).NotNull().WithMessage("Açıklama Alanı Boş Geçilemez!");
            RuleFor(x => x.Stock).NotNull().WithMessage("Stok Alanı Boş Geçilemez!");
            this.secondhandGameDAL = secondhandGameDAL;
        }
    }
}
