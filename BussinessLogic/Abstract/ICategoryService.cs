using System;
using System.Collections.Generic;
using Core.BLL;
using Core.BLL.Constant;
using Entity.DTO;
using Entity.POCO;

namespace BussinessLogic.Abstract
{
    public interface ICategoryService:IGenericSrv<Category>
    {
        EntityResult Delete(Category entity, int categoryid);
        EntityResult Delete(int categoryid);
        EntityResult<IEnumerable<Category>> GetAllActive();
        EntityResult<Category> GetActive(int id);
        EntityResult Update(Category entity, int categoryid);
        EntityResult<IEnumerable<CategoryDTO>> GetAllActiveAndCartUserId(int userId);
    }
}
