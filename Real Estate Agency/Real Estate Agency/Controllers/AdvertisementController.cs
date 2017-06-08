using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Real_Estate_Agency.Models;
using Real_Estate_Agency;
using Microsoft.AspNet.Identity;
using System.Web.UI;

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

        [HttpGet]
        public ActionResult Search()
        {
            ViewBag.Title = "";
            using (var context = ApplicationDbContext.Create())
            {
                var newModel = new UnionModels
                {
                    SearchModel = new SearchModels(),
                    AdsList = context.Advertisements.Where(m => String.IsNullOrEmpty(m.RenterId)).ToList()
                };
                return View(newModel);
            }
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
                    OwnerId = userId,
                    RenterId = null
                };
                context.Advertisements.Add(ad);
                context.SaveChanges();

                return View("SuccessfulCreated");

            }

            return View();
        }

        [HttpPost]
        public ActionResult Search(UnionModels model)
        {
            using (var context = ApplicationDbContext.Create())
            {
                var m = model.SearchModel;
                if (String.IsNullOrEmpty(m.SizeFrom)) m.SizeFrom = "0";
                if (String.IsNullOrEmpty(m.SizeTo)) m.SizeTo = "100000000";
                if (String.IsNullOrEmpty(m.PriceFrom)) m.PriceFrom = "0";
                if (String.IsNullOrEmpty(m.PriceTo)) m.PriceTo = "100000000";
                if (String.IsNullOrEmpty(m.SearchLine)) m.SearchLine = "";
                int sizeFrom = Convert.ToInt32(m.SizeFrom);
                int sizeTo = Convert.ToInt32(m.SizeTo);
                int priceFrom = Convert.ToInt32(m.PriceFrom);
                int priceTo = Convert.ToInt32(m.PriceTo);
                var ads = context.Advertisements.Where(a =>
                    (a.Header.Contains(m.SearchLine)) &&
                        a.Size >= sizeFrom &&
                        a.Size <= sizeTo &&
                        a.Price >= priceFrom &&
                        a.Price <= priceTo &&
                        String.IsNullOrEmpty(a.RenterId)).ToList();
                var newModel = new UnionModels()
                {
                    SearchModel = m,
                    AdsList = ads
                };
                return View(newModel);
            }
            return View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult Details(int id)
        {
            using (var context = ApplicationDbContext.Create())
            {
                var ad = context.Advertisements.Single(m => m.Id == id);
                return View(ad);
            }
           
        }

        [HttpPost]
        [Authorize]
        public ActionResult Details(Advertisement ad)
        {
            var userId = User.Identity.GetUserId();
            if (userId == ad.OwnerId)
            {
                return View("Error");
            }
            using (var context = ApplicationDbContext.Create())
            {
                ad = context.Advertisements.Include("Owner").Single(m => m.Id == ad.Id);
                if (userId == ad.OwnerId)
                {
                    return View("Error");
                }
                ad.RenterId = userId;
                context.SaveChanges();
            }
            return RedirectToAction("Search", "Advertisement");
        }

    }
}