using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class MVCInventoryModels
    {
        public int Id { get; set; }
       [Required (ErrorMessage ="This feild must ")] 
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
    }
}