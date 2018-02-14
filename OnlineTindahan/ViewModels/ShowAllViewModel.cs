using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineTindahan.Models;

namespace OnlineTindahan.ViewModels
{
    public class ShowAllViewModel
    {
        public Product Product { get; set; }
        public List<User> Users { get; set; }

        public ShowAllViewModel()
        {
            this.Product = new Product();
            this.Users = new List<User>();
        }
    }
}