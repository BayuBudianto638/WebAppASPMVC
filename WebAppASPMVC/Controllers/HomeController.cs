using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppASPMVC.Models;
using WebAppASPMVC.Services;

namespace WebAppASPMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult DownloadTextFile()
        {
            var listUser = new List<UserModel>();

            var user1 = new UserModel();
            user1.Id = 1;
            user1.Name = "Test";

            var user2 = new UserModel();
            user2.Id = 1;
            user2.Name = "Test";

            var user3 = new UserModel();
            user3.Id = 1;
            user3.Name = "Test";

            listUser.Add(user1);
            listUser.Add(user2);
            listUser.Add(user3);

            GenerateCsvService<UserModel> csvService = new GenerateCsvService<UserModel>();
            var csvBytes = csvService.ExportToCsv(listUser);

           return File(csvBytes, "text/csv", "hello_world.txt");
        }
    }
}