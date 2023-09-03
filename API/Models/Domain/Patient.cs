namespace API.Models.Domain
{
    public class Patient
    {
        public int PatientID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string PatientAdress { get; set; }
        public string Illness { get; set; }
        public DateTime TreatMentStartDate { get; set; }
        public DateTime TreatMentEndDate { get; set; }
        public string DoctorName { get; set; }
    }
}
