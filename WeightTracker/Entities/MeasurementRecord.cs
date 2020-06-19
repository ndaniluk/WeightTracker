using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WeightTracker.Validators;

namespace WeightTracker.Entities
{
   public class MeasurementRecord
   {
      public int Id { get; set; }
      [IsNumberGreaterThanZero]
      public float Chest { get; set; }
      [IsNumberGreaterThanZero]
      public float Biceps { get; set; }
      [IsNumberGreaterThanZero]
      public float Waist { get; set; }
      [IsNumberGreaterThanZero]
      public float Hips { get; set; }
      [IsNumberGreaterThanZero]
      public float Thigh { get; set; }
      [IsNumberGreaterThanZero]
      public float Calf { get; set; }
      [IsNumberGreaterThanZero]
      public float Height { get; set; }
      [IsNumberGreaterThanZero]
      public float Weight { get; set; }
      public DateTime TimeStamp { get; set; }
      public User User { get; set; }
   }
}