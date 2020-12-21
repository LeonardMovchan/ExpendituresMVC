using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpendituresDAL;
using ExpendituresDAL.Entities;
using ExpendituresDAL.Interfaces;
using ExpendituresDAL.Repositories;
using LightInject;
namespace ExpendituresBL
{
    public static class BLLightInjectCongiguration
    {
        public static ServiceContainer Configuration(ServiceContainer container)
        {
            container.Register<ExpendituresContext>(new PerScopeLifetime());
            container.Register(typeof(ICategoryRepository), typeof(CategoryRepository));
            container.Register(typeof(ITransactionRepository), typeof(TransactionRepository));
            return container;
        }
    }
}
