using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobCode.Core.Entities
{
    public class Company: BaseEntity
    {
        public Company(string name, string cPNJ, string sector, string comercialPhone)
            :base()
        {
            Name = name;
            CPNJ = cPNJ;
            Sector = sector;
            ComercialPhone = comercialPhone;
        }

        public string Name { get; private set; }
        public string CPNJ { get; private set; }
        public string Sector { get; private set; }
        public string ComercialPhone { get; private set; }
        public ICollection<User> Users { get; set; } = new List<User>();
    }
}
