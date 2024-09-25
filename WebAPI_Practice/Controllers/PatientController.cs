using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI_Practice.Models;
using WebAPI_Practice.Service.PatientService;

namespace WebAPI_Practice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientInterface _patientInterface;
        public PatientController(IPatientInterface patientInterface) 
        {
            _patientInterface = patientInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<PatientModel>>>> GetAllPatients()
        {
            return Ok(await _patientInterface.GetAllPatients());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<PatientModel>>> GetPatientById(int id)
        {
            ServiceResponse<PatientModel> serviceResponse = await _patientInterface.GetPatientById(id);

            return Ok(serviceResponse);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<PatientModel>>>> CreatePatient(PatientModel newPatient)
        {
            return Ok(await _patientInterface.CreatePatient(newPatient));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<PatientModel>>>> UpdatePatient(PatientModel updatedPatient)
        {
            ServiceResponse<List<PatientModel>> serviceResponse = await _patientInterface.UpdatePatient(updatedPatient);

            return Ok(serviceResponse);
        }

        [HttpPut("deactivatePatient")]
        public async Task<ActionResult<ServiceResponse<List<PatientModel>>>> DeactivatePatient(int id)
        {
            ServiceResponse<List<PatientModel>> serviceResponse = await _patientInterface.DeactivatePatient(id);

            return Ok(serviceResponse);
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<List<PatientModel>>>> DeletePatient(int id)
        {
            ServiceResponse<List<PatientModel>> serviceResponse = await _patientInterface.DeletePatient(id);

            return Ok(serviceResponse);
        }
    }   
}
