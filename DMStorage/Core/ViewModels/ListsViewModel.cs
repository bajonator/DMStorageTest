using DMStorage.Core.Models.Domains;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DMStorage.Core.ViewModels
{
    public class ListsViewModel
    {
        public IEnumerable<Department> Departments { get; set; }
        public IEnumerable<Machine> Machines { get; set; }
        public IEnumerable<Device> Devices { get; set; }
        public IEnumerable<TypeDevice> TypeDevices { get; set; }
        public IEnumerable<Variable> Variables { get; set; }
    }
}
