using Microsoft.AspNetCore.Identity;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using WeightTracker.Data;
using WeightTracker.Entities;

namespace WeightTracker.Services
{
   public class TrainingService
   {
      private readonly WeightTrackerContext _dbContext;

      public TrainingService(WeightTrackerContext dbContext)
      {
         _dbContext = dbContext;
      }

   }
}
