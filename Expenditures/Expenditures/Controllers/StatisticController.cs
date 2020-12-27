using AutoMapper;
using Expenditures.Models;
using ExpendituresBL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Expenditures.Controllers
{
    public class StatisticController : Controller
    {
       
        private readonly ICategoryService _categoryService;


        public StatisticController(ICategoryService categoryService)
        {
           
            _categoryService = categoryService;

        }


        // GET: Statistic
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult AutoCompleteSuggestion(string query)
        {
            //filteredSuggestions =  serviceCategory.GetAll().Where(x=>x.Name.contains(query)); 

            var categories = _categoryService.GetAll().Where(x => x.Title.StartsWith(query, StringComparison.CurrentCultureIgnoreCase)).ToList();

           
            var filteredSuggestions = new List<AutoCompleteModel>();

            foreach (var item in categories)
            {
                var model = new AutoCompleteModel { data = item.Id.ToString(), value = item.Title };
                filteredSuggestions.Add(model);
            }

                
            var result = new JsonResult();
            result.Data = new { suggestions = filteredSuggestions };

            return Json(new { suggestions = filteredSuggestions }, JsonRequestBehavior.AllowGet);
        }
    }
}