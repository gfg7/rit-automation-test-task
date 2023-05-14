using RITAutomantion.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace RITAutomantion.Services
{
    internal static class ColumnNameService
    {
        public static string GetColumnName(this PropertyInfo property)
        {
            return property.GetCustomAttribute<ColumnAttribute>().Name;
        }

        public static IEnumerable<PropertyInfo> GetMappedProperties<T>(this T source) where T : class, IMappedEntity<T>
        {
            var properties = source.GetType().GetProperties().Where(x =>
            {
                var attribute = x.GetCustomAttribute<ColumnAttribute>(false);
                return attribute!=null;
            });

            return properties;
        }

        public static string GetKeyColumnName<T>(this T source) where T : class, IMappedEntity<T>
        {
            var keyProperty = source.GetType()
                .GetProperties()
                .FirstOrDefault(x =>
                {
                    var attribute = x.GetCustomAttribute<KeyAttribute>(false);
                    return attribute!=null;
                });

            return keyProperty?.GetCustomAttribute<ColumnAttribute>().Name;
        }
    }
}
