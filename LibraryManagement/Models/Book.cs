using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Models
{
    public class Book
    {
        public int Id { get; set; }

        public string BookName { get; set; }

        public string Author { get; set; }

        public string Category { get; set; }

        public int Quantity { get; set; }

        public string BookInfo
        {
            get { return $"Name:{BookName} |   Author: {Author} |   Category:{Category} |   Quantity:{Quantity}";}
        }

    }
}
