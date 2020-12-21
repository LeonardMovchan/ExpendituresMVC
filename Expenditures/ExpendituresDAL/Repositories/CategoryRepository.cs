using ExpendituresDAL.Entities;
using ExpendituresDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpendituresDAL.Repositories
{
    public class CategoryRepository : GenericRepository<Category,int>, ICategoryRepository
    {
        private readonly ExpendituresContext _ctx;

        public CategoryRepository(ExpendituresContext context) : base(context)
        {
            _ctx = context;
        }
    }
}
