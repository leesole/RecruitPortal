using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELegal.RecruitmentPortal.Model
{
    public class RecruitmentCompany: IRpAudit
    {
        [Key]
        public int RecruitmentCompanyId { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("CompanyName")]
        public string CompanyName { get; set; }
        public string LogoUrl { get; set; }
        public string Notes { get; set; }
        public string TandC { get; set; }
        public virtual ICollection<RecruitmentCompanyRate> RecruitmentCompanyRates { get; set; }

        



        public DateTime CreatedDate { get; set; }
        public string CreatedUser { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdatedUser { get; set; }
        public decimal Version { get; set; }
    }
}
