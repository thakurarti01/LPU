using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebApiDemo.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CitiesController : ControllerBase
	{
		public static List<string> cityList = null; //here we made this list static, so that only one copy can be created because this is in web api, and if different people will run this code, multiple copy will be created which is not needed and will degrade the performance
		public CitiesController() 
		{
			if(cityList == null)
			{
				cityList = new List<string>()
				{
					"Delhi",
					"Pune",
					"Mumbai",
					"Chennai",
					"Hyderabad"
				};
			}
		}
		[Route("JoiningCities")] //for routing, if want to make routing short add a slash "/JoiningCities"
		[HttpGet] //this method will not be called if this attribute is not written
		public List<string> ShowAllCities()
		{
			return cityList;
		}
		[Route("GetCities{stateName}")]
		[HttpGet]
		public List<string> GetCities(string stateName)
		{
			return cityList;
		}
		[Route("FetchAllCities{stateId}")]
		[HttpGet]
		public List<string> FetchAllCities(int stateId)
		{
			return cityList;
		}

		[HttpPost]
		public int AddMe(int num1, int num2)
		{
			return num1 + num2;
		}
	}
}
