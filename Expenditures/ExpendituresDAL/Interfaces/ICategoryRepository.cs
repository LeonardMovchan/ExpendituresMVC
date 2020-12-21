using ExpendituresDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpendituresDAL.Interfaces
{
    public interface ICategoryRepository : IGenericRepository<Category, int>
    {
    }
}
