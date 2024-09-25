using Microsoft.EntityFrameworkCore;
using WebAPI_Practice.DataContext;
using WebAPI_Practice.Models;

namespace WebAPI_Practice.Service.PatientService
{
    public class PatientService : IPatientInterface
    {
        private readonly ApplicationDbContext _context;
        public PatientService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<List<PatientModel>>> CreatePatient(PatientModel newPatient)
        {
            ServiceResponse<List<PatientModel>> serviceResponse = new ServiceResponse<List<PatientModel>>();

            try
            {
                if (newPatient == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "Informar dados!";
                    serviceResponse.Sucess = false;

                    return serviceResponse;
                }
                _context.Add(newPatient);
                await _context.SaveChangesAsync();

                serviceResponse.Data = _context.Patients.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Sucess = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<PatientModel>>> DeactivatePatient(int id)
        {
            ServiceResponse<List<PatientModel>> serviceResponse = new ServiceResponse<List<PatientModel>>();

            try
            {
                PatientModel patient = _context.Patients.FirstOrDefault(x => x.Id == id);

                if (patient == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "O paciente não foi encontrado!";
                    serviceResponse.Sucess = false;
                }

                patient.IsActive = false;
                patient.ModifiedIn = DateTime.Now.ToLocalTime();

                _context.Patients.Update(patient);
                await _context.SaveChangesAsync();

                serviceResponse.Data = _context.Patients.ToList();
            }
            catch (Exception ex) 
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Sucess = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<PatientModel>>> DeletePatient(int id)
        {
            ServiceResponse<List<PatientModel>> serviceResponse = new ServiceResponse<List<PatientModel>>();

            try
            {
                PatientModel patient = _context.Patients.FirstOrDefault(x => x.Id == id);

                if (patient == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "O paciente não foi encontrado!";
                    serviceResponse.Sucess = false;
                }

                _context.Patients.Remove(patient);
                await _context.SaveChangesAsync();

                serviceResponse.Data = _context.Patients.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Sucess = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<PatientModel>>> GetAllPatients()
        {
            ServiceResponse<List<PatientModel>> serviceResponse = new ServiceResponse<List<PatientModel>>();
            
            try
            {
                serviceResponse.Data = _context.Patients.ToList();
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

        public async Task<ServiceResponse<PatientModel>> GetPatientById(int id)
        {
            ServiceResponse<PatientModel> serviceResponse = new ServiceResponse<PatientModel>();

            try
            {
                PatientModel patient = _context.Patients.FirstOrDefault(x => x.Id == id);

                if (patient == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "O paciente não foi encontrado!";
                    serviceResponse.Sucess = false;
                }

                serviceResponse.Data = patient;

            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Sucess = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<PatientModel>>> UpdatePatient(PatientModel updatedPatient)
        {
            ServiceResponse<List<PatientModel>> serviceResponse = new ServiceResponse<List<PatientModel>>();

            try
            {
                PatientModel patient = _context.Patients.AsNoTracking().FirstOrDefault(x =>x.Id == updatedPatient.Id);

                if (patient == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "O paciente não foi encontrado!";
                    serviceResponse.Sucess = false;
                }

                patient.ModifiedIn = DateTime.Now.ToLocalTime();

                _context.Patients.Update(updatedPatient);
                await _context.SaveChangesAsync();

                serviceResponse.Data = _context.Patients.ToList();
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
