using RITAutomantion.Contracts;
using RITAutomantion.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace RITAutomantion.Services
{
    internal class QueryBuilder<T, K> : IQueryBuilder<T, K> where T : class, IMappedEntity<T>, IEntity<K>
    {
        private readonly string _table = typeof(T).GetCustomAttribute<TableAttribute>().Name;
        private string _keyColumn;
        private IEnumerable<PropertyInfo> _mappedProperties;

        public string UpdateQuery(T obj)
        {
            _keyColumn = _keyColumn ?? obj.GetKeyColumnName();
            _mappedProperties = _mappedProperties ?? obj.GetMappedProperties();
            var update = new List<string>();

            _mappedProperties.ToList().ForEach(x =>
            {
                var columnName = x.GetColumnName();

                if (columnName == _keyColumn)
                {
                    return;
                }

                var value = x.GetValue(obj);
                update.Add($"{columnName}={value.ToString().Replace(',', '.')}");
            });

            return $"update {_table} set {string.Join(",", update)} where {_keyColumn}={obj.GetKey()}";
        }

        public string SelectQuery() => $"select * from {_table}";
    }
}
