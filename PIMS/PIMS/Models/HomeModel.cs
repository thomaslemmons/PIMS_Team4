using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PIMS.Models
{
    public class Patient
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zipcode { get; set; }
        public int HomePhone { get; set; }
        public int WorkPhone { get; set; }
        public int MobilePhone { get; set; }
        public string EmergencyContact1 { get; set; }
        public string EmergencyContact2 { get; set; }
        public DateTime AdmitDate { get; set; }
        public DateTime AdmitTime { get; set; }
        public string AdmitReason { get; set; }
        public string FamilyDoctor { get; set; }
        public string Facility { get; set; }
        public int Floor { get; set; }
        public int RoomNumber { get; set; }
        public int BedNumber { get; set; }
        public DateTime DischargeDate { get; set; }
        public DateTime DischargeTime { get; set; }
        public string DoctorNotes { get; set; }
        public string NurseNotes { get; set; }
        public string Prescriptions { get; set; }
        public string Procedures { get; set; }
        public string InsuranceCarrier { get; set; }
        public string InsuranceInfo { get; set; }
        public string BillingInfo { get; set; }
        public int AmountPaid { get; set; }
        public int AmountOwed { get; set; }
        public int AmountInsurancePaid { get; set; }
        public string ApprovedVisitors { get; set; }
        public int NumberOfVisitors { get; set; }
    }

    public class PatientList
    {
        public List<Patient> PList { get; set; }
        public int role { get; set; }
    }
}
