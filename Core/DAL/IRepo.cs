using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.ENTITY;

namespace Core.DAL
{
    public interface IRepo<T>
        where T:class,IBASEENTITY,new()
    {
        bool Add(T entity);
        bool Update(T entity);
        bool Delete(T entity);
        IEnumerable<T> Get();
        T Get(int id);
        //IEnumerable<T> GetEntity(Expression<Func<T, bool>> expression = null, string[] navProperty = null);
    }
}
