using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace DMStorage.Core.Models.Domains
{
    public class Department
    {
        public Department()
        {
            Machines = new Collection<Machine>();
            Devices = new Collection<Device>();
        }
        public int Id { get; set; }
        [MaxLength(50)]
        [Required(ErrorMessage = "Pole povinné .")]
        [Display(Name = "Nazev Oddeleni")]
        public string Name { get; set; }
        public string Number {  get; set; }

        public ICollection<Machine> Machines { get; set; }
        public ICollection<Device> Devices { get; set; }
    }
}
