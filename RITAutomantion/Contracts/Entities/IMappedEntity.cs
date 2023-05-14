using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RITAutomantion.Contracts
{
    public interface IMappedEntity<T> where T : class
    {
        T Map(DataRow row);
    }
}
