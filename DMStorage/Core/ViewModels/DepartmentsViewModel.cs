using DMStorage.Core.Models;
using DMStorage.Core.Models.Domains;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DMStorage.Core.ViewModels
{
    public class DepartmentsViewModel
    {
        public Variable Variable { get; set; }

        [Required(ErrorMessage = "Pole povinné.")]
        [Display(Name = "Filtruj podle oddeleni")]
        public Department Department { get; set; }

        [Required(ErrorMessage = "Pole povinné.")]
        [Display(Name = "Stroj")]
        public Machine Machine { get; set; }

        [Required(ErrorMessage = "Pole povinné.")]
        [Display(Name = "Oddeleni")]
        public IEnumerable<Department> Departments { get; set; }

        [Required(ErrorMessage = "Pole povinné.")]
        [Display(Name = "Stroj")]
        public IEnumerable<Machine> Machines { get; set; }

        public IEnumerable<Variable> Variables { get; set; }
        //public Filter Filter { get; set; }
        //public int CurrentPage { get; internal set; }
        //public int TotalPages { get; internal set; }
    }
}
