using AutoMapper;
using ExpendituresBL.Models;
using ExpendituresDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpendituresBL
{
    public class BLAutomapperProfile : Profile
    {
        public BLAutomapperProfile()
        {
            CreateMap<TransactionBL, Transaction>().ReverseMap();
            CreateMap<CategoryBL, Category>().ReverseMap();
        }
    }
}
