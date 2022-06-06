using System;
using System.Collections.Generic;
using System.Linq;
using Core.DAL;
using DataAccess.Abstract;
using DataAccess.Context;
using Entity.DTO;
using Entity.POCO;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfSecondHandGame : EfRepo<SecondhandGame, GamesectionDbContext>,ISecondhandGameDAL
    {
        private readonly GamesectionDbContext db;

        public EfSecondHandGame(GamesectionDbContext db):base(db)
        {
            this.db = db;
        }

        public bool Delete(SecondhandGame entity, int secondhandGameid)
        {
            var result = db.SecondhandGame.Where(x => x.ID == secondhandGameid).FirstOrDefault();
            result.Active = false;
            result.Deleted = true;
            if (db.SaveChanges() > 0)
                return true;
            else
                return false;
        }

        public bool Delete(int secondhandGameid)
        {
            var result = db.SecondhandGame.Where(x => x.ID == secondhandGameid).FirstOrDefault();
            result.Active = false;
            result.Deleted = true;
            if (db.SaveChanges() > 0)
                return true;
            else
                return false;
        }

        public SecondhandGame GetActive(int id)
        {
            var secondhandGames =
                from secondhandGame in db.SecondhandGame
                where secondhandGame.ID == id
                where secondhandGame.Active == true
                where secondhandGame.Deleted == false
                select new SecondhandGame
                {
                    ID = secondhandGame.ID,
                    GameName = secondhandGame.GameName,
                    Price = secondhandGame.Price,
                    Stock = secondhandGame.Stock,
                    Description = secondhandGame.Description
                };
            return secondhandGames.FirstOrDefault();
        }

        public IEnumerable<SecondhandGame> GetAllActive()
        {
            var secondhandGames =
                from secondhandGame in db.SecondhandGame
                where secondhandGame.Active == true && secondhandGame.Deleted == false
                select new SecondhandGame
                {
                    ID = secondhandGame.ID,
                    GameName = secondhandGame.GameName,
                    Price = secondhandGame.Price,
                    Stock = secondhandGame.Stock,
                    Description = secondhandGame.Description
                };
            return secondhandGames;
        }

        public IEnumerable<SecondhandGameDTO> GetGameByCategoryId(int categoryid)
        {
            var secondhandGames =
           from secondhandgame in db.SecondhandGame
           join gameCategory in db.GameCategory
           on secondhandgame.ID equals gameCategory.GameID
           join category in db.Category
           on gameCategory.CategoryID equals category.ID
           where gameCategory.CategoryID == categoryid
           select new SecondhandGameDTO
           {
               GameCategoryName = category.CategoryName,
               ID = secondhandgame.ID,
               GameName = secondhandgame.GameName,
               Price = secondhandgame.Price,
               Stock = secondhandgame.Stock,
               GameImageURL = db.GameImage.FirstOrDefault(x => x.GameID == secondhandgame.ID).ImageURL,
               CategoryID = category.ID
           };
            return secondhandGames;
        }

        public bool Update(SecondhandGame entity, int secondhandGameid)
        {
            var result = db.SecondhandGame.Where(x => x.ID == secondhandGameid).FirstOrDefault();
            result.Active = entity.Active;
            result.Deleted = entity.Deleted;
            result.GameName = entity.GameName;
            result.Price = entity.Price;
            result.Description = entity.Description;
            result.Stock = entity.Stock;
            result.Updated = DateTime.Now;
            if (db.SaveChanges() > 0)
                return true;
            else
                return false;
        }
    }
}
