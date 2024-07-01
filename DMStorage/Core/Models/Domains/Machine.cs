using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace DMStorage.Core.Models.Domains
{
    public class Machine
    {
        public Machine()
        {
            Variables = new Collection<Variable>();
            Devices = new Collection<Device>();
        }
        public int Id { get; set; }
        [MaxLength(50)]
        [Required(ErrorMessage = "Pole povinné.")]
        [Display(Name = "Nazev stroje")]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Ip {  get; set; }
        [MaxLength(50)]
        [Display(Name = "Mac Adress")]
        public string MacAdress { get; set; }
        public string Port { get; set; }
        public string DMCZ_Connection { get; set; }
        public string OPC_Driver { get; set; }
        public string OPC_PLC { get; set; }
        public string Original_PLC { get; set; }
        [MaxLength(50)]
        public string VLan { get; set; }
        [Required(ErrorMessage = "Pole povinné.")]
        [Display(Name = "Nazev Oddeleni")]
        public int DepartmentId { get; set; }

        public Department Department { get; set; }
        public ICollection<Variable> Variables { get; set; }
        public ICollection<Device> Devices { get; set; }
    }
}
