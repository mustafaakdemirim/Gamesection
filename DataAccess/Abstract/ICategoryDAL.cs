using System;
using System.Collections.Generic;
using Core.DAL;
using Entity.DTO;
using Entity.POCO;

namespace DataAccess.Abstract
{
    public interface ICategoryDAL:IRepo<Category>
    {
        bool Delete(Category entity, int categoryid);
        bool Delete(int categoryid);
        IEnumerable<Category> GetAllActive();
        Category GetActive(int id);
        bool Update(Category entity, int categoryid);
        IEnumerable<CategoryDTO> GetAllActiveAndCartUserId(int userId);

    }
}
