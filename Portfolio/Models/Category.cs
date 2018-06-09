using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string Title { get; set; }

        public List<Project> Projects { get; set; }
    }
}
