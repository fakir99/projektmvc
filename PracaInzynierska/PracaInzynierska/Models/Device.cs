using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PracaInzynierska.Models
{
    public class Device
    {
        public int DeviceId { get; set; }

       // [Required(ErrorMessage = "Enter name of device")]
      //  [StringLength(30)]
        public string Name { get; set; }
        public string Producer { get; set; }
      //  [Required(ErrorMessage = "choose type of device")]
        public string Type { get; set; }
        public bool IsWorking { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

    }

    public enum Type
    {
        Spot,
        Wash,
        Architecture,
        Beam,
        Entertaiment,
        Construction,
        Other
    }


}