
namespace GeekRegistrationSystem.ApplicationServices.DTO
{
    public class CandidateSkillDto
    {
        public long Id { get; set; }
        public long CandidateId { get; set; }
        public long SkillId { get; set; }
        public CandidateDto Candidate { get; set; }
        public SkillDto Skill { get; set; }
    }
}
