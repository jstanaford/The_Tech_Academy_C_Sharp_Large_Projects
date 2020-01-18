using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarQuoteInsurance.ViewModels
{
	public class GetQuoteVm
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string EmailAddress { get; set; }
		public DateTime DateofBirth { get; set; }
		public DateTime CarYear { get; set; }
		public string CarMake { get; set; }
		public string CarModel { get; set; }
		public bool Dui { get; set; }
		public string CoverageType { get; set; }
		public int SpeedingTickets { get; set; }
		public Nullable<int> PaymentPerMonth { get; set; }

	}
}