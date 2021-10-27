using System.Collections.Generic;

namespace LuaTest
{
    public class AgreementService
    {
        public string Piss()
        {
            return "piss";
        }

        public Agreement[] GetAgreements()
        {
            return new Agreement[]
            {
                new Agreement
                {
                    Id = 0,
                    DisplayName = "AgreementX",
                    Enabled = true
                },

                new Agreement
                {
                    Id = 1,
                    DisplayName = "AgreementY",
                    Enabled = true
                },

                new Agreement
                {
                    Id = 2,
                    DisplayName = "AgreemenyZ",
                    Enabled = false
                }
            };
        }
    }
}
