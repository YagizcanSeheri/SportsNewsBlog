using SportsNews.Entities;
using SportsNews.Service.Services;
using SportsNews.UI.Areas.Admin.Data.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsNews.UI.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        CategoryService _categoryService;
        public CategoryController()
        {
            _categoryService = new CategoryService();
        }
        // GET: Admin/Category
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category data) 
        {
            _categoryService.Add(data);
            return Redirect("/Admin/Category/List");
        }
        public ActionResult List() 
        {
            List<Category> model = _categoryService.GetActive();
            return View(model);
        }

        public ActionResult Update(int id) 
        {
            Category category = _categoryService.GetById(id);
            CategoryDTO model = new CategoryDTO();
            model.Id = category.Id;
            model.Name = category.Name;
            return View(model);
        }

        [HttpPost]
        public ActionResult Update(CategoryDTO model) 
        {
            Category category = _categoryService.GetById(model.Id);
            category.Name = model.Name;
            category.UpdateDate = DateTime.Now;
            category.Status = Status.Modified;
            _categoryService.Update(category);
            return Redirect("/Admin/Category/List");
        }
        public ActionResult Delete(int id) 
        {
            _categoryService.Remove(id);
            return Redirect("/Admin/Category/List");
        }
    }
}