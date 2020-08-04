using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Models;
using System.Net.Http;
using System.Net;

namespace MVC.Controllers
{
    public class InventoriesController : Controller
    {
        private readonly object db;

        // GET: Inventories
        public ActionResult Index()
        {
            IEnumerable<MVCInventoryModels> invList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Inventories").Result;
            invList = response.Content.ReadAsAsync<IEnumerable<MVCInventoryModels>>().Result;
            return View(invList);
        }
        public ActionResult AddOrEdit(int Id = 0)
        { 
            return View(new MVCInventoryModels());
        }

        [HttpPost]
        public ActionResult AddOrEdit(MVCInventoryModels Inv)

        {
            if (Inv.Id == 0)
            {

                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Inventories", Inv).Result;
                TempData["SuccessMessage"] = "Saved Successfully";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Inventories/" + Inv.Id, Inv).Result;
                TempData["SuccessMessage"] = "Updated Successfully";
            }
            return RedirectToAction("Index");

          }
        public ActionResult Delete(int Id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Inventories/" + Id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Index");

        }
        

    }
    }
