using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Real_Estate_Agency.Models;
using Real_Estate_Agency;
using Microsoft.AspNet.Identity;

namespace Real_Estate_Agency.Controllers
{
    public class AdvertisementController : Controller
    {
        [HttpGet]
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.Title = "Create";
            return View();
        }

        public ActionResult Search()
        {
            ViewBag.Title = "";
            return View();
        }


        [HttpPost]
        [Authorize]
        public ActionResult Create(AdvertisementModels model)
        {
            var userId = User.Identity.GetUserId();

            using (var context = ApplicationDbContext.Create())
            {

                var ad = new Advertisement
                {
                    Adress = model.Adress,
                    Header = model.Header,
                    Content = model.Content,
                    Price = Convert.ToInt32(model.Price),
                    Size = Convert.ToInt32(model.Size),
                    OwnerId = Guid.Parse(userId),
                    RenterId = new Guid(-1, 0, 0, new byte[8])                   
                };
                context.Advertisements.Add(ad);
                context.SaveChanges();

                return View("SuccessfulCreated");

            }

            return View();
        }

        public ActionResult Search(SearchModels model)
        {
            using (var context = ApplicationDbContext.Create())
            {

                var ads = context.Advertisements.Where(a =>
                    (a.Header.Contains(model.SearchLine)) && 
                        a.Size >= Convert.ToInt32(model.SizeFrom) &&
                        a.Size <= Convert.ToInt32(model.SizeTo) &&
                        a.Price >= Convert.ToInt32(model.PriceFrom) &&
                        a.Price <= Convert.ToInt32(model.PriceTo)).ToList();
                return View(ads);
            }
            return View();
        }
    }
}