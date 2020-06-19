using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeightTracker.Entities
{
   public class MeasurementRecord
   {
      public int Id { get; set; }
      public float Chest { get; set; }
      public float Biceps { get; set; }
      public float Waist { get; set; }
      public float Hips { get; set; }
      public float Thigh { get; set; }
      public float Calf { get; set; }
      public float Height { get; set; }
      public float Weight { get; set; }
      public DateTime TimeStamp { get; set; }
      public User User { get; set; }
   }
}