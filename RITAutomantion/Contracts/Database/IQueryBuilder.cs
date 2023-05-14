using RITAutomantion.Contracts;

namespace RITAutomantion.Services
{
    public interface IQueryBuilder<T, K> where T : IEntity<K>
    {
        string SelectQuery();
        string UpdateQuery(T obj);
    }
}