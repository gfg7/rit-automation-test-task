using RITAutomantion.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RITAutomantion
{
    public interface IRepository<T, K> : IDisposable where T : IEntity<K>
    {
        IEnumerable<T> GetAll();
        Task<T> Update(T entity);
    }
}
