using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PracaInzynierska.Models
{
    public class Worker
    {
        public int WorkerId { get; set; }
       [Required(ErrorMessage = "Enter your name")]
       [StringLength(15)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter your surname")]
        [StringLength(20)]
        public string Surname { get; set; }
        public int PhoneNumber { get; set; }
        [Required(ErrorMessage = "Enter your Email")]
        [StringLength(30)]
        public string EmailAdress { get; set; }
        public Position Position  { get; set; }

        public virtual Order Order { get; set; }
    }

    public enum Position
    {
        Owner,
        Worker,
        Other
    }




}