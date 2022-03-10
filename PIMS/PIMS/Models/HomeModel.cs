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
        public string Zipcode { get; set; }
        public string HomePhone { get; set; }
        public string WorkPhone { get; set; }
        public string MobilePhone { get; set; }
        public string EmergencyContact1 { get; set; }
        public string EmergencyContact2 { get; set; }
        public string AdmitDate { get; set; }
        public string AdmitTime { get; set; }
        public string AdmitReason { get; set; }
        public string FamilyDoctor { get; set; }
        public string Facility { get; set; }
        public string Floor { get; set; }
        public string RoomNumber { get; set; }
        public string BedNumber { get; set; }
        public string DischargeDate { get; set; }
        public string DischargeTime { get; set; }
        public string DoctorNotes { get; set; }
        public string NurseNotes { get; set; }
        public string Prescriptions { get; set; }
        public string Procedures { get; set; }
        public string InsuranceCarrier { get; set; }
        public string InsuranceInfo { get; set; }
        public string BillingInfo { get; set; }
        public string AmountPaid { get; set; }
        public string AmountOwed { get; set; }
        public string AmountInsurancePaid { get; set; }
        public string ApprovedVisitors { get; set; }
        public string NumberOfVisitors { get; set; }
    }

    public class PatientList
    {
        public List<Patient> PList { get; set; }
        public int role { get; set; }
    }
}
