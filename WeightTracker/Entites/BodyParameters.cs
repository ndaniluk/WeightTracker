using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeightTracker.Models
{
    public class BodyParameters
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Guid { get; set; }
        public float Chest { get; set; }
        public float Biceps { get; set; }
        public float Waist { get; set; }
        public float Hips { get; set; }
        public float Thigh { get; set; }
        public float Calf { get; set; }
        public float Height { get; set; }
        public float Weight { get; set; }
        public Guid MeasurementRecordGuid { get; set; }
        public MeasurementRecord MeasurementRecord { get; set; }
    }
}