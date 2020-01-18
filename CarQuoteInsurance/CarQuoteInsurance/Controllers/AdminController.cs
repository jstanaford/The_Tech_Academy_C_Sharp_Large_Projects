using CarQuoteInsurance.Models;
using CarQuoteInsurance.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarQuoteInsurance.Controllers
{
	public class AdminController : Controller
	{
		// GET: Admin
		public ActionResult Index()
		{
			using (CarQuoteInsuranceEntities db = new CarQuoteInsuranceEntities())
			{
				var carOwners = db.CarOwners.ToList();
				var carOwnerVms = new List<GetQuoteVm>();
				foreach (var carOwner in carOwners)
				{
					var carOwnerVm = new GetQuoteVm();
					carOwnerVm.Id = carOwner.Id;
					carOwnerVm.FirstName = carOwner.FirstName;
					carOwnerVm.LastName = carOwner.LastName;
					carOwnerVm.EmailAddress = carOwner.EmailAddress;
					carOwnerVm.PaymentPerMonth = carOwner.PaymentPerMonth;
					carOwnerVms.Add(carOwnerVm);
				}
				return View(carOwnerVms);
			}
		}
	}
}