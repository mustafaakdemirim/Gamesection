using System;
using Core.BLL.Constant;
using Entity.POCO;

namespace BussinessLogic.Abstract
{
    public interface IGameCategoryService
    {
        EntityResult<bool> Update(GameCategory entity, int categoryid, int gameid);

    }
}
