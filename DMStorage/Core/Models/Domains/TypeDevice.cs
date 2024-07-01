using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace DMStorage.Core.Models.Domains
{
    public class TypeDevice
    {
        public TypeDevice()
        {
            Devices = new Collection<Device>();
        }
        public int Id { get; set; }
        [Required(ErrorMessage = "Pole povinné.")]
        [Display(Name = "Nazev typu zarizeni")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Pole povinné.")]
        [Display(Name = "Typ Zarizeni")]
        public ICollection<Device> Devices { get; set; }
    }
}
