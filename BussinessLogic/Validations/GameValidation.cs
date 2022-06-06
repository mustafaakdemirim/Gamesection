using System;
using System.Linq;
using DataAccess.Abstract;
using Entity.POCO;
using FluentValidation;

namespace BussinessLogic.Validations
{
    public class GameValidation:AbstractValidator<Game>
    {
        private readonly IGameDAL gameDAL;

        public GameValidation(IGameDAL gameDAL)
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Ad Alanı Boş Geçilemez!");
            RuleFor(x => x.Name).Must(GameNameValidation).WithMessage("Oyun Adı Mevcut!");
            RuleFor(x => x.GameImages).NotNull().WithMessage("Görsel Alanı Boş Geçilemez!");
            RuleFor(x => x.Price).NotNull().WithMessage("Fiyat Alanı Boş Geçilemez!");
            RuleFor(x => x.Description).NotNull().WithMessage("Açıklama Alanı Boş Geçilemez!");
            RuleFor(x => x.Stock).NotNull().WithMessage("Stok Alanı Boş Geçilemez!");
            this.gameDAL = gameDAL;
        }

        public bool GameNameValidation(string gameName)
        {
            Game entity =
                gameDAL.Get().AsQueryable().FirstOrDefault(x => x.Name == gameName);
            if (entity == null)
            {
                return true;
            }
            return false;
        }
    }
}
