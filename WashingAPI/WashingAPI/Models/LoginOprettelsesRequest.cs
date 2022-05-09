using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WashingAPI.Models
{
    public class LoginOprettelsesRequest
    {
        public string fornavn { get; set; }
        public string efternavn { get; set; }
        public string lejlighedsNummer { get; set; }

        public LoginOprettelsesRequest(string fornavn, string efternavn, string lejlighedsNummer)
        {
            this.fornavn = fornavn;
            this.efternavn = efternavn;
            this.lejlighedsNummer = lejlighedsNummer;
        }
    }
}
