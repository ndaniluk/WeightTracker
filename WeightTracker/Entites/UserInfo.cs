using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeightTracker.Models
{
    public class UserInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age
        {
            get
            {
                var today = DateTime.Today;
                var age = today.Year - DateOfBirth.Year;
                return DateOfBirth.Date > today.AddYears(-age) ? --age : age;
            }
            set { }
        }
        public DateTime DateOfBirth { get; set; }
        public LoginInfo LoginInfo { get; set; }
        public ICollection<TrainingRecord> TrainingRecords { get; set; }
        public ICollection<MeasurementRecord> MeasurementRecords { get; set; }
    }
}