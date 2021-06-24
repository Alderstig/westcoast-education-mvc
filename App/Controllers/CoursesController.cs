using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using App.Interfaces;
using App.Models;
using App.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ICourseService _service;

        public CoursesController(ICourseService service)
        {
            _service = service;
        }

        [HttpGet()]
        public async Task<IActionResult> Index()
        {
            var result = await _service.GetCoursesAsync();

            return View("Index", result);
        }

        [HttpGet]
        public IActionResult CreateCourse()
        {
            return View("CreateCourse");
        }

        [HttpPost]
        public async Task<IActionResult> CreateCourse(RegisterCourseViewModel data)
        {
            if (!ModelState.IsValid) return View("CreateCourse");

            var course = new CourseModel
            {
                CourseNumber = data.CourseNumber,
                CourseTitle = data.CourseTitle,
                CourseDesc = data.CourseDesc,
                CourseLength = data.CourseLength,
                CourseLevel = data.CourseLevel,
                Retired = data.Retired,
            };

            try
            {
                if (await _service.AddCourse(course)) return RedirectToAction("Index");
            }
            catch (System.Exception)
            {
                return View("Error");
            }

            return View("Error");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditCourseViewModel data)
        {
            try
            {
                var courseModel = new UpdateCourseViewModel
                {
                    CourseDesc = data.CourseDesc,
                    CourseLength = data.CourseLength,
                    Retired = data.Retired
                };
                if (await _service.UpdateCourse(data.Id, courseModel)) return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View("Error");
            }

            return View("Error");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var course = await _service.GetCourseAsync(id);

            var model = new EditCourseViewModel
            {
                CourseDesc = course.CourseDesc,
                CourseLength = course.CourseLength,
                Retired = course.Retired
            };

            return View("Edit", model);
        }
    }
}