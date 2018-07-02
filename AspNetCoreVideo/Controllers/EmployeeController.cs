using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreVideo.Controllers
{
	[Route("company/[controller]/[action]")]
	public class EmployeeController : Controller
	{
		public ContentResult Name()
		{
			return Content("Vlad");
		}
		public string Country()
		{
			return "Romania";
		}
		public string Index()
		{
			return "Hello  from employees";
		}
	}
}
