namespace GeekRegistrationSystem.Domains.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Candidate")]
    public sealed class Candidate
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Candidate()
        {
            CandidateSkills = new HashSet<CandidateSkill>();
        }

        public long Id { get; set; }

        [Required]
        [StringLength(2147483647)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(2147483647)]
        public string LastName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<CandidateSkill> CandidateSkills { get; set; }
    }
}
