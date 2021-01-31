using System;
using System.IO;
using System.Linq;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using BulkyBook.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BulkyBook.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index() => View();

        public IActionResult Upsert(int? id)
        {
            var productVm = new ProductVm()
            {
                Product = new Product(),
                CategoryList = _unitOfWork.CategoryRepository.GetAll()
                    .Select(category => new SelectListItem
                    {
                        Text = category.Name,
                        Value = category.Id.ToString()
                    }),
                CoverTypeList = _unitOfWork.CoverTypeRepository.GetAll()
                    .Select(coverType => new SelectListItem
                    {
                        Text = coverType.Name,
                        Value = coverType.Id.ToString()
                    })
            };

            if (id == null) return View(productVm);

            productVm.Product = _unitOfWork.ProductRepository.Get(id.GetValueOrDefault());

            if (productVm.Product == null)
                return NotFound();

            return View(productVm);
        }

        #region API CALLS

        [HttpGet]
        public IActionResult GetAll() =>
            Json(new
            {
                data = _unitOfWork.ProductRepository
                    .GetAll(includeProperties: "Category,CoverType")
            });

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(ProductVm productVm)
        {
            if (!ModelState.IsValid)
                return View(productVm);

            var webRootPath = _webHostEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;

            if (files.Count > 0)
            {
                var fileName = Guid.NewGuid().ToString();
                var uploads = Path.Combine(webRootPath, @"images\products");
                var extension = Path.GetExtension(files[0]?.FileName);
                if (productVm.Product.ImageUrl != null)
                {
                    var imagePath = Path.Combine(
                        webRootPath,
                        productVm.Product.ImageUrl.TrimStart('\\')
                    );
                    if (System.IO.File.Exists(imagePath))
                        System.IO.File.Delete(imagePath);
                }

                using var filesStreams = new FileStream(Path
                    .Combine(uploads, fileName + extension), FileMode.Create);

                files[0].CopyTo(filesStreams);

                productVm.Product.ImageUrl = $@"\images\products\{fileName + extension}";
            }
            else
            {
                if (productVm.Product.Id != 0)
                    productVm.Product.ImageUrl = _unitOfWork
                        .ProductRepository
                        .Get(productVm.Product.Id)
                        .ImageUrl;
            }

            if (productVm.Product.Id == 0)
                _unitOfWork.ProductRepository.Add(productVm.Product);
            else
                _unitOfWork.ProductRepository.Update(productVm.Product);

            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var product = _unitOfWork.ProductRepository.Get(id);
            if (product == null)
                return Json(new {success = false, message = "Error while deleting"});

            _unitOfWork.ProductRepository.Remove(product);
            _unitOfWork.Save();

            return Json(new {success = true, message = "Product successfully deleted"});
        }

        #endregion
    }
}