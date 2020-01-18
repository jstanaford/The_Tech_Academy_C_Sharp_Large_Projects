using CarQuoteInsurance.Models;
using CarQuoteInsurance.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarQuoteInsurance.Controllers
{
	public class HomeController : Controller
	{

		public ActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public ActionResult GetQuote(string firstName, string lastName, string emailAddress,
									 DateTime dateOfBirth, int carYear, string carMake,
									 string carModel, bool dui, bool coverageType, int speedingTickets)
		{
			if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(emailAddress) || string.IsNullOrEmpty(carModel) || string.IsNullOrEmpty(carMake))
			{
				return View("~/Views/Shared/Error.cshtml");
			}
			else
			{

				using (CarQuoteInsuranceEntities db = new CarQuoteInsuranceEntities())
				{
					var carOwner = new CarOwner();
					carOwner.FirstName = firstName;
					carOwner.LastName = lastName;
					carOwner.EmailAddress = emailAddress;
					carOwner.DateOfBirth = dateOfBirth;
					carOwner.CarYear = carYear;
					carOwner.CarMake = carMake;
					carOwner.CarModel = carModel;
					carOwner.DUI = dui;
					carOwner.CoverageType = coverageType;
					carOwner.SpeedingTickets = speedingTickets;



					//My Operations for a car quote
					
					int runningBalance = 50;
					int years = 0;
					years = DateTime.Now.Year - carOwner.DateOfBirth.Value.Year;
					if (DateTime.Now.DayOfYear < dateOfBirth.DayOfYear)
						years -= 1;
					if (years < 25 && years > 18 || years > 100)
					{
						runningBalance += 25;
					}
					else if (years < 18)
					{
						runningBalance += 100;
					}
					else
					{
						runningBalance += 0;
					}
					
					//My math for car year
					
					if (carOwner.CarYear < 2000)
					{
						runningBalance += 25;
					}
					else if (carOwner.CarYear > 2015)
					{
						runningBalance += 25;
					}
					else
					{
						runningBalance += 0;
					}
					
					//The make
					
					if (carOwner.CarMake == "Porsche" && carOwner.CarModel != "911 Carrera")
					{
						runningBalance += 25;
					}
					else if (carOwner.CarMake == "Porsche" && carOwner.CarModel == "911 Carrera")
					{
						runningBalance += 50;
					}

					//Speeding tickets
					for (int i = 0; i < carOwner.SpeedingTickets; i++)
					{
						runningBalance += 10;
					}
				
					//DUI
					if (carOwner.DUI == true)
					{
						double percentage = runningBalance * .25;
						runningBalance += Convert.ToInt32(percentage);
					}
					else
					{
						runningBalance += 0;
					}

					//COVERAGE
					if (carOwner.CoverageType == true)
					{
						double percentage = runningBalance * .50;
						runningBalance += Convert.ToInt32(percentage);

					}
					else
					{
						runningBalance += 0;
					}
					carOwner.PaymentPerMonth = runningBalance;
					db.CarOwners.Add(carOwner);
					db.SaveChanges();

					GetQuoteVm quote = new GetQuoteVm
					{
						PaymentPerMonth = runningBalance
					};
					ViewBag.Message = quote;
				}
				return View("Success");
			}
		}
	}
}