using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web.ViewModels;
using Core.Models;

namespace Web.Controllers
{
    public class RegistrationsController : Controller
    {
        public IActionResult Index()
        {
            RegistrationViewModel registrationViewModel = new RegistrationViewModel();
            registrationViewModel.Customer = new Owner();
            registrationViewModel.Car = new Car();
            registrationViewModel.Maintenance = new MaintenanceSpecification();
            return View(registrationViewModel);
        }
    }
}
