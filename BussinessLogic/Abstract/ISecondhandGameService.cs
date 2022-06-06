using System;
using System.Collections.Generic;
using Core.BLL;
using Core.BLL.Constant;
using Entity.DTO;
using Entity.POCO;

namespace BussinessLogic.Abstract
{
    public interface ISecondhandGameService:IGenericSrv<SecondhandGame>
    {
        EntityResult<IEnumerable<SecondhandGameDTO>> GetGameByCategoryId(int categoryid);
        EntityResult Delete(SecondhandGame entity, int secondhandGameid);
        EntityResult Delete(int secondhandGameid);
        EntityResult<IEnumerable<SecondhandGame>> GetAllActive();
        EntityResult<SecondhandGame> GetActive(int id);
        EntityResult Update(SecondhandGame entity, int secondhandGameid);
    }
}
