using HW19.Domain.ToDoAgg.Contracts.Services;
using HW19.Domain.ToDoAgg.Dtos;
using HW19.Domain.ToDoAgg.Entities;
using HW19.Domain.UserAgg.Contracts.Services;
using HW19.Domain.UserAgg.Dto;
using Microsoft.AspNetCore.Mvc;

namespace HW19.Presentation.MVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly ITodoService _todoService;

        public UserController(IUserService userService , ITodoService todoService)
        {
            _userService = userService;
            _todoService = todoService;
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
                    return RedirectToAction("Index","ToDo");

                }
                else 
                {
                    return View(userInfoInputDto);
                }
            }
            catch (Exception ex) 
            {
                ModelState.AddModelError("",ex.Message);
                return View(userInfoInputDto);
            }
           
        }
        public IActionResult Add() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Delete(int categoryId) 
        {
            try
            {
                    _todoService.Delete(categoryId);
                    TempData["SuccessMessage"] = "عملیات با موفقیت انجام شد.";

            }
            catch (Exception ex) 
            {
                TempData["ErrorMessage"] = ex.Message;

            }

            return RedirectToAction("Index", "ToDo");
        }
       
    }
}
