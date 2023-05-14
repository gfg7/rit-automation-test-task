using RITAutomantion.Contracts;
using RITAutomantion.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RITAutomantion
{
    internal class Repository<T, K> : IRepository<T, K> where T : class, IEntity<K>, IMappedEntity<T>, new()
    {
        private readonly SqlConnection _connection;
        private SqlCommand _command;
        private SqlDataAdapter _adapter;
        private readonly IQueryBuilder<T, K> _builder;
        public Repository()
        {
            _connection = new SqlConnection(Properties.Settings.Default.masterConnectionString);
            _builder = new QueryBuilder<T, K>();
            TryConnection();
        }

        private void TryConnection()
        {
            try
            {
                _connection.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Dispose()
        {
            _command?.Dispose();
            _adapter?.Dispose();
            _connection.Close();
            _connection.Dispose();
        }

        public IEnumerable<T> GetAll()
        {
            _adapter = new SqlDataAdapter(_builder.SelectQuery(), _connection);

            var dataset = new DataTable();
            _adapter.Fill(dataset);

            var result = new List<T>();

            foreach (var row in dataset.AsEnumerable())
            {
                var entity = new T();
                entity = entity.Map(row);
                result.Add(entity);
            }

            _adapter.Dispose();

            return result;
        }

        public async Task<T> Update(T entity)
        {
            _command = new SqlCommand(_builder.UpdateQuery(entity), _connection);
            await _command.ExecuteNonQueryAsync();

            return entity;
        }
    }
}
