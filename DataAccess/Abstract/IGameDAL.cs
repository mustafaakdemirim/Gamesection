using System;
using System.Collections.Generic;
using Core.DAL;
using Entity.DTO;
using Entity.POCO;

namespace DataAccess.Abstract
{
    public interface IGameDAL:IRepo<Game>
    {
        IEnumerable<GameDTO> GetGameByCategoryId(int categoryid);
        bool Delete(Game entity, int gameid);
        bool Delete(int gameid);
        IEnumerable<Game> GetAllActive();
        Game GetActive(int id);
        bool Update(Game entity, int gameid);
        IEnumerable<GameDTO> GetGameAndImage();
        IEnumerable<GameDTO> GetGameAndImage(int id);
        IEnumerable<GameDTO> GetCartByGameId(int userId);
        GameDTO GetGameAndImageByGameId(int gameId);
    }
}
