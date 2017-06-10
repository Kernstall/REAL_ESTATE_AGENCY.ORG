using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Real_Estate_Agency.Models;

namespace Real_Estate_Agency
{
    public class Advertisement
    {
        public DateTime Date { get; set; }
        public int Id { get; set; }

        public string OwnerId { get; set; }
        public ApplicationUser Owner { get; set; }

        public string Header { get; set; }
        public string Content { get; set; }
        public int Size { get; set; }
        public string Adress { get; set; }
        public int Price { get; set; }
        public string RenterId { get; set; } 
        public ApplicationUser Renter { get; set; }
    }
}