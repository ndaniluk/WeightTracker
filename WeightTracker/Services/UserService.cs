using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeightTracker.Data;
using WeightTracker.Entities;
using WeightTracker.Models;

namespace WeightTracker.Services
{
   public class UserService
   {
      private readonly UserManager<User> _userManager;
      private readonly WeightTrackerContext _dbContext;
      public UserService(UserManager<User> userManager, WeightTrackerContext dbContext)
      {
         _userManager = userManager;
         _dbContext = dbContext;
      }

      public async Task<bool> IsAdmin(User user)
      {
         return await _userManager.IsInRoleAsync(user, "ADMINISTRATOR");
      }

      public async Task<AdminPanelUser> getAdminPanelUserById(string id)
      {
         var userService = new UserService(_userManager, _dbContext);
         var user = _dbContext.Users.Where(x => x.Id == id).SingleOrDefault();
         return new AdminPanelUser(user.Id, user.Email, await IsAdmin(user));
      }
   }
}
