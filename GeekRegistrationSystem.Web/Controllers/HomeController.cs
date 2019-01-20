using System.Data;
using GeekRegistrationSystem.ApplicationServices.DTO;
using GeekRegistrationSystem.ApplicationServices.Interfaces;
using GeekRegistrationSystem.Web.Models;
using System.Web.Mvc;
using System.Linq;
using System.Reflection;
using log4net;


namespace GeekRegistrationSystem.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGeekHunterService _geekHunterService;
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public HomeController(IGeekHunterService geekHunterService)
        {
            _geekHunterService = geekHunterService;
        }

        public ActionResult Index()
        {
            var viewModel = new ListCandidatesViewModel();
            try
            {
                var candidates = _geekHunterService.GetAllCandidates();
                var skills = _geekHunterService.GetAllSkills();

                viewModel.SkillList = skills.Select(x => new SkillViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Selected = true
                }).ToList();

                viewModel.Candidates = candidates.ToList();
            }
            catch (System.Exception ex)
            {
                Log.Error("Error occurred in Index method: " + ex.Message);

            }
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Heading = "Create Candidate";
            var viewModel = new CreateCandidateViewModel();
            try
            {
                var skills = _geekHunterService.GetAllSkills();

                viewModel.Skills = skills.Select(x => new SkillViewModel()
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Selected = false
                    })
                    .ToList();
            }
            catch (System.Exception ex)
            {
                Log.Error("Error occurred in Create method: " + ex.Message);

            }
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateCandidateViewModel viewModel)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var candidate = new CandidateDto
                    {
                        FirstName = viewModel.FirstName,
                        LastName = viewModel.LastName,
                        Skills = viewModel.Skills.Where(x => x.Selected)
                            .Select(x => new SkillDto()
                            {
                                Name = x.Name,
                                Id = x.Id
                            }).ToList()
                    };
                    _geekHunterService.AddCandidate(candidate);
                }
                catch (DataException ex)
                {
                    Log.Error("Error occurred in post Create method: " + ex.Message);
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult Search(ListCandidatesViewModel viewModel)
        {
            if (viewModel.SelectedSkills != null)
            {
                var skills = viewModel.SelectedSkills;
                try
                {
                    viewModel.Candidates = _geekHunterService.FilterCandidates(skills).ToList();
                    viewModel.SkillList = _geekHunterService.GetAllSkills().Select(x => new SkillViewModel()
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Selected = true
                    }).ToList();
                }
                catch (System.Exception ex)
                {
                    Log.Error("Error occurred in Search method: " + ex.Message);

                }

                return View("Index", viewModel);
            }

            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
    }
}