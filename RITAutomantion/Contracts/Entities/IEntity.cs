using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RITAutomantion.Contracts
{
    public interface IEntity<T>
    {
        T GetKey();
    }
}
