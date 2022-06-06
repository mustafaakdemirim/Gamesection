using System;
using System.Collections.Generic;
using Core.DAL;
using Entity.DTO;
using Entity.POCO;

namespace DataAccess.Abstract
{
    public interface ISecondhandGameDAL:IRepo<SecondhandGame>
    {
        IEnumerable<SecondhandGameDTO> GetGameByCategoryId(int categoryid);
        bool Delete(SecondhandGame entity, int secondhandGameid);
        bool Delete(int secondhandGameid);
        IEnumerable<SecondhandGame> GetAllActive();
        SecondhandGame GetActive(int id);
        bool Update(SecondhandGame entity, int secondhandGameid);

    }
}
