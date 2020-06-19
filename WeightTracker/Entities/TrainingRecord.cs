using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeightTracker.Entities
{
   public class TrainingRecord
   {
      public int Id { get; set; }
      public string Title { get; set; }
      [DataType(DataType.MultilineText)]
      public string Description { get; set; }
      [DataType(DataType.Date)]
      public DateTime TimeStamp { get; set; }
      public User User { get; set; }
   }
}