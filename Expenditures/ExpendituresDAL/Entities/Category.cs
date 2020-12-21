﻿using ExpendituresDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpendituresDAL.Entities
{
    public class Category : ITEntity<int>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public ICollection<Transaction> Tranasctions { get; set; }
    }
}
