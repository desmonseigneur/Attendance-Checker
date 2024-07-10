using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Municipal
{
    public interface IConnectionStringProvider
    {
        string GetConnectionString();
    }
}