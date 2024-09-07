using Lab01.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lab01.Controllers
{
	public class StudentController : Controller
	{
		public IActionResult Index()
		{
			return View(StudentRepository.GetStudents());
		}

		public IActionResult Create()
		{
			// Lay danh sach cac gia tri Gender de hien thi radio btn tren form
			ViewBag.AllGenders = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();

			// Lay danh sach cac gia tri Branch de hien thi select-opt tren form
			ViewBag.AllBranches = new List<SelectListItem>()
			{
				new SelectListItem { Text = "IT", Value = "1" },
				new SelectListItem { Text = "BE", Value = "2" },
				new SelectListItem { Text = "CE", Value = "3" },
				new SelectListItem { Text = "EE", Value = "4" },
			};

			return View();
		}

		[HttpPost]
		public IActionResult Create(Student s)
		{
			StudentRepository.AddStudent(s);
			return View("Index", StudentRepository.GetStudents());
		}
	}
}
