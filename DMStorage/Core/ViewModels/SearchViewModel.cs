using DMStorage.Core.Models.Domains;
using System.Collections.Generic;

namespace DMStorage.Core.ViewModels
{
    public class SearchViewModel
    {
        public List<Device> Devices { get; set; }
        public List<Department> Departments { get; set; }
        public List<TypeDevice> TypeDevices { get; set; }
        public List<Machine> Machines { get; set; }
        public List<Variable> Variables { get; set; }

        public Device Device { get; set; }
        public Department Department { get; set; }
        public TypeDevice TypeDevice { get; set; }
        public Machine Machine { get; set; }
        public Variable Variable { get; set; }
    }
}
