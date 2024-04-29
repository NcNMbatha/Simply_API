using Microsoft.AspNetCore.Mvc;
using Simple_API_Assessment.Interface;
using Simple_API_Assessment.Models;

namespace Simple_API_Assessment.Controllers
{
    [Route("api/applicant")]
    public class ApplicantController : Controller
    {
        private readonly IAplicantRepository _applicantRepository;
        public ApplicantController(IAplicantRepository applicantRepository) 
        {
            _applicantRepository = applicantRepository;
        }

        [HttpGet]
        [Route("get-applicant-byId")]
        public IActionResult GetApplicantById(int applicantId)
        {
            return Ok(_applicantRepository.GetApplicantById(applicantId));
        }

        [HttpGet]
        [Route("get-all-applicants")]
        public IActionResult GetAllApplicants()
        {
            return Ok (_applicantRepository.GetAllApplicants());
        }

        [HttpPost]
        [Route("create-applicant")]
        public IActionResult CreateApplicant(Applicant applicant)
        {
            return Ok(_applicantRepository.CreateApplicant(applicant));
        }
        [HttpPut]
        [Route("update-applicant")]
        public IActionResult UpdateApplicant(Applicant applicant)
        {
            return Ok(_applicantRepository.UpdateApplicant(applicant));
        }

        [HttpDelete]
        [Route("delete-applicant")]
        public IActionResult DeleteApplicant(int applicantId)
        {
            return Ok (_applicantRepository.DeleteApplicant(applicantId));
        }
    }
}
