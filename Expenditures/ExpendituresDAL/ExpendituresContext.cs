using ExpendituresDAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpendituresDAL
{
    public class ExpendituresContext : DbContext
    {
        public ExpendituresContext() : base("Data source=.;Initial Catalog = ExpendituresDB; Integrated Security = true;")
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Transaction> Tranasctions { get; set; }
    
    }
}
