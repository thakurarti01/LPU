using FirstWebApiDemo.Models.Repos;
using Microsoft.AspNetCore.Mvc;
using FirstWebApiDemo.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FirstWebApiDemo.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StudentsController : ControllerBase
	{
		StudentRepo sRepo = null;
		public StudentsController() 
		{
			sRepo = new StudentRepo();
		}
		// GET: api/<StudentsController>
		[HttpGet]
		public IEnumerable<Student> Get()
		{
			return sRepo.GetAll();
		}

		// GET api/<StudentsController>/5
		[HttpGet("{id}")]
		public Student Get(int id)
		{
			return sRepo.Get(id);
		}

		// POST api/<StudentsController>
		[HttpPost]
		public void Post([FromBody] string value)
		{
		}

		// PUT api/<StudentsController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<StudentsController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
