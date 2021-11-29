using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccinationDrive
{
    public class VaccinationDetails
    {
        public enum VaccineName
        {
            Covishield,
            Covaxin,
            Sputnik

        }
        public int Dosage { get; set; }
        public DateTime DoseTime { get; set; }
        public VaccineName Vaccine { get; set; }
        public VaccinationDetails()
        {

        }
        public VaccinationDetails(int vaccine, DateTime doseTime, int doseCount)
        {
            this.Vaccine = (VaccineName)vaccine;
            this.DoseTime = doseTime;
            this.Dosage = doseCount;
        }
    }
}

