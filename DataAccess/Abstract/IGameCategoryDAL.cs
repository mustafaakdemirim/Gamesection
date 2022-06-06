using System;
using Entity.POCO;

namespace DataAccess.Abstract
{
    public interface IGameCategoryDAL
    {
        bool Update(GameCategory entity, int categoryid, int gameid);
    }
}
