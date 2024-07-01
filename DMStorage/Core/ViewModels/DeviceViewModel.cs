using DMStorage.Core.Models.Domains;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DMStorage.Core.ViewModels
{
    public class DeviceViewModel
    {
        [Display(Name = "Typ Zarizeni")]
        public TypeDevice TypeDevice { get; set; }
        public Department Department { get; set; }
        public Machine Machine { get; set; }
        public Device Device { get; set; }
        [Display(Name = "Oddeleni")]
        public IEnumerable<Device> Devices { get; set; }
        public IEnumerable<Department> Departments { get; set; }
        public IEnumerable<Machine> Machines { get; set; }
    }
}
