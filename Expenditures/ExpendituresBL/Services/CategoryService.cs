using AutoMapper;
using ExpendituresBL.Interfaces;
using ExpendituresBL.Models;
using ExpendituresDAL;
using ExpendituresDAL.Entities;
using ExpendituresDAL.Interfaces;
using ExpendituresDAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpendituresBL.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository repository, IMapper mapper)
        {
           
            _categoryRepository = repository;
            _mapper = mapper;
        }

        public CategoryBL Create(CategoryBL model)
        {
            var categoryMapper = _mapper.Map<Category>(model);
            var createdCategory = _categoryRepository.Create(categoryMapper);

            return _mapper.Map<CategoryBL>(createdCategory);
        }


        public void Delete(CategoryBL model)
        {
            var deleteModel = _mapper.Map<Category>(model);
            _categoryRepository.Delete(deleteModel);
        }

        public IEnumerable<CategoryBL> GetAll()
        {
            IEnumerable<Category> models = _categoryRepository.GetAll();

            var mappedModels = _mapper.Map<IEnumerable<CategoryBL>>(models);

            return mappedModels;
        }

        public CategoryBL GetById(int id)
        {
            var model = _categoryRepository.GetById(id);

            return _mapper.Map<CategoryBL>(model);
        }

        public CategoryBL Update(CategoryBL model)
        {
            var categoryMapper = _mapper.Map<Category>(model);
            var updatedCategory = _categoryRepository.Update(categoryMapper);

            return _mapper.Map<CategoryBL>(updatedCategory);
        }


    }
}
