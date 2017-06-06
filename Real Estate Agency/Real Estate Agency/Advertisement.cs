using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Real_Estate_Agency.Models;

namespace Real_Estate_Agency
{
    public class Advertisement
    {
        public int Id { get; set; }

        public Guid OwnerId { get; set; }
        public ApplicationUser Owner { get; set; }

        public string Header { get; set; }
        public string Content { get; set; }
        public int Size { get; set; }
        public string Adress { get; set; }
        public int Price { get; set; }
        public Guid RenterId { get; set; } 
        public ApplicationUser Renter { get; set; }
    }
}