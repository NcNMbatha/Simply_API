using Dapper;
using Microsoft.AspNetCore.Http;
using Npgsql;
using Simple_API_Assessment.Interface;
using Simple_API_Assessment.Models;

namespace Simple_API_Assessment.Data.Repository
{
    public class ApplicantRepository : IAplicantRepository
    {
        private readonly string _connectionString;

        public ApplicantRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public Applicant GetApplicantById(int applicantId)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                var applicant = connection.Query<Applicant>($"SELECT \"Id\", \"Name\" FROM public.\"Applicant\" WHERE \"Id\" = {applicantId};").FirstOrDefault();
                return new Applicant()
                {
                    Id = applicantId,
                    Name = applicant.Name,
                    Skills = (ICollection<Skill>)connection.Query<Skill>($"SELECT \"Id\", \"Name\", \"ApplicantId\" FROM public.\"Skill\" WHERE \"ApplicantId\" = {applicantId};")
                };
            }
        }
        public List<Applicant> GetAllApplicants()
        {
            var applicants = new List<Applicant>();
            var connection = new NpgsqlConnection(_connectionString);
            var applicant = connection.Query<Applicant>("SELECT \"Id\", \"Name\" FROM public.\"Applicant\";").ToList();

            foreach (var app in applicant) 
            {
                var skills = (ICollection<Skill>)connection.Query<Skill>($"SELECT \"Id\", \"Name\", \"ApplicantId\" FROM public.\"Skill\" WHERE \"ApplicantId\" = {app.Id};");
                
                if (skills.Count() > 0)
                {
                    app.Skills = skills;
                }
                applicants.Add(app);
            }

            return applicants;
        }

        public bool CreateApplicant(Applicant applicant)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                var results = connection.Execute($"INSERT INTO public.\"Applicant\"(\"Id\", \"Name\") VALUES({applicant.Id}, '{applicant.Name}');");

                if (results > 0 && applicant.Skills.Count() > 0)
                {
                    foreach (var skill in applicant.Skills)
                    {
                        connection.Execute($"INSERT INTO public.\"Skill\"(\"Id\", \"Name\", \"ApplicantId\") VALUES ({skill.Id}, '{skill.Name}', {applicant.Id});");
                    }

                    return true;
                }
              
            }
            return false;
        }

        public bool UpdateApplicant(Applicant applicant)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                var results = connection.Execute($"UPDATE public.\"Applicant\" " +
                                                 $"SET \"Name\"='{applicant.Name}'" +
                                                 $"WHERE \"Id\" = {applicant.Id};");
                return results > 0;
            }
        }

        public bool DeleteApplicant(int applicantId) 
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                var results = connection.Execute($"DELETE FROM public.\"Applicant\" WHERE \"Id\" = {applicantId};");
                var skills = connection.Query<Skill>($"SELECT \"Id\" FROM public.\"Skill\" WHERE \"ApplicantId\" = {applicantId};").ToList();
              
                if (results > 0 && skills.Count() > 0) 
                {
                    connection.Execute($"DELETE FROM public.\"Skill\" WHERE \"ApplicantId\" = {applicantId};");
                }

                return results > 0;
            }
        }

    }
}
