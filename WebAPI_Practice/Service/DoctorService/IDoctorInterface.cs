using WebAPI_Practice.Models;

namespace WebAPI_Practice.Service.DoctorService
{
    public interface IDoctorInterface
    {
        Task<ServiceResponse<List<DoctorModel>>> GetAllDoctors();
        Task<ServiceResponse<DoctorModel>> GetDoctorById(int id);
        Task<ServiceResponse<List<DoctorModel>>> CreateDoctor(DoctorModel newDoctor);
        Task<ServiceResponse<List<DoctorModel>>> UpdateDoctor(DoctorModel updatedDoctor);
        Task<ServiceResponse<List<DoctorModel>>> DeleteDoctor(int id);
        Task<ServiceResponse<List<DoctorModel>>> DeactivateDoctor(int id);
    }
}
