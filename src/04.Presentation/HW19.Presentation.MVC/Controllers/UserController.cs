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

        public UserController(IUserService userService)
        {
            _userService = userService;
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
        public IActionResult Delete() 
        {
            return View();
        }
       
    }
}
