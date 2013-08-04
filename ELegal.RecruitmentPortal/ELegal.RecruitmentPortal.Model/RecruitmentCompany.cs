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
        [DisplayName("Company Name")]
        public string CompanyName { get; set; }

        [DataType(DataType.ImageUrl)]
        [DisplayName("Company Logo Url")]
        public string LogoUrl { get; set; }
        
        [DisplayName("Address Line 1")]
        public string Address1 { get; set; }
        [DisplayName("Address Line 2")]
        public string Address2 { get; set; }
        [DisplayName("Address Line 3")]
        public string Address3 { get; set; }
        [DisplayName("Address Line 4")]
        public string Address4 { get; set; }
        [DisplayName("City / Town")]
        public string City { get; set; }
        [DisplayName("County")]
        public string County { get; set; }
        [DataType(DataType.PostalCode)]
        [DisplayName("Postcode")]
        public string Postcode { get; set; }
        [DataType(DataType.PhoneNumber)]
        [DisplayName("Telephone No.")]
        public string Telephone { get; set; }
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        public virtual MetaKeyValue Rating { get; set; }

        public virtual ICollection<RecruitmentUser> RecruitmentUsers { get; set; } 
        public virtual ICollection<RecruitmentCompanyRate> RecruitmentCompanyRates { get; set; }

        public bool Deleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedUser { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdatedUser { get; set; }
        public decimal Version{ get; set; }
    }
}
