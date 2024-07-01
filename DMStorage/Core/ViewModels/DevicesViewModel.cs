using DMStorage.Core.Models.Domains;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DMStorage.Core.ViewModels
{
    public class DevicesViewModel
    {
        public Device Device { get; set; }
        [Display(Name = "Oddeleni")]
        public Department Department { get; set; }
        public Machine Machine { get; set; }
        [Display(Name = "Filtruj podle typu zarizeni")]
        public TypeDevice TypeDevice { get; set; }
        public IEnumerable<Device> Devices { get; set; }
        [Display(Name = "Oddeleni")]
        public IEnumerable<Department> Departments { get; set; }
        [Required(ErrorMessage = "Pole povinné.")]
        [Display(Name = "Filtruj podle typu zarizeni")]
        public IEnumerable<TypeDevice> TypeDevices { get; set; }
        public IEnumerable<Machine> Machines { get; set; }
    }
}