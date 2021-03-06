﻿using OdeToFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Controllers
{
    public class HomeController : Controller
    {
        OdeToFoodDb _db = new OdeToFoodDb();
        public ActionResult Index(string searchTerm=null)
        {
            //var controller = RouteData.Values["controller"];
            //var action = RouteData.Values["action"];
            //var id = RouteData.Values["id"];
            //var message = String.Format($"{controller}::{action} {id}");
            //ViewBag.Message = message;

            var model =
                _db.Restaurants
                .OrderByDescending(r=>r.Reviews.Average(review=>review.Rating))
                .Where(r=>searchTerm==null||r.Name.StartsWith(searchTerm))
                .Take(10)
                .Select (r=>new RestaurantListViewModel{
                    Id=r.Id,
                    Name=r.Name,
                    City=r.City,
                    Country=r.Country,
                    CountOfReviews = r.Reviews.Count()
                });

            return View(model);
        }

        public ActionResult About()
        {
            var model = new AboutModel();
            model.Name = "Scott";
            model.Location = "Marryland, USA";

            return View(model);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        protected override void Dispose(bool disposing)
        {
            if(_db!=null)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}