using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RazorPage.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public String ResidenceCountry { get; set; }
        public String WorkCountry { get; set; }
        private String _pricetype { get; set; }
        public String PriceType {
            get {
                return _pricetype;
            }
            set {
                _pricetype = value;
                var unitpertype = new Dictionary<string, string>()
                {
                    {"DayPrice", "€/jour"},
                    {"HourPrice", "€/H"},
                    {"MonthPrice", "€/mois"},
                    {"TurnOver", "€"},
                    {"NotKnowPrice", ""}
                };
                PriceUnit = unitpertype[value ?? "NotKnowPrice"];
            }
        }
        public String PriceUnit { get; private set; }
        public int NetSalary { get; set; }
        public int BrutSalary { get; set; }
        public int MonthDuration { get; set; }
        public int DayByMonthDuration { get; set; }
        public String Civility { get; set; }
        public String Lastname { get; set; }
        public String Firstname { get; set; }
        public String Email { get; set; }
        public String Telephone { get; set; }
        public bool ConfidentialityPoliticAccepted { get; set; }
        public bool MarketingOfferAccepted { get; set; }
        public User()
        {

        }
        private int GetMissionDurationInDays()
        {
            if(MonthDuration == 0)
            {
                return DayByMonthDuration;
            }
            else
            {
                return MonthDuration * DayByMonthDuration;
            }
        }
        public int GetMissionBrutCA()
        {
            int CA = 0;
            int daysduration = GetMissionDurationInDays();
            switch (PriceType)
            {
                case "DayPrice":
                    CA = daysduration * BrutSalary;
                    break;
                case "HourPrice":
                    CA = daysduration * 7 * BrutSalary;
                    break;
                case "MonthPrice":
                    CA = MonthDuration * BrutSalary;
                    break;
                case "TurnOver":
                    CA = BrutSalary;
                    break;
                case "NotKnownPrice":
                    CA = daysduration * BrutSalary;
                    break;
            }
            return CA;
        }
    }
}