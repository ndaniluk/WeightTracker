using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace WeightTracker.Models
{
    public class LoginInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Guid { get; set; }
        public string Username { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        [ForeignKey("UserInfo")]
        public Guid UserInfoGuid { get; set; }
    }
}