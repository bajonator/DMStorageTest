using DMStorage.Core.Models.Domains;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DMStorage.Core.ViewModels
{
    public class DepartmentViewModel
    {
        [Required(ErrorMessage = "Pole povinné.")]

        [Display(Name = "Oddeleni")]
        public Department Department { get; set; }
        [Required(ErrorMessage = "Pole povinné.")]

        [Display(Name = "Stroj")]
        public Machine Machine { get; set; }
        public Variable Variable { get; set; }
        public Device Device { get; set; }

        [Required(ErrorMessage = "Pole povinné.")]
        [Display(Name = "Stroj")]
        public IEnumerable<Machine> Machines { get; set; }
        [Required(ErrorMessage = "Pole povinné.")]
        [Display(Name = "Oddeleni")]
        public IEnumerable<Department> Departments { get; set; }
        public IEnumerable<Device> Devices { get; set; }

    }
}
