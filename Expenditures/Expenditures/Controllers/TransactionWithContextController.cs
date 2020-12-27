using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Expenditures.Models;
using Expenditures.Models.Category;
using ExpendituresBL.Interfaces;
using ExpendituresBL.Models;
using ExpendituresBL.Services;

namespace Expenditures.Controllers
{
    public class TransactionWithContextController : Controller
    {
        private readonly ITransactionService _transactionService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public TransactionWithContextController(ITransactionService tranasctionService, ICategoryService categoryService, IMapper mapper)
        {
           
            _mapper = mapper;

            _transactionService = tranasctionService;
            _categoryService = categoryService;

        }

        // GET: TransactionWithContext
        public ActionResult Index()
        {
            var transactions = _mapper.Map<IEnumerable<TransactionModel>>(_transactionService.GetAll());
            
            return View(transactions);
        }

        // GET: TransactionWithContext/Details/5
        public ActionResult Details(int id)
        {      
            var transactionModel = _mapper.Map<TransactionModel>(_transactionService.GetById(id));        

            return View(transactionModel);
        }

        // GET: TransactionWithContext/Create
        public ActionResult Create()
        {
            var model = new TransactionModel();
            model.CaetgoriesList = SelectCategories();
            return View(model);
        }

        // POST: TransactionWithContext/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TransactionModel transactionModel)
        {
            transactionModel.CreatedDate = DateTime.UtcNow;
            transactionModel.UpdatedDate = DateTime.UtcNow;

           
            var model = _mapper.Map<TransactionBL>(transactionModel);
            if (ModelState.IsValid)
            {
                _transactionService.Create(model);
                return RedirectToAction("Index");
            }
            return View();
        }
        // GET: TransactionWithContext/Edit/5
        public ActionResult Edit(int id)
        {
            var updatedModel = _mapper.Map<TransactionModel>(_transactionService.GetById(id));
            updatedModel.CaetgoriesList = SelectCategories();

            if (updatedModel != null)
            {
                return View(updatedModel);
            }

            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult Edit(int id, TransactionModel model)
        {
            model.UpdatedDate = DateTime.UtcNow;


            var updatedModel = _mapper.Map<TransactionBL>(model);
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }

               
                _transactionService.Update(updatedModel);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(TransactionModel model)
        {
            var deleteModel = _mapper.Map<TransactionBL>(model);

            try
            {
                _transactionService.Delete(deleteModel);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        #region DropDownList
        public IEnumerable<SelectListItem> SelectCategories()
        {
            var model = new TransactionModel();

            var categories = _mapper.Map<IEnumerable<CategoryModel>>(_categoryService.GetAll());


            model.CaetgoriesList = GetSelectListItems(categories);

           

            return model.CaetgoriesList;
        }

        private IEnumerable<SelectListItem> GetSelectListItems(IEnumerable<CategoryModel> categories)
        {
            var selectList = new List<SelectListItem>();
            foreach (var element in categories)
            {
                selectList.Add(new SelectListItem
                {
                    Value = element.Id.ToString(),
                    Text = element.Title

                }); 
            }
            return selectList;
        }
        #endregion

    }
}
