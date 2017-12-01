using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PracaInzynierska.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        [Required(ErrorMessage = "Enter place")]
        [StringLength(50)]
        public string Place { get; set; }
        [Required(ErrorMessage = "Enter start time")]      
        public DateTime StartTime{ get; set; }
        public DateTime EndTime { get; set; }       
        public DateTime TimeAtWorehouse { get; set; }
        public string Comment { get; set; }

        public virtual ICollection<Worker> Workers{ get; set; }
        public virtual ICollection<Device> Devices { get; set; }

    }
}