using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DMStorage.Core.Models.Domains
{
    public class User
    {
        public int Id { get; set; }
        [Required (ErrorMessage ="Pole je povinne.")]
        [Display (Name ="Nazev uzivatele")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Pole je povinne.")]
        [Display(Name = "Heslo")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Pole je povinne.")]
        public string Email { get; set; }
        public int RoleId { get; set; }

        public Role Role { get; set; }
    }
}