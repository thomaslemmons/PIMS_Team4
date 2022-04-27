using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PIMS.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using System.IO;
using PIMS.Data;


namespace PIMS.Controllers
{
    public enum Role
    {
        Doctor,
        MedicalStaff,
        OfficeStaff,
        Volunteer
    }

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;


        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            /*if (User.Identity.IsAuthenticated)
            {
                if ()
                return View();
            }
            else
            {
                return Redirect("/");
            }*/
            return Redirect("/");
        }

        [Route("Home/DoctorPatientList/{id?}")]
        public IActionResult DoctorPatientList(string id)
        {
            //get list of all patients from db

            PatientList PList = new PatientList();
            List<Patient> PatientList = new List<Patient>();
            PList.Patients = GetPatientList(id);
            ViewBag.SearchQuery = id;

            return View(PList);
        }

        [HttpGet]
        [Route("/Home/DoctorPatientDetail/{id}")]
        public IActionResult DoctorPatientDetail(int id)
        {
            //get info for singular patient

            Patient p = GetPatient(id);

            return View(p);
        }

        [HttpGet]
        [Route("/Home/DoctorPatientEdit/{id}")]
        public IActionResult DoctorPatientEdit(int id)
        {
            //get info for singular patient

            Patient p = GetPatient(id);

            return View(p);
        }

        [HttpPost]
        [Route("/Home/DoctorPatientEdit/{id}")]
        public IActionResult DoctorPatientEdit(int id, Patient p)
        {
            //get info for singular patient

            int id2 = UpdatePatient(id, p, Role.Doctor);
            Patient p1 = GetPatient(p.PatientID);

            return Redirect("/Home/DoctorPatientDetail/" + id);
        }

        [Route("Home/NursePatientList/{id?}")]
        public IActionResult NursePatientList(string id)
        {
            //get list of all patients from db

            PatientList PList = new PatientList();
            PList.Patients = GetPatientList(id);
            ViewBag.SearchQuery = id;

            return View(PList);
        }

        [HttpGet]
        [Route("/Home/NursePatientDetail/{id}")]
        public IActionResult NursePatientDetail(int id)
        {
            //get info for singular patient

            Patient p = GetPatient(id);

            return View(p);
        }

        [HttpGet]
        [Route("/Home/NursePatientEdit/{id}")]
        public IActionResult NursePatientEdit(int id)
        {
            //get info for singular patient

            Patient p = GetPatient(id);

            return View(p);
        }

        [HttpPost]
        [Route("/Home/NursePatientEdit/{id}")]
        public IActionResult NursePatientEdit(int id, Patient p)
        {
            //get info for singular patient

            int id2 = UpdatePatient(id, p, Role.MedicalStaff);
            Patient p1 = GetPatient(p.PatientID);

            return Redirect("/Home/NursePatientDetail/" + id);
        }

        [Route("Home/OfficePatientList/{id?}")]
        public IActionResult OfficePatientList(string id)
        {
            //get list of all patients from db

            PatientList PList = new PatientList();
            PList.Patients = GetPatientList(id);
            ViewBag.SearchQuery = id;

            return View(PList);
        }

        [HttpGet]
        [Route("/Home/OfficePatientDetail/{id}")]
        public IActionResult OfficePatientDetail(int id)
        {
            //get info for singular patient

            Patient p = GetPatient(id);

            return View(p);
        }

        [HttpGet]
        [Route("/Home/OfficePatientEdit/{id}")]
        public IActionResult OfficePatientEdit(int id)
        {
            //get info for singular patient

            Patient p = GetPatient(id);

            return View(p);
        }

        [HttpPost]
        [Route("/Home/OfficePatientEdit/{id}")]
        public IActionResult OfficePatientEdit(int id, Patient p)
        {
            //get info for singular patient

            int id2 = UpdatePatient(id, p, Role.OfficeStaff);
            Patient p1 = GetPatient(p.PatientID);

            return Redirect("/Home/OfficePatientDetail/" + id);
        }

        [Route("Home/VolunteerPatientList/{id?}")]
        public IActionResult VolunteerPatientList(string id)
        {
            //get list of all patients from db

            PatientList PList = new PatientList();
            PList.Patients = GetPatientList(id);
            ViewBag.SearchQuery = id;

            return View(PList);
        }

        [HttpGet]
        [Route("/Home/VolunteerPatientDetail/{id}")]
        public IActionResult VolunteerPatientDetail(int id)
        {
            //get info for singular patient

            Patient p = GetPatient(id);

            return View(p);
        }

        [HttpGet]
        [Route("/Home/VolunteerPatientEdit/{id}")]
        public IActionResult VolunteerPatientEdit(int id)
        {
            //get info for singular patient

            Patient p = GetPatient(id);

            return View(p);
        }

        [HttpPost]
        [Route("/Home/VolunteerPatientEdit/{id}")]
        public IActionResult VolunteerPatientEdit(int id, Patient p)
        {
            //get info for singular patient

            int id2 = UpdatePatient(id, p, Role.Volunteer);
            Patient p1 = GetPatient(p.PatientID);

            return Redirect("/Home/VolunteerPatientDetail/" + id);
        }

        public List<Patient> GetPatientList(string id)
        {
            //call database and get list of patients

            List<Patient> PList = new List<Patient>();

            using (var db = new PatientContext())
            {
                var query = from p in db.Patients
                            select p;
                if (!String.IsNullOrEmpty(id))
                {
                    query = query.Where(s => s.FirstName!.Contains(id) || s.LastName!.Contains(id));
                }
                foreach (var item in query)
                {
                    Patient p1 = item;
                    PList.Add(p1);
                }

            }

            return PList;
        }

        public Patient GetPatient(int id)
        {
            //get all information about individual patient
            Patient p1 = new Patient();

            using (var db = new PatientContext())
            {
                var query = from p in db.Patients
                            where p.PatientID == id
                            select p;
                foreach (var item in query)
                {
                    p1 = item;
                }

            }


            return p1;
        }
        public int UpdatePatient(int id, Patient p, Role r)
        {

            using (var db = new PatientContext())
            {
                var query = from patient in db.Patients
                            where patient.PatientID == id
                            select patient;
                foreach (var item in query)
                {
                    if(r == Role.Doctor)
                    {
                        item.FirstName = p.FirstName;
                        item.MiddleName = p.MiddleName;
                        item.LastName = p.LastName;
                        item.Address = p.Address;
                        item.City = p.City;
                        item.State = p.State;
                        item.Zipcode = p.Zipcode;
                        item.HomePhone = p.HomePhone;
                        item.WorkPhone = p.WorkPhone;
                        item.MobilePhone = p.MobilePhone;
                        item.EC1Name = p.EC1Name;
                        item.EC1Phone = p.EC1Phone;
                        item.EC1Relationship = p.EC1Relationship;
                        item.EC2Name = p.EC2Name;
                        item.EC2Phone = p.EC2Phone;
                        item.EC2Relationship = p.EC2Relationship;
                        item.Admittance = p.Admittance;
                        item.AdmittanceReason = p.AdmittanceReason;
                        item.FamilyDoctor = p.FamilyDoctor;
                        item.FloorNumber = p.FloorNumber;
                        item.RoomNumber = p.RoomNumber;
                        item.BedNumber = p.BedNumber;
                        item.Discharge = p.Discharge;
                        item.DoctorNotes = p.DoctorNotes;
                        item.Prescriptions = p.Prescriptions;
                        item.Procedures = p.Procedures;
                        item.ApprovedVisitors = p.ApprovedVisitors;
                        item.NumberOfVisitors = p.NumberOfVisitors;
                    }
                    if (r == Role.MedicalStaff)
                    {
                        item.FirstName = p.FirstName;
                        item.MiddleName = p.MiddleName;
                        item.LastName = p.LastName;
                        item.Address = p.Address;
                        item.City = p.City;
                        item.State = p.State;
                        item.Zipcode = p.Zipcode;
                        item.HomePhone = p.HomePhone;
                        item.WorkPhone = p.WorkPhone;
                        item.MobilePhone = p.MobilePhone;
                        item.EC1Name = p.EC1Name;
                        item.EC1Phone = p.EC1Phone;
                        item.EC1Relationship = p.EC1Relationship;
                        item.EC2Name = p.EC2Name;
                        item.EC2Phone = p.EC2Phone;
                        item.EC2Relationship = p.EC2Relationship;
                        item.Admittance = p.Admittance;
                        item.AdmittanceReason = p.AdmittanceReason;
                        item.FamilyDoctor = p.FamilyDoctor;
                        item.FloorNumber = p.FloorNumber;
                        item.RoomNumber = p.RoomNumber;
                        item.BedNumber = p.BedNumber;
                        item.Discharge = p.Discharge;
                        item.NurseNotes = p.NurseNotes;
                        item.Prescriptions = p.Prescriptions;
                        item.Procedures = p.Procedures;
                        item.ApprovedVisitors = p.ApprovedVisitors;
                        item.NumberOfVisitors = p.NumberOfVisitors;
                    }
                    if (r == Role.OfficeStaff)
                    {
                        item.FirstName = p.FirstName;
                        item.MiddleName = p.MiddleName;
                        item.LastName = p.LastName;
                        item.Address = p.Address;
                        item.City = p.City;
                        item.State = p.State;
                        item.Zipcode = p.Zipcode;
                        item.HomePhone = p.HomePhone;
                        item.WorkPhone = p.WorkPhone;
                        item.MobilePhone = p.MobilePhone;
                        item.EC1Name = p.EC1Name;
                        item.EC1Phone = p.EC1Phone;
                        item.EC1Relationship = p.EC1Relationship;
                        item.EC2Name = p.EC2Name;
                        item.EC2Phone = p.EC2Phone;
                        item.EC2Relationship = p.EC2Relationship;
                        item.Admittance = p.Admittance;
                        item.AdmittanceReason = p.AdmittanceReason;
                        item.FamilyDoctor = p.FamilyDoctor;
                        item.FloorNumber = p.FloorNumber;
                        item.RoomNumber = p.RoomNumber;
                        item.BedNumber = p.BedNumber;
                        item.Discharge = p.Discharge;
                        item.InsuranceCarrier = p.InsuranceCarrier;
                        item.InsuranceInfo = p.InsuranceInfo;
                        item.BillingInfo = p.BillingInfo;
                        item.AmountPaid = p.AmountPaid;
                        item.AmountOwed = p.AmountOwed;
                        item.AmountInsurancePaid = p.AmountInsurancePaid;
                        item.ApprovedVisitors = p.ApprovedVisitors;
                        item.NumberOfVisitors = p.NumberOfVisitors;
                    }
                    if (r == Role.Volunteer)
                    {
                        item.FirstName = p.FirstName;
                        item.MiddleName = p.MiddleName;
                        item.LastName = p.LastName;
                        item.FloorNumber = p.FloorNumber;
                        item.RoomNumber = p.RoomNumber;
                        item.BedNumber = p.BedNumber;
                        item.ApprovedVisitors = p.ApprovedVisitors;
                        item.NumberOfVisitors = p.NumberOfVisitors;
                    }

                }
                db.SaveChanges();

            }


            return id;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
