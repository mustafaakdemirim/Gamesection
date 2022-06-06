using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.BLL;
using Core.BLL.Constant;
using Entity.DTO;
using Entity.POCO;

namespace BussinessLogic.Abstract
{
    public interface IGameService : IGenericSrv<Game>
    {
        EntityResult<IEnumerable<GameDTO>> GetGameByCategoryId(int categoryid);
        EntityResult Delete(Game entity, int gameid);
        EntityResult Delete(int gameid);
        EntityResult<IEnumerable<Game>> GetAllActive();
        EntityResult<Game> GetActive(int id);
        EntityResult Update(Game entity, int gameid);
        EntityResult<IEnumerable<GameDTO>> GetGameAndImage();
        EntityResult<IEnumerable<GameDTO>> GetGameAndImage(int id);
        //EntityResult<IEnumerable<Game>> GetEntity(Expression<Func<Game, bool>> expression = null, string[] navProperty = null);
        EntityResult<IEnumerable<GameDTO>> GetCartByGameId(int userId);
        EntityResult<GameDTO> GetGameAndImageByGameId(int gameId);


    }
}
