using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeightTracker.Data;
using WeightTracker.Entities;
using WeightTracker.Models;
using WeightTracker.Services;

namespace WeightTracker.Controllers
{
   public class AdminPanelUsersController : Controller
   {
      private readonly WeightTrackerContext _dbContext;
      private readonly UserManager<User> _userManager;
      private readonly UserService userService = null;


      public AdminPanelUsersController(WeightTrackerContext dbContext, UserManager<User> userManager)
      {
         _dbContext = dbContext;
         _userManager = userManager;
         userService = new UserService(_userManager, _dbContext);

      }


      public async Task<IActionResult> Index()
      {
         var users = await _dbContext.Users.Select(user => user).ToListAsync();
         var adminPanelUsers = new List<AdminPanelUser>();
         foreach (var user in users)
         {
            adminPanelUsers.Add(new AdminPanelUser(user.Id, user.Email, await userService.IsAdmin(user)));
         }
         return View(adminPanelUsers);
      }

      public async Task<IActionResult> Edit(string id)
      {
         if (id == null)
         {
            return NotFound();
         }

         var adminPanelUser = await userService.getAdminPanelUserById(id);
         if (adminPanelUser == null)
         {
            return NotFound();
         }
         return View(adminPanelUser);
      }

      [HttpPost]
      [ValidateAntiForgeryToken]
      public async Task<IActionResult> EditRole(string id)
      {
         if (id == null)
         {
            return NotFound();
         }
         var user = _dbContext.Users.SingleOrDefault(x => x.Id == id);

         if (await userService.IsAdmin(user))
         {
            if (User.Identity.Name != user.UserName)
            {
               await _userManager.RemoveFromRoleAsync(user, "ADMINISTRATOR");
            }
         }
         else
         {
            await _userManager.AddToRoleAsync(user, "ADMINISTRATOR");
         }

         return RedirectToAction(nameof(Index));
      }

      public async Task<IActionResult> Delete(string id)
      {
         if (id == null)
         {
            return NotFound();
         }

         var user = await userService.getAdminPanelUserById(id);

         if (user == null)
         {
            return NotFound();
         }


         return View(user);
      }

      [HttpPost, ActionName("Delete")]
      [ValidateAntiForgeryToken]
      public async Task<IActionResult> DeleteConfirmed(string id)
      {
         if (id == null)
         {
            return NotFound();
         }
         var user = _dbContext.Users.SingleOrDefault(x => x.Id == id);

         if (User.Identity.Name != user.UserName)
         {
            _dbContext.Users.Remove(user);
         }
         await _dbContext.SaveChangesAsync();
         return RedirectToAction(nameof(Index));
      }
   }
}
