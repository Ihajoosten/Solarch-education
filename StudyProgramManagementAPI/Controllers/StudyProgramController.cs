using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudyProgramManagementAPI.Repositories;

namespace StudyProgramManagementAPI.Controllers
{
    [Route("api/[controller]")]
    public class StudyProgramController : Controller
    {
        private readonly IStudyProgramRepository _studyProgramRepo;

        public StudyProgramController(IStudyProgramRepository studyProgramRepo)
        {
            _studyProgramRepo = studyProgramRepo;
        }

        [HttpGet]
        [Route("studyprograms")]
        public async Task<IActionResult> GetStudyPrograms()
        {
            return Ok(await _studyProgramRepo.GetStudyPrograms());
        }
    }
}