using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PIMS.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PIMS.Controllers
{
    enum Role
    {
        Doctor,
        MedicalStaff,
        OfficeStaff,
        Volunteer
    }

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DoctorPatientList()
        {
            //get list of all patients from db

            List<Patient> PList = GetPatientList();

            return View();
        }

        public IActionResult DoctorPatientDetail(int id)
        {
            //get info for singular patient

            Patient p = GetPatient(id);

            return View();
        }

        public IActionResult MedicalPatientList()
        {
            //get list of all patients from db

            List<Patient> PList = GetPatientList();

            return View();
        }

        public IActionResult MedicalPatientDetail(int id)
        {
            //get info for singular patient

            Patient p = GetPatient(id);

            return View();
        }

        public IActionResult OfficePatientList()
        {
            //get list of all patients from db

            List<Patient> PList = GetPatientList();

            return View();
        }

        public IActionResult OfficePatientDetail(int id)
        {
            //get info for singular patient

            Patient p = GetPatient(id);

            return View();
        }

        public IActionResult VolunteerPatientList()
        {
            //get list of all patients from db

            List<Patient> PList = GetPatientList();

            return View();
        }

        public IActionResult VolunteerPatientDetail(int id)
        {
            //get info for singular patient

            Patient p = GetPatient(id);

            return View();
        }

        public List<Patient> GetPatientList()
        {
            //call database and get list of patients
            List<Patient> PList = new List<Patient>();
            return PList;
        }

        public Patient GetPatient(int id)
        {
            //get all information about individual patient
            Patient p = new Patient();
            return p;
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
