using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PIMS.Models
{
    public class Patient
    {
        public int PatientID { get; set; }
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
        public string EC1Name { get; set; }
        public string EC1Phone { get; set; }
        public string EC1Relationship { get; set; }
        public string EC2Name { get; set; }
        public string EC2Phone { get; set; }
        public string EC2Relationship { get; set; }
        public DateTime Admittance { get; set; }
        public string AdmittanceReason { get; set; }
        public string FamilyDoctor { get; set; }
        public string Facility { get; set; }
        public int FloorNumber { get; set; }
        public int RoomNumber { get; set; }
        public int BedNumber { get; set; }
        public DateTime Discharge { get; set; }
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
        public List<Patient> Patients { get; set; }
    }
}
