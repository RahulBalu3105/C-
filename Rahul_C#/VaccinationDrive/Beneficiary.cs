using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccinationDrive
{
    public class Beneficiary
    {
        public string Name { get; set; }
        public int RegistrationID { get; set; }
        private static int _registrationID = 1001;
        public long PhoneNumber { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public Gender GenderType { get; set; }
        public List<VaccinationDetails> Vaccines = new List<VaccinationDetails>();

        public enum Gender
        {
            Male,
            Female,
            Other
        }
        public string VaccineDetails(int vaccine, DateTime time)
        {

            if (Vaccines.Count == 0)
            {
                VaccinationDetails vaccineDetails = new VaccinationDetails(vaccine, time, 1);
                Vaccines.Add(vaccineDetails);
                return String.Format("Your Next Dose Due time is " + vaccineDetails.DoseTime.AddDays(30).ToString("dd/MM/yyyy"));
            }
            else if (Vaccines.Count == 1)
            {
                if (Vaccines[0].DoseTime > Vaccines[0].DoseTime.AddDays(30))
                {
                    VaccinationDetails vaccine1 = new VaccinationDetails(vaccine, time, 2);
                    Vaccines.Add(vaccine1);
                    return String.Format("You are now Vaccinated. Thank You for Participating");
                }
                else
                {
                    return String.Format("Second dose due date is " + Vaccines[0].DoseTime.AddDays(30).ToString("dd/MM/yyyy"));
                }

            }
            else
            {
                return String.Format("You had 2 doses already.");
            }

        }
        //Method for Next Due Date
        public string NextDueDate()
        {
            if (Vaccines.Count == 1)
            {
                return String.Format("Your Next dose due time is " + Vaccines[0].DoseTime.AddDays(30).ToString("dd/MM/yyyy"));
            }
            else
            {
                return String.Format("You have completed the vaccination course. Thanks for your participation in the vaccination drive.");
            }

        }
        //Default Constructor for BeneficiaryDetails
        public Beneficiary()
        {

        }
        //Parameterised Constructor for Beneficiary Details
        public Beneficiary(string Name, long phoneNumber, string address, int age, int gender)
        {
            this.Name = Name;
            this.RegistrationID = _registrationID++;
            this.PhoneNumber = phoneNumber;
            this.Age = age;
            this.Address = address;
            this.GenderType = (Gender)gender;


        }
    }
}
