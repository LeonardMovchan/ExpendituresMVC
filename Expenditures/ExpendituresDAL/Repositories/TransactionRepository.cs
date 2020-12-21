using ExpendituresDAL.Entities;
using ExpendituresDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpendituresDAL.Repositories
{
    public class TransactionRepository : GenericRepository<Transaction, int>, ITransactionRepository
    {
        private readonly ExpendituresContext _ctx;

        public TransactionRepository(ExpendituresContext context) : base(context)
        {
            _ctx = context;
        }
    }
}
