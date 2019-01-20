namespace GeekRegistrationSystem.Domains.Entities
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("CandidateSkill")]
    public class CandidateSkill
    {
        public long Id { get; set; }

        public long CandidateId { get; set; }

        public long SkillId { get; set; }

        public virtual Candidate Candidate { get; set; }

        public virtual Skill Skill { get; set; }
    }
}
