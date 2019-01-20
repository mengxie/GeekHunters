using System.Collections.Generic;

namespace GeekRegistrationSystem.ApplicationServices.DTO
{
    public class CandidateDto
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<SkillDto> Skills { get; set; }
    }
}
