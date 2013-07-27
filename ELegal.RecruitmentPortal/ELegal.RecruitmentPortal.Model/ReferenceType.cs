using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELegal.RecruitmentPortal.Model
{
    public class ReferenceType
    {
        [Key]
        public int ReferenceTypeId { get; set; }
        public string ReferenceDescription { get; set; }
    }
}
