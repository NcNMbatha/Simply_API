using Npgsql;
using Simple_API_Assessment.Models;

namespace Simple_API_Assessment.Interface
{
    public interface IAplicantRepository
    {
        Applicant GetApplicantById(int applicantId);
        List<Applicant> GetAllApplicants();
        bool CreateApplicant(Applicant applicant);
        bool UpdateApplicant(Applicant applicant);
        bool DeleteApplicant(int applicantId);
      
    }
}
