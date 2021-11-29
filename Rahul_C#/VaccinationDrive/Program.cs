using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccinationDrive
{
    class Program
    {
        private static Beneficiary beneficiaryDetails = new Beneficiary();
        private static List<Beneficiary> beneficiaries = new List<Beneficiary>();
        static void Main(string[] args)
        {
            Beneficiary beneficiary = new Beneficiary();
            Beneficiary beneficiary1 = new Beneficiary("Rahul", 8220409931, "T Nagar", 22, 1);
            Beneficiary beneficiary2 = new Beneficiary("Aravind", 9003542151, "kodambakkam", 22, 1);
            beneficiary1.VaccineDetails(1, DateTime.Now);
            beneficiary2.VaccineDetails(2, DateTime.Now);
            beneficiaries.Add(beneficiary1);
            beneficiaries.Add(beneficiary2);
            int age, userchoice;
            string Name, City;
            long PhoneNumber;
        re:
            Console.WriteLine("------------------------------");
            Console.WriteLine("WELCOME TO VACCINATION DRIVE");
            Console.WriteLine("------------------------------");
            Console.WriteLine("Enter Your Option :");
            Console.WriteLine("1.Beneficiary Registration \n2.Vaccination \n3.Exit");
            Console.WriteLine("---------------------------------------------------");
            userchoice = Convert.ToInt32(Console.ReadLine());
            do
            {
                if (userchoice == 1 || userchoice == 2 || userchoice == 3)
                {
                    if (userchoice == 1)
                    {
                        Console.WriteLine("Enter Your Name : ");
                        Name = Console.ReadLine();
                        Console.WriteLine("Enter Your PhoneNumber : ");
                        PhoneNumber = Convert.ToInt64(Console.ReadLine());
                        Console.WriteLine("Enter your Address : ");
                        City = Console.ReadLine();
                        Console.WriteLine("Enter your Age : ");
                        age = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter your Gender  \n1.Male\n2.Female\n3.Other: ");
                        int Gender = Convert.ToInt32(Console.ReadLine());
                        beneficiary = new Beneficiary(Name, PhoneNumber, City, age, Gender);
                        Console.WriteLine("On Completion of Beneficiary Registration Number is \n" + beneficiary.RegistrationID);
                        beneficiaries.Add(beneficiary);
                        Console.WriteLine("------------------------------");

                        goto re;
                    }
                    else if (userchoice == 2)
                    {
                        foreach (Beneficiary details in beneficiaries)
                        {
                            Console.WriteLine("Registration ID : " + details.RegistrationID + " Beneficiary Name : " + details.Name);
                        }
                        Console.WriteLine("------------------------------");
                        Console.WriteLine("Enter your Registration ID ");
                        int registerNumber = Convert.ToInt32(Console.ReadLine());
                        foreach (Beneficiary regID in beneficiaries)
                        {
                            if (registerNumber == regID.RegistrationID)
                            {
                                beneficiaryDetails = regID;

                            }
                        }

                    again:

                        Console.WriteLine("Select Your Options");
                        Console.WriteLine("a.Take vaccination \nb.Vaccination History \nc.NextDueDate \nd.Exit");
                        string choice1 = Console.ReadLine();
                        switch (choice1)
                        {
                            case "a":
                                TakeVaccination();
                                goto again;

                            case "b":
                                VaccinationHistory();
                                goto again;
                            case "c":
                                Console.WriteLine(beneficiaryDetails.NextDueDate());
                                goto again;
                            case "d":
                                goto re;
                            default:
                                Console.WriteLine("Invalid Input");
                                break;

                        }
                        if (beneficiaryDetails.RegistrationID == 0)
                        {
                            Console.WriteLine("Invalid Registration Number \nPlease Enter valid one");
                        }

                    }
                    else if (userchoice == 3)
                    {
                        System.Environment.Exit(0);
                    }

                }


            } while (userchoice != 3);
            Console.ReadLine();
        }
        private static void TakeVaccination()
        {

            Console.WriteLine("Choose your Vaccine:\n1.Covaxin\n2.Covishield\n3.Sputnik");
            int vaccineType = Convert.ToInt32(Console.ReadLine());
            if (beneficiaryDetails.Vaccines.Count == 0)
            {
                Console.WriteLine("Enter your Date in the format of dd/mm/yyyy ");
                DateTime dateTime = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
                Console.WriteLine("You are Vaccinated " + beneficiaryDetails.VaccineDetails(vaccineType, dateTime));
            }
            else if (beneficiaryDetails.Vaccines.Count == 1)
            {

                Console.WriteLine("Enter your Date in the format of dd/mm/yyyy ");
                DateTime dateTime = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
                Console.WriteLine(beneficiaryDetails.VaccineDetails(vaccineType, dateTime));

            }
        }
        private static void VaccinationHistory()
        {
            foreach (VaccinationDetails vaccine in beneficiaryDetails.Vaccines)
            {
                Console.WriteLine("Vaccine : {0} \nDosage : {1} dose \nDate : {2}", vaccine.Vaccine, vaccine.Dosage, vaccine.DoseTime.ToString("dd/MM/yyyy"));
            }

        }
    }
}
