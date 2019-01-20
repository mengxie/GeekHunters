using System.Linq;
using AutoMapper;
using GeekRegistrationSystem.ApplicationServices.DTO;
using GeekRegistrationSystem.Domains.Entities;

namespace GeekRegistrationSystem.Web
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {            
            CreateMap<Candidate, CandidateDto>()
                .ForMember(cr => cr.Skills, opt => opt.MapFrom(c => c.CandidateSkills.Select(cs => new SkillDto { Id = cs.Skill.Id, Name = cs.Skill.Name })));
        }
    }
}