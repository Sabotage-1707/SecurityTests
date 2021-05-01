using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityTestsUI.Library.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public int RoleId { get; set; }
        public bool VereficationStatusByFireSafety { get; set; }

        public bool VereficationStatusByIndustrialSafety { get; set; }

        public string Name { get; set; }

        public string EmailAddress { get; set; }

        public DateTime Birthday { get; set; }
        public int CounterOfUsedTries { get; set; }

        public DateTime DateTimeOfLastTryByFireSafety { get; set; }

        public DateTime DateTimeOfLastTryByIndustrialSafety { get; set; }

    }
}
