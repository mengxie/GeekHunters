using GeekRegistrationSystem.ApplicationServices.DTO;
using System.Collections.Generic;

namespace GeekRegistrationSystem.ApplicationServices.Interfaces
{
    public interface IGeekHunterService
    {
        IEnumerable<CandidateDto> GetAllCandidates();
        IEnumerable<CandidateDto> FilterCandidates(IEnumerable<string> skills);
        void AddCandidate(CandidateDto candidate);
        IEnumerable<SkillDto> GetAllSkills();

    }
}
