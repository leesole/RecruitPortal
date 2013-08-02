using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELegal.RecruitmentPortal.Model
{
    public class VacancyType
    {
        [Key]
        public int VacancyTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ParentVacancyTypeId { get; set; }


    }
}
