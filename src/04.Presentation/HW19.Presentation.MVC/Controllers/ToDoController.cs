using HW19.Domain.ToDoAgg.Contracts.Services;
using HW19.Domain.ToDoAgg.Dtos;
using HW19.Domain.UserAgg.Contracts.Services;
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
        public IActionResult Index()
        {

            List<ToDoInfoDto> toDoInfoDtos= _toDoService.GetAll();
            return View(toDoInfoDtos);
        }

    }
}
