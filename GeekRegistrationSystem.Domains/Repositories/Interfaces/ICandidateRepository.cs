using GeekRegistrationSystem.Domains.Entities;
using System.Collections.Generic;

namespace GeekRegistrationSystem.Domains.Repositories.Interfaces
{
    public interface ICandidateRepository
    {
        IEnumerable<Candidate> GetCandidates();

        IEnumerable<Candidate> GetCandidatesBySkills(IEnumerable<string> skills);

        void SaveNewCandidate(Candidate candidate);
    }
}
