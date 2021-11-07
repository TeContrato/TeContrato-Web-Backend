namespace Supermarket.API.Domain.Models
{
    public class Project
    {
        public int Cproject { get; set; }
        public string Nproject { get; set; }
        public int Created_at { get; set; }
        public string Tdescription { get; set; }
        public string Fstatus { get; set; }
        public Contractor Contractor_Cuser { get; set; }
        public Client Client_Cuser { get; set; }
        public int Mbudget { get; set; }
        public ProjectControl CProjectControl { get; set; }
    }
}
