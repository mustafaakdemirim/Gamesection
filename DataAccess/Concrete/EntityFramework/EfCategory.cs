using System;
using System.Collections.Generic;
using DataAccess.Abstract;
using DataAccess.Context;
using Entity.POCO;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Entity.DTO;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCategory:EfRepo<Category,GamesectionDbContext>,ICategoryDAL
    {
        private readonly GamesectionDbContext dbContext;

        public EfCategory(GamesectionDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public bool Delete(Category entity, int categoryid)
        {
            var result = dbContext.Category.Where(x => x.ID == categoryid).FirstOrDefault();
            result.Active = false;
            result.Deleted = true;
            if (dbContext.SaveChanges() > 0)
                return true;
            else
                return false;
        }

        public bool Delete(int categoryid)
        {
            var result = dbContext.Category.Where(x => x.ID == categoryid).FirstOrDefault();
            result.Active = false;
            result.Deleted = true;
            if (dbContext.SaveChanges() > 0)
                return true;
            else
                return false;
        }

        public Category GetActive(int id)
        {
            var categories =
                from category in dbContext.Category
                where category.ID == id
                where category.Active == true
                where category.Deleted == false
                select new Category
                {
                    ID = category.ID,
                    CategoryName = category.CategoryName,
                    CategoryImageURL=category.CategoryImageURL
                };
            return categories.FirstOrDefault();
        }

        public IEnumerable<Category> GetAllActive()
        {
            var categories =
                from category in dbContext.Category
                where category.Active == true && category.Deleted == false
                select new Category
                {
                    ID = category.ID,
                    CategoryName = category.CategoryName,
                    CategoryImageURL = category.CategoryImageURL
                };
            return categories;
        }

        public IEnumerable<Category> GetAllCategories()
        {
            var categories =
                from category in dbContext.Category
                select new Category
                {
                    ID = category.ID,
                    CategoryName = category.CategoryName,
                    CategoryImageURL = category.CategoryImageURL
                };
            return categories;
        }

        public bool Update(Category entity, int categoryid)
        {
            var result = dbContext.Category.Where(x => x.ID == categoryid).FirstOrDefault();
            result.Active = entity.Active;
            result.Deleted = entity.Deleted;
            result.CategoryName = entity.CategoryName;
            result.CategoryImageURL = entity.CategoryImageURL;
            result.Updated = DateTime.Now;
            if (dbContext.SaveChanges() > 0)
                return true;
            else
                return false;
        }
        public IEnumerable<CategoryDTO> GetAllActiveAndCartUserId(int userId)
        {
            var count = dbContext.Cart.Where(x => x.AppUserId == userId).Count();
            var categories =
                from category in dbContext.Category
                join gameCategory in dbContext.GameCategory on category.ID equals gameCategory.CategoryID
                join game in dbContext.Game on gameCategory.GameID equals game.ID
                join cart in dbContext.Cart on game.ID equals cart.GameID
                join user in dbContext.Users on cart.AppUserId equals user.Id
                where category.Active == true && category.Deleted == false && cart.AppUserId == userId
                select new CategoryDTO
                {
                    ID = category.ID,
                    CategoryName = category.CategoryName,
                    CategoryImageURL = category.CategoryImageURL,
                    CartCount = count
                };
            return categories;
        }

        
    }
}
