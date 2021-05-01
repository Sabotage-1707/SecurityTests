using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityTestsUI.Library.Models
{
    public class Questions
    {
        public int Id { get; set; }
        public string Question { get; set; }

        public int RoleId { get; set; }

        public int TypeOfQuestionId { get; set; }

    }
}
