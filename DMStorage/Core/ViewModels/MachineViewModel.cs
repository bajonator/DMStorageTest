using DMStorage.Core.Models.Domains;
using System.Collections.Generic;

namespace DMStorage.Core.ViewModels
{
    public class MachineViewModel
    {
        public Department Department { get; set; }
        public Machine Machine { get; set; }
        public IEnumerable<Variable> Variables { get; set; }
    }
}
