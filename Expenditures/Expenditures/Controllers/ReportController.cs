using AutoMapper;
using Expenditures.Models;
using Expenditures.Models.Category;
using ExpendituresBL.Interfaces;
using ExpendituresBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Expenditures.Controllers
{
    public class ReportController : ApiController
    {
        private readonly ICategoryService _categoryService;
        private readonly ITransactionService _transactionService;
        public ReportController()
        {

        }
        public ReportController(ICategoryService categoryservice, ITransactionService transactionService)
        {
            _categoryService = categoryservice;
            _transactionService = transactionService;
        }

        [HttpGet]
        public IHttpActionResult Test()
        {
            return Ok(_transactionService.GetAll());
        }

        [HttpGet]
        //TODO: return ModelClass with data for traffic
        public List<ChartDataModel> GetExpenditureData(string category)
        {
            var dataList = new List<ChartDataModel>();


            var categories       = _categoryService.GetAll()
                .FirstOrDefault(x => x.Title == category);

            
            if (category != null) 
            {
                var expenditureData = _transactionService.GetAll()
                        .Where(x => x.CategoryId == categories.Id).OrderBy(x => x.ExpenditureDate)
                        .ToList();
              
                if (expenditureData != null)
                {

                    foreach (var item in expenditureData)
                    {
                        var dataModel = new ChartDataModel();
                        dataModel.Value = item.Value;
                        dataModel.ExpenditureDate = item.ExpenditureDate;

                        dataList.Add(dataModel);
                    }


                    return dataList;
                }
                return dataList;
            }
            return dataList;
        }
    }
}
