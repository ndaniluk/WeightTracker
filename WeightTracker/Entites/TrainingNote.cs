using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeightTracker.Models
{
    public class TrainingNote
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Guid { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid TrainingRecordGuid { get; set; }
        public TrainingRecord TrainingRecord { get; set; }
    }
}