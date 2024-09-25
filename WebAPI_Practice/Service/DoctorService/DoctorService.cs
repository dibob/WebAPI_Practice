using Microsoft.EntityFrameworkCore;
using WebAPI_Practice.DataContext;
using WebAPI_Practice.Models;

namespace WebAPI_Practice.Service.DoctorService
{
    public class DoctorService : IDoctorInterface
    {
        private readonly ApplicationDbContext _context;
        public DoctorService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<List<DoctorModel>>> CreateDoctor(DoctorModel newDoctor)
        {
            ServiceResponse<List<DoctorModel>> serviceResponse = new ServiceResponse<List<DoctorModel>>();

            try
            {
                if (newDoctor == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "Informar dados!";
                    serviceResponse.Sucess = false;

                    return serviceResponse;
                }
                _context.Add(newDoctor);
                await _context.SaveChangesAsync();

                serviceResponse.Data = _context.Doctors.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Sucess = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<DoctorModel>>> DeactivateDoctor(int id)
        {
            ServiceResponse<List<DoctorModel>> serviceResponse = new ServiceResponse<List<DoctorModel>>();

            try
            {
                DoctorModel doctor = _context.Doctors.FirstOrDefault(x => x.Id == id);

                if (doctor == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "O médico não foi encontrado!";
                    serviceResponse.Sucess = false;
                }

                doctor.IsActive = false;
                doctor.ModifiedIn = DateTime.Now.ToLocalTime();

                _context.Doctors.Update(doctor);
                await _context.SaveChangesAsync();

                serviceResponse.Data = _context.Doctors.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Sucess = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<DoctorModel>>> DeleteDoctor(int id)
        {
            ServiceResponse<List<DoctorModel>> serviceResponse = new ServiceResponse<List<DoctorModel>>();

            try
            {
                DoctorModel doctor = _context.Doctors.FirstOrDefault(x => x.Id == id);

                if (doctor == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "O médico não foi encontrado!";
                    serviceResponse.Sucess = false;
                }

                _context.Doctors.Remove(doctor);
                await _context.SaveChangesAsync();

                serviceResponse.Data = _context.Doctors.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Sucess = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<DoctorModel>>> GetAllDoctors()
        {
            ServiceResponse<List<DoctorModel>> serviceResponse = new ServiceResponse<List<DoctorModel>>();

            try
            {
                serviceResponse.Data = _context.Doctors.ToList();
                if (serviceResponse.Data.Count == 0)
                {
                    serviceResponse.Message = "Nenhum dado encontrado!";
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Sucess = false;
            }

            return serviceResponse;

        }

        public async Task<ServiceResponse<DoctorModel>> GetDoctorById(int id)
        {
            ServiceResponse<DoctorModel> serviceResponse = new ServiceResponse<DoctorModel>();

            try
            {
                DoctorModel doctor = _context.Doctors.FirstOrDefault(x => x.Id == id);

                if (doctor == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "O médico não foi encontrado!";
                    serviceResponse.Sucess = false;
                }

                serviceResponse.Data = doctor;

            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Sucess = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<DoctorModel>>> UpdateDoctor(DoctorModel updatedDoctor)
        {
            ServiceResponse<List<DoctorModel>> serviceResponse = new ServiceResponse<List<DoctorModel>>();

            try
            {
                DoctorModel doctor = _context.Doctors.AsNoTracking().FirstOrDefault(x => x.Id == updatedDoctor.Id);

                if (doctor == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "O médico não foi encontrado!";
                    serviceResponse.Sucess = false;
                }

                doctor.ModifiedIn = DateTime.Now.ToLocalTime();

                _context.Doctors.Update(updatedDoctor);
                await _context.SaveChangesAsync();

                serviceResponse.Data = _context.Doctors.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Sucess = false;
            }

            return serviceResponse;
        }
    }
}
