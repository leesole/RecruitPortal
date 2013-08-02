using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELegal.RecruitmentPortal.Model
{
    public class RecruitmentCompanyRate
    {
        [Key]
        public int RecruitmentCompanyRateId { get; set; }

        public virtual VacancyType VacancyType { get; set; }
        public decimal Rate { get; set; }
    }
}
