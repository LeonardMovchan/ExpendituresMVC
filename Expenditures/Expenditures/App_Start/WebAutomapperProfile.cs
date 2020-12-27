using Expenditures.Models;
using Expenditures.Models.Category;
using ExpendituresBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
namespace Expenditures.App_Start
{
    public class WebAutomapperProfile : Profile
    {
        public WebAutomapperProfile()
        {
            CreateMap<CategoryBL, CategoryModel>().ReverseMap();
            CreateMap<TransactionBL, TransactionModel>().ReverseMap();
        }      
    }
}