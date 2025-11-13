using HW19.Domain._common;
using HW19.Domain.ToDoAgg.Contracts.Services;
using HW19.Domain.ToDoAgg.Dtos;
using HW19.Domain.UserAgg.Contracts.Services;
using HW19.Presentation.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace HW19.Presentation.MVC.Controllers
{
    public class ToDoController : Controller
    {
        private readonly ITodoService _toDoService;
        public ToDoController(ITodoService toDoService)
        {
            _toDoService = toDoService;
        }
        public IActionResult Index(string searchTerm, string sortBy)
        {
            if (LocalStorage.LoginUser != null)
            {
                
                List<ToDoInfoDto> fetchedToDos = _toDoService.GetAll(LocalStorage.LoginUser.Id, searchTerm, sortBy);

                ToDoIndexViewModel viewModel = new ToDoIndexViewModel
                {
                    ToDos = fetchedToDos,
                    SearchTerm = searchTerm, 
                    SortBy = sortBy           
                };
                return View(viewModel); 
            }

            return RedirectToAction("Login", "User");
        }
    }

}

