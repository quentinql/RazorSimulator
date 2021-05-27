using System;
namespace RazorPage.Models
{
    public class Simulator
    {
        private readonly RazorPage.Data.UserContext _context;
        public Simulator(User user)
        {
            double ManagementCostsRate = 0.05;
            double BrutGeneratedRate = 0.659111;
            double NetGeneratedRate = 0.79348;
            double NetTaxableRate = 0.8243;
            double TaxableRate = 0;
            int Fees = 460;
            CA = user.GetMissionBrutCA();
            ManagementCosts = (float)(CA * ManagementCostsRate);
            Consultant = CA - ManagementCosts;
            ExpenseReport = 500;
            Interessement = (float)(0.1 * CA);
            ChargedAmount = Consultant - ExpenseReport - Interessement;
            BrutGenerated = (float)(ChargedAmount * BrutGeneratedRate);
            EmployersContribution = ChargedAmount - BrutGenerated;
            EmployeeContributions = (float)(BrutGenerated * NetGeneratedRate);
            NetTaxable = (float)((NetTaxableRate * BrutGenerated)+(Interessement * 0.903));
            NetBeforeTax = (float)((0.965 * NetTaxable) + ExpenseReport);
            NetGenerated = (float)((NetGeneratedRate * BrutGenerated) + (Interessement * 0.903) + Fees + ExpenseReport);
            RestitutionAfterTax = (float)((NetTaxable * (1 - TaxableRate))+ ExpenseReport + Fees);
        }
        public int CA { get; set; }
        public float ManagementCosts { get; set; }
        public float Consultant { get; set; }
        public float ExpenseReport { get; set; }
        public float Interessement { get; set; }
        public float ChargedAmount { get; set; }
        public float EmployersContribution { get; set; }
        public float BrutGenerated { get; set; }
        public float EmployeeContributions { get; set; }
        public float NetTaxable { get; set; }
        public float NetBeforeTax { get; set; }
        public float NetGenerated { get; set; }
        public float TaxRate { get; set; }
        public float RestitutionAfterTax { get; set; }
    }
}
