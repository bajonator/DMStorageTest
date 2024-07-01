using DMStorage.Helpers;
using System.ComponentModel.DataAnnotations;

namespace DMStorage.Core.Models.Domains
{
    public class Device
    {
        public int Id { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "Pole povinné.")]
        [Display(Name = "Nazev Zarizeni")]
        public string Name { get; set; }

        public string MacAdress { get; set; }
        public string Ip { get; set; }
        public string InventoryNumber { get; set; }
        public string SerialNumber { get; set; }
        public string State { get; set; } 
        public string WPAUserName { get; set; }
        public string WPAPassword { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "Pole povinné.")]
        [Display(Name = "Typ zarizeni")]
        public int TypeDeviceId { get; set; }
        public int DepartmentId { get; set; }
        public int MachineId { get; set; }
        public Department Department { get; set; }
        public Machine Machine { get; set; }
        public TypeDevice TypeDevice { get; set; }


    }
}
