using System;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBook.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index() => View();

        public IActionResult Upsert(int? id)
        {
            var category = new Category();

            if (id == null)
                return View(category);

            category = _unitOfWork.CategoryRepository.Get(id.GetValueOrDefault());

            if (category == null)
                return NotFound();

            return View(category);
        }

        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            var categories = _unitOfWork.CategoryRepository.GetAll();
            return Json(new {data = categories});
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Category category)
        {
            if (!ModelState.IsValid)
                return NotFound();

            if (category.Id == 0)
                _unitOfWork.CategoryRepository.Add(category);
            else
                _unitOfWork.CategoryRepository.Update(category);

            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var category = _unitOfWork.CategoryRepository.Get(id);
            if (category == null)
                return Json(new {success = false, message = "Error while deleting"});

            _unitOfWork.CategoryRepository.Remove(category);
            _unitOfWork.Save();

            return Json(new {success = true, message = "Category successfully deleted"});
        }

        #endregion
    }
}