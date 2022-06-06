using System;
using System.Collections.Generic;
using Core.BLL.Constant;

namespace Core.BLL
{
    public interface IGenericSrv<T>
    {
        EntityResult Add(T entity);
        EntityResult Update(T entity);
        EntityResult Delete(T entity);
        EntityResult<IEnumerable<T>> Get();
        EntityResult<T> Get(int id);
    }
}
