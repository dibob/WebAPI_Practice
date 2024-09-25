using WebAPI_Practice.Models;

namespace WebAPI_Practice.Service.PatientService
{
    public interface IPatientInterface
    {
        Task<ServiceResponse<List<PatientModel>>> GetAllPatients();
        Task<ServiceResponse<PatientModel>> GetPatientById(int id);
        Task<ServiceResponse<List<PatientModel>>> CreatePatient(PatientModel newPatient);
        Task<ServiceResponse<List<PatientModel>>> UpdatePatient(PatientModel updatedPatient);
        Task<ServiceResponse<List<PatientModel>>> DeletePatient(int id);
        Task<ServiceResponse<List<PatientModel>>> DeactivatePatient(int id);
    }
}
