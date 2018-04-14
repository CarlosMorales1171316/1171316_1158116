using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Futbolista
    {

        [Key]
        public int ID { get; set; }
        public string club { get; set; }
        public string lastName { get; set; }
        public string firstName { get; set; }
        public string position { get; set; }
        public string baseSalary { get; set; }
        public string guaranteedCompensation { get; set; }
    }
}