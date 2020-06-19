using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WeightTracker.Validators
{
   public class IsNumberGreaterThanZero: ValidationAttribute
   {
      public override bool IsValid(object value)
      {
         return value != null && float.TryParse(value.ToString(), out var i) && i > 0;
      }
   }
}
