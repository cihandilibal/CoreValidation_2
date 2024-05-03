using CoreValidation_2.Models.ContextClasses;
using CoreValidation_2.Models.Entities;
using CoreValidation_2.Models.ViewModels.PureVM.Categories;
using Microsoft.AspNetCore.Mvc;

namespace CoreValidation_2.Controllers
{
    public class CategoryController : Controller
    {
        MyContext _db;

        public CategoryController(MyContext db)
        {
            _db = db;
        }


        public IActionResult GetCategories()
        {
            return View();
        }
        public IActionResult CreateCategory()
        {
            return View();
        }

        //Server Side Validation : Bilgiler BackEnd'e gönderilir...Ve Validation Back End'de kontrol edilir...

        //Client Side Validation : Bilgiler istemciden ayrılamaz Validation Front End'de kontrol edilir...
        //Bunun icin tek yapmanız gereken şey .Net Core MVC'deki iki kütüphaneyi kullanmaktır...

        [HttpPost]
        public IActionResult CreateCategory(CategoryRequestModel category)
        {
            //Server Side Validation'da bilgiler back end'e gönderilir ve kontrol öyle saglanır
            if (ModelState.IsValid) //Model durumu Validation'dan gecmiş ise 
            { //bu, server-side validation.
                //Mapping ( Bir tipin bilgilerinin diger istenilen tipe aktarılmasıdır)
                Category c = new()
                {
                    CategoryName = category.CategoryName,
                    Description = category.Description
                };

                _db.Categories.Add(c);
                _db.SaveChanges();
                return RedirectToAction("GetCategories");
            }
            //model gecerli degilse, model kullaniciya geri gider.
            return View(category);
        }
    }
}
