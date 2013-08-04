using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELegal.RecruitmentPortal.Model
{
    public class Vacancy : IRpAudit
    {
        [Key]
        public int VacancyId { get; set; }

        public string VacancyName { get; set; }
        public string VacancyDescription { get; set; }

        public bool Deleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedUser { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdatedUser { get; set; }
        public decimal Version{ get; set; }
    }
}
