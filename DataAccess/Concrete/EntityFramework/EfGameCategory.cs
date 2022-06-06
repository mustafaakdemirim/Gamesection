using System;
using System.Linq;
using DataAccess.Abstract;
using DataAccess.Context;
using Entity.POCO;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfGameCategory : EfRepo<GameCategory, GamesectionDbContext>, IGameCategoryDAL
    {
        private readonly GamesectionDbContext db;

        public EfGameCategory(GamesectionDbContext db):base(db)
        {
            this.db = db;
        }
        public bool Update(GameCategory entity, int categoryid, int gameid)
        {
            var result = db.GameCategory.Where(x => x.GameID == gameid).FirstOrDefault();
            //result.GameID = gameid;
            result.CategoryID = categoryid;
            db.Update(result);
            if (db.SaveChanges() > 0)
                return true;
            else
                return false;
        }
    }
}
