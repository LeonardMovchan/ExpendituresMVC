using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Expenditures.Models
{
    public class TransactionModel
    {
        public int Id { get; set; }
        public decimal Value { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime UpdatedDate { get; set; }
  
        public int CategoryId { get; set; }
        [Display(Name = "Categories")]
        public IEnumerable<SelectListItem> CaetgoriesList { get; set; }
    }
}