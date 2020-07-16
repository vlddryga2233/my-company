﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCompany.Domain;
using MyCompany.Domain.Entities;
using MyCompany.Service;

namespace MyCompany.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServiceItemsController : Controller
    {
        private readonly DataManager dataManager;
        private readonly IWebHostEnvironment hostEnvironment;
        public ServiceItemsController(DataManager dataManager, IWebHostEnvironment hostEnvironment)
        {
            this.dataManager = dataManager;
            this.hostEnvironment = hostEnvironment;
        }
        public IActionResult Edit(Guid id)
        {
            var entity= id == default ? new ServiceItem() :  dataManager.ServiceItems.GetServiceItemById(id);
            return View(entity);

        }
        [HttpPost]
        public IActionResult Edit(ServiceItem model,IFormFile titleImageFile)
        {
            if (ModelState.IsValid)
            {
                if (titleImageFile!=null)
                {
                    model.TitleImagePath = titleImageFile.FileName;
                    using (var stram= new FileStream(Path.Combine(hostEnvironment.WebRootPath,"images/",titleImageFile.FileName),FileMode.Create))
                    {
                        titleImageFile.CopyTo(stram);
                    }
                }
                dataManager.ServiceItems.SaveServiceItem(model);
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
            }
            return View(model);
        }
        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            dataManager.ServiceItems.DeleteServiceItem(id);
            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
        }
    }
}