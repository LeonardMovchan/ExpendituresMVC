using AutoMapper;
using Expenditures.Models.Category;
using ExpendituresBL.Interfaces;
using ExpendituresBL.Models;
using ExpendituresBL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace Expenditures.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CategoryModel, CategoryBL>().ReverseMap();
            });

            _mapper = new Mapper(mapperConfig);

            _categoryService = categoryService;
        }

        // GET: Category
        public ActionResult MyCategories()
        {

            var categories = _mapper.Map<IEnumerable<CategoryModel>>(_categoryService.GetAll());

            return View(categories);
        }

        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Details(int id)
        {

            var categoryModel = _mapper.Map<CategoryModel>(_categoryService.GetById(id));

            return View(categoryModel);
        }

        [HttpPost]
        public ActionResult Create(CategoryModel model)
        {
            model.CreatedDate = DateTime.UtcNow;
            model.UpdatedDate = DateTime.UtcNow;

            var categoryModel = _mapper.Map<CategoryBL>(model);
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                _categoryService.Create(categoryModel);

                return RedirectToAction("MyCategories");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var updatedModel = _mapper.Map<CategoryModel>(_categoryService.GetById(id));

            if (updatedModel != null)
            {
                return View(updatedModel);
            }

            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult Edit(int id, CategoryModel model)
        {

            model.UpdatedDate = DateTime.UtcNow;

            var categoryModel = _mapper.Map<CategoryBL>(model);

            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                _categoryService.Update(categoryModel);

                return RedirectToAction("MyCategories");
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
        public ActionResult Delete(CategoryModel model)
        {
            var deleteModel = _mapper.Map<CategoryBL>(model);

            try
            {
                _categoryService.Delete(deleteModel);

                return RedirectToAction("MyCategories");
            }
            catch
            {
                return View();
            }
        }

        
    }
}