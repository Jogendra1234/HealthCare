using API.DBHandler;
using API.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private DbPatientContext dbContext { get; }

        public PatientController(DbPatientContext context)
        {
            dbContext = context;
        }
        //Get all patient detail

        [HttpGet("GetAll")]
        public ActionResult GetAll()
        {
            var dbResult = dbContext.Patients.ToList();
            List<PatientDTO> lstPatient = new();
            foreach (var patient in dbResult) 
            {
                lstPatient.Add(new PatientDTO
                {
                    FirstName = patient.FirstName,
                    LastName = patient.LastName,
                    FatherName = patient.FatherName,
                    Email   = patient.Email,
                    Mobile = patient.Mobile,
                    PatientAdress = patient.PatientAdress,
                    Illness = patient.Illness,
                    TreatMentStartDate =    patient.TreatMentStartDate,
                    TreatMentEndDate = patient.TreatMentEndDate,
                    DoctorName =    patient.DoctorName
                });
            };
            return Ok(lstPatient);
        }

        //Get patient detail by ID
        [HttpGet("GetById")]
        public ActionResult GetById([FromQuery] int Id)
        {
            var dbResult = dbContext.Patients.Where(x=> x.PatientID == Id).FirstOrDefault();
            if(dbResult != null)
            {
                PatientDTO patient = new()
                {
                    FirstName = dbResult.FirstName,
                    LastName = dbResult.LastName,
                    FatherName = dbResult.FatherName,
                    Email = dbResult.Email,
                    Mobile = dbResult.Mobile,
                    PatientAdress = dbResult.PatientAdress,
                    Illness = dbResult.Illness,
                    TreatMentStartDate = dbResult.TreatMentStartDate,
                    TreatMentEndDate = dbResult.TreatMentEndDate,
                    DoctorName = dbResult.DoctorName
                };
                return Ok(dbResult);
            }
            return NotFound();
        }
    }
}
