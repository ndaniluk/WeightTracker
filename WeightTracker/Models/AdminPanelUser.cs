using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeightTracker.Models
{
   public class AdminPanelUser
   {
      public string Id { get; private set; }
      public string Email { get; private set; }
      public bool IsAdmin { get; private set; }

      public AdminPanelUser(string id, string email, bool isAdmin)
      {
         Id = id;
         Email = email;
         IsAdmin = isAdmin;
      }
   }
}
