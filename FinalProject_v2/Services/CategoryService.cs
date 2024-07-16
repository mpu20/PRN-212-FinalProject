using FinalProject_v2.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_v2.Services
{
    public class CategoryService
    {
        public List<Category> Categories { get; set; }

        public CategoryService()
        {
            Categories = new List<Category>
            {
                new Category { Name = "Income" },
                new Category { Name = "Expenses" },
                new Category { Name = "Savings" },
                new Category { Name = "Investments" }
            };
        }

        public List<Category> GetCategories() => Categories;
    }
}
