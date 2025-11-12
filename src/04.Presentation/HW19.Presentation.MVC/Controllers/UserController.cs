using HW19.Domain._common;
using HW19.Domain.ToDoAgg.Contracts.Services;
using HW19.Domain.ToDoAgg.Dtos;
using HW19.Domain.ToDoAgg.Entities;
using HW19.Domain.UserAgg.Contracts.Services;
using HW19.Domain.UserAgg.Dto;
using HW19.Domain.UserAgg.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HW19.Presentation.MVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly ITodoService _todoService;

        public UserController(IUserService userService, ITodoService todoService)
        {
            _userService = userService;
            _todoService = todoService;
        }

        public IActionResult Register() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(UserInfoInputDto userInfoInputDto) 
        {
            try
            {
                User? user=_userService.Register(userInfoInputDto);
                if (user!=null )
                {
                    TempData["SuccessMessage"] = "عملیات با موفقیت انجام شد.";
                    LocalStorage.Login(user);
                }
                else 
                {
                    TempData["FailureMessage"] = "عملیات با خطا روبرو شد.";
                }
            }
            catch (Exception ex) 
            {
                TempData["ErrorMessage"] = ex.Message;
            }
            return RedirectToAction("Index", "ToDo");
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserInfoInputDto userInfoInputDto)
        {
            try
            {
                int result = _userService.Login(userInfoInputDto);
                if (result > 0)
                {
                    return RedirectToAction("Index", "ToDo");

                }
                else
                {
                    return View(userInfoInputDto);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(userInfoInputDto);
            }

        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(CreateToDoDto model)
        {
            if (LocalStorage.LoginUser!=null)
            {
                int result = _todoService.Create(model);
                if (result > 0)
                {
                    TempData["SuccessMessage"] = "عملیات با موفقیت انجام شد.";
                }
                else
                {
                    TempData["FailureMessage"] = "عملیات با خطا روبرو شد.";
                }
                return RedirectToAction("Index", "ToDo");
            }
            else
            {
                TempData["FailureMessage"] = "عملیات با خطا روبرو شد.";
                return RedirectToAction("Index", "ToDo");
            }

        }

        [HttpPost]
        public IActionResult Delete(int toDoId)
        {
            try
            {
                int result = _todoService.Delete(toDoId);
                if (result > 0)
                {
                    TempData["SuccessMessage"] = "عملیات با موفقیت انجام شد.";
                }

                else
                {
                    TempData["FailureMessage"] = "عملیات با خطا روبرو شد.";
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;

            }

            return RedirectToAction("Index", "ToDo");
        }

        [HttpPost]
        public IActionResult ToggleStatus(int toDoId) 
        {
            try
            {
                int userId = LocalStorage.LoginUser.Id;
                int result =_todoService.ToggleStatus(toDoId,userId);
                if (result > 0)
                {
                    TempData["SuccessMessage"] = "عملیات با موفقیت انجام شد.";
                }

                else
                {
                    TempData["FailureMessage"] = "عملیات با خطا روبرو شد.";
                }
            }
            catch (Exception ex) 
            {
                TempData["ErrorMessage"] = ex.Message;

            }

            return RedirectToAction("Index", "ToDo");
        }
    }
}
