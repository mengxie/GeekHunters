using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GeekRegistrationSystem.Web.Models
{
    public class CreateCandidateViewModel
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Skills")]
        public List<SkillViewModel> Skills { get; set; }
    }
}