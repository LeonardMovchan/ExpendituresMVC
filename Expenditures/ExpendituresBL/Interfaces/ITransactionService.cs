using ExpendituresBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpendituresBL.Interfaces
{
    public interface ITransactionService
    {
        TransactionBL Create(TransactionBL model);
        TransactionBL Update(TransactionBL model);
        IEnumerable<TransactionBL> GetAll();
        void Delete(TransactionBL model);
        TransactionBL GetById(int id);
    }
}
