using System;
using System.Collections;
using System.Collections.Generic;

namespace ChaoticConventions.SQL
{
    public interface IRepository<T>
    {
        IEnumerable<T> Get();
        void Save(IEnumerable<T> entities);

        void Save(T entity);

    }


}
