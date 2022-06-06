using System;
using System.Linq;
using DataAccess.Abstract;
using Entity.POCO;
using FluentValidation;

namespace BussinessLogic.Validations
{
    public class CategoryValidation:AbstractValidator<Category>
    {
        private readonly ICategoryDAL categoryDAL;

        public CategoryValidation(ICategoryDAL categoryDAL)
        {
            RuleFor(x => x.CategoryName).NotNull().WithMessage("Kategori Adı Boş Geçilemez!");
            RuleFor(x => x.CategoryName).Must(CategoryNameValidation).WithMessage("Kategori Adı Mevcut!");
            this.categoryDAL = categoryDAL;
        }

        public bool CategoryNameValidation(string categoryname)
        {
            Category entity =
                categoryDAL.Get().AsQueryable().FirstOrDefault(x => x.CategoryName == categoryname);
            if (entity == null)
            {
                return true;
            }
            return false;
        }
    }
}
