using System.Collections.Generic;

namespace NUnitTest
{
    internal class Data
    {
        public Dictionary<string, string> generateData()
        {
            Dictionary<string, string> person = new Dictionary<string, string>();
            person.Add("name", "Tcc");
            person.Add("last_name", "Gabriel");
            person.Add("contact_first_name", "Teste");
            person.Add("phone", "92 9999-9999");
            person.Add("addressLine1", "Av Darcy Vargas, 1200");
            person.Add("addressLine2", "Stem");
            person.Add("city", "Manaus");
            person.Add("state", "AM");
            person.Add("postal_code", "69050-020");
            person.Add("country", "Brasil");
            person.Add("from_employeer", "Fixter");
            person.Add("credit_limit", "200");
            return person;
        }
    }
}
