using System.Collections.Generic;
using System.Web.Mvc;
using GeekRegistrationSystem.ApplicationServices.DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeekRegistrationSystem.Web.Controllers;
using GeekRegistrationSystem.ApplicationServices.Interfaces;
using GeekRegistrationSystem.Web.Models;
using Moq;

namespace GeekRegistrationSystem.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        private Mock<IGeekHunterService> _geekHunterService;
        private HomeController _controller;


        [TestInitialize]
        public void TestInitialize()
        {
            _geekHunterService = new Mock<IGeekHunterService>();
            _geekHunterService.Setup(c => c.GetAllCandidates()).Returns(GetFakeCandidates());
            _controller = new HomeController(_geekHunterService.Object);
            
        }

        private List<CandidateDto> GetFakeCandidates()
        {
            var candidates = new List<CandidateDto>();
            candidates.Add(new CandidateDto()
            {
                FirstName = "sf",
                LastName = "fg",
                Skills = new List<SkillDto>
                    { new SkillDto { Id=2, Name="Java"}}
            });

            candidates.Add(new CandidateDto()
            {
                LastName = "aa",
                FirstName = "cf",
                Skills = new List<SkillDto>
                    { new SkillDto { Id = 1, Name = "JavaScript" } }
            });
            return candidates;
        }

        private ListCandidatesViewModel GetListCandidatesViewModel()
        {
            return new ListCandidatesViewModel()
            {
                SelectedSkills = new[] {"Java"}
            };
        }

        [TestMethod]
        public void ControllerIndexTest()
        {
            var result = _controller.Index() as ViewResult;
            Assert.IsNotNull(result);

        }

        [TestMethod]
        public void ControllerSearchTest()
        {
            var result = _controller.Search(GetListCandidatesViewModel()) as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void AddNewCandidate()
        {
            var result = _controller.Create() as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void About()
        {           
            var result = _controller.About() as ViewResult;
            if (result != null) Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }
    }
}
