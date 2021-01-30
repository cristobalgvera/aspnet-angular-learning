using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBook.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CoverTypeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CoverTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index() => View();

        public IActionResult Upsert(int? id)
        {
            var coverType = new CoverType();

            if (id == null) return View(coverType);

            coverType = _unitOfWork.CoverTypeRepository.Get(id.GetValueOrDefault());

            if (coverType == null)
                return NotFound();

            return View(coverType);
        }

        #region API CALLS

        [HttpGet]
        public IActionResult GetAll() =>
            Json(new {data = _unitOfWork.CoverTypeRepository.GetAll()});

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(CoverType coverType)
        {
            if (!ModelState.IsValid)
                return NotFound();

            if (coverType.Id == 0)
                _unitOfWork.CoverTypeRepository.Add(coverType);
            else
                _unitOfWork.CoverTypeRepository.Update(coverType);

            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var coverType = _unitOfWork.CoverTypeRepository.Get(id);
            if (coverType == null)
                return Json(new {success = false, message = "Error while deleting"});

            _unitOfWork.CoverTypeRepository.Remove(coverType);
            _unitOfWork.Save();

            return Json(new {success = true, message = "Cover Type successfully deleted"});
        }

        #endregion
    }
}