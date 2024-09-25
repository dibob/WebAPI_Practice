using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI_Practice.Models;
using WebAPI_Practice.Service.DoctorService;

namespace WebAPI_Practice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorInterface _doctorInterface;
        public DoctorController(IDoctorInterface doctorInterface) 
        {
            _doctorInterface = doctorInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<DoctorModel>>>> GetAllDoctors()
        {
            return Ok(await _doctorInterface.GetAllDoctors());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<DoctorModel>>> GetDoctorById(int id)
        {
            ServiceResponse<DoctorModel> serviceResponse = await _doctorInterface.GetDoctorById(id);

            return Ok(serviceResponse);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<DoctorModel>>>> CreateDoctor(DoctorModel newDoctor)
        {
            return Ok(await _doctorInterface.CreateDoctor(newDoctor));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<DoctorModel>>>> UpdateDoctor(DoctorModel updatedDoctor)
        {
            ServiceResponse<List<DoctorModel>> serviceResponse = await _doctorInterface.UpdateDoctor(updatedDoctor);

            return Ok(serviceResponse);
        }

        [HttpPut("deactivateDoctor")]
        public async Task<ActionResult<ServiceResponse<List<DoctorModel>>>> DeactivateDoctor(int id)
        {
            ServiceResponse<List<DoctorModel>> serviceResponse = await _doctorInterface.DeactivateDoctor(id);

            return Ok(serviceResponse);
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<List<DoctorModel>>>> DeleteDoctor(int id)
        {
            ServiceResponse<List<DoctorModel>> serviceResponse = await _doctorInterface.DeleteDoctor(id);

            return Ok(serviceResponse);
        }
    }   
}
