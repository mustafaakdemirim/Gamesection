using System;
using System.Collections.Generic;
using DataAccess.Abstract;
using DataAccess.Context;
using Entity.POCO;
using Entity.DTO;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfGame:EfRepo<Game,GamesectionDbContext>,IGameDAL
    {
        private readonly GamesectionDbContext dbContext;

        public EfGame(GamesectionDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public bool Delete(Game entity, int gameid)
        {
            var result = dbContext.Game.Where(x => x.ID == gameid).FirstOrDefault();
            result.Active = false;
            result.Deleted = true;
            if (dbContext.SaveChanges() > 0)
                return true;
            else
                return false;
        }

        public bool Delete(int gameid)
        {
            var result = dbContext.Game.Where(x => x.ID == gameid).FirstOrDefault();
            result.Active = false;
            result.Deleted = true;
            if (dbContext.SaveChanges()>0)
                return true;
            else
                return false;
        }

        public Game GetActive(int id)
        {
            var games =
                from game in dbContext.Game
                where game.ID == id where game.Active==true where game.Deleted==false
                select new Game
                {
                    ID=game.ID,
                    Name=game.Name,
                    Price=game.Price,
                    Stock=game.Stock,
                    Description=game.Description
                };
            return games.FirstOrDefault();
        }

        public IEnumerable<Game> GetAllActive()
        {
            var games =
                from game in dbContext.Game
                where game.Active == true && game.Deleted==false
                select new Game
                {
                    ID = game.ID,
                    Name = game.Name,
                    Price = game.Price,
                    Stock = game.Stock,
                    Description = game.Description
                };
            return games;
        }

        public IEnumerable<GameDTO> GetGameByCategoryId(int categoryid)
        {
            var games =
            from game in dbContext.Game
            join gameCategory in dbContext.GameCategory
            on game.ID equals gameCategory.GameID
            join category in dbContext.Category
            on gameCategory.CategoryID equals category.ID
            where gameCategory.CategoryID == categoryid
            select new GameDTO
            {
                GameCategoryName = category.CategoryName,
                ID = game.ID,
                GameName = game.Name,
                Price = game.Price,
                Stock = game.Stock,
                GameImageURL = dbContext.GameImage.FirstOrDefault(x => x.GameID == game.ID).ImageURL,
                CategoryID = category.ID
            };
            return games;  
        }

        public bool Update(Game entity, int gameid)
        {
            var result = dbContext.Game.Where(x => x.ID == gameid).FirstOrDefault();
            result.Active = entity.Active;
            result.Deleted = entity.Deleted;
            result.Name = entity.Name;
            result.Price = entity.Price;
            result.Description = entity.Description;
            result.Stock = entity.Stock;
            result.Updated = DateTime.Now;
            if (dbContext.SaveChanges() > 0)
                return true;
            else
                return false;
        }

        public IEnumerable<GameDTO> GetGameAndImage()
        {
            var games =
            from game in dbContext.Game
            join gameImage in dbContext.GameImage
            on game.ID equals gameImage.GameID
            join gameCategory in dbContext.GameCategory
            on game.ID equals gameCategory.GameID
            join category in dbContext.Category
            on gameCategory.CategoryID equals category.ID
            where game.Active == true && game.Deleted == false
            select new GameDTO
            {
                
                ID = game.ID,
                GameName = game.Name,
                Price = game.Price,
                Stock = game.Stock,
                Description =game.Description,
                GameImageURL = dbContext.GameImage.FirstOrDefault(x => x.GameID == game.ID).ImageURL,
                GameCategoryName = category.CategoryName,
                
            };
            return games;
        }

        public IEnumerable<GameDTO> GetGameAndImage(int id)
        {
            var games =
            from game in dbContext.Game
            join gameImage in dbContext.GameImage
            on game.ID equals gameImage.GameID
            join gameCategory in dbContext.GameCategory
            on game.ID equals gameCategory.GameID
            join category in dbContext.Category
            on gameCategory.CategoryID equals category.ID
            where game.ID == id
            select new GameDTO
            {

                ID = game.ID,
                GameName = game.Name,
                Price = game.Price,
                Stock = game.Stock,
                Description = game.Description,
                GameImageURL = dbContext.GameImage.FirstOrDefault(x => x.GameID == game.ID).ImageURL,
                GameCategoryName = category.CategoryName,
                CategoryID=category.ID

            };
            return games;
        }

        public IEnumerable<GameDTO> GetCartByGameId(int userId)
        {
           var count = dbContext.Cart.Where(x => x.AppUserId == userId).Count();
            var result =
                from game in dbContext.Game
                join cart in dbContext.Cart on game.ID equals cart.GameID
                join user in dbContext.Users on cart.AppUserId equals user.Id
                where user.Id == userId && cart.Active == true && cart.Deleted == false
                select new GameDTO
                {
                    ID = game.ID,
                    GameName = game.Name,
                    Price = game.Price,
                    Stock = game.Stock,
                    GameImageURL = dbContext.GameImage.FirstOrDefault(x => x.GameID == game.ID).ImageURL,
                    CartCount = count
                };
            return result;
        }

        public GameDTO GetGameAndImageByGameId(int gameId)
        {
            

            var games =
            from game in dbContext.Game
            join gameImage in dbContext.GameImage
            on game.ID equals gameImage.GameID
            join gameCategory in dbContext.GameCategory
            on game.ID equals gameCategory.GameID
            join category in dbContext.Category
            on gameCategory.CategoryID equals category.ID
            where game.ID == gameId
            select new GameDTO
            {

                ID = game.ID,
                GameName = game.Name,
                Price = game.Price,
                Stock = game.Stock,
                Description = game.Description,
                GameImageURL = dbContext.GameImage.FirstOrDefault(x => x.GameID == game.ID).ImageURL,
                GameCategoryName = category.CategoryName,
                CategoryID = category.ID,
                Categories = dbContext.Category.Where(x => x.ID != gameCategory.CategoryID).ToList()
        };
            return games.FirstOrDefault();
        }

    }
}
