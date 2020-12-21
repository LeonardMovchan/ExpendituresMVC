using ExpendituresBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpendituresBL.Interfaces
{
    public interface ICategoryService 
    {
        CategoryBL Create(CategoryBL model);
        CategoryBL Update(CategoryBL model);
        IEnumerable<CategoryBL> GetAll();
        void Delete(CategoryBL model);
        CategoryBL GetById(int id);
    }
}
