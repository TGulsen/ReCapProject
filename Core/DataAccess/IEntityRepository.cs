using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {   // Generic Constraint: T yerine verilecek sınıfın kısıtlaması yapılır.
        // IEntity: Referans tip, IEntity veya IEntity implement eden referans tipler kabul edilir.
        // new() : new lenebilir olmalı. Yani IEntity interface olduğundan kabul edilmez.
        // LinQ kullanarak referans vermek istediğimiz filtrelemeyi kullanmayı sağlar. Bunlara "Delege" denir.
        T Get(Expression<Func<T, bool>> filter);
        List<T> GetAll(Expression<Func<T,bool>> filter=null);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
