using GeekRegistrationSystem.ApplicationServices.DTO;
using System.Collections.Generic;

namespace GeekRegistrationSystem.Web.Models
{
    public class ListCandidatesViewModel
    {
        public List<SkillViewModel> SkillList { get; set; }
        public List<CandidateDto> Candidates { get; set; }

        public string[] SelectedSkills { get; set; }

    }
}