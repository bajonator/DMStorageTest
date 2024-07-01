using System.ComponentModel.DataAnnotations;

namespace DMStorage.Core.Models.Domains
{
    public class Variable
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Pole povinné.")]
        [Display(Name = "Nazev promenne")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Pole povinné.")]
        [Display(Name = "Nazev Stroju")]
        public int MachineId { get; set; }
        [Display(Name = "Komentar")]
        public string Description { get; set; }
        public string DataType { get; set; }

        public Machine Machine { get; set; }
    }
}
