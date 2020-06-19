using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WeightTracker.Data;
using WeightTracker.Entities;
using WeightTracker.Models;
using WeightTracker.Services;

namespace WeightTracker.Controllers
{
   [Route("admin")]
   public class AdminPanelController : Controller
   {
      private readonly WeightTrackerContext _dbContext;
      private readonly UserManager<User> _userManager;

      public AdminPanelController(WeightTrackerContext dbContext, UserManager<User> userManager)
      {
         _dbContext = dbContext;
         _userManager = userManager;
      }

      [HttpGet]
      public async Task<IActionResult> Index()
      {
         var userService = new UserService(_userManager, _dbContext);
         var users = _dbContext.Users.Select(user => user).ToList();
         var adminPanelUsers = new List<AdminPanelUser>();
         foreach(var user in users)
         {
            adminPanelUsers.Add(new AdminPanelUser(user.Id, user.Email, await userService.IsAdmin(user)));
         }
            return View(adminPanelUsers);
      }

      //[HttpPost]
      //public async Task<IActionResult> ChangeAdminRole()
      //{

      //}
   }
}