using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELegal.RecruitmentPortal.Model
{
    public class MenuItem
    {
        [Key]
        public int MenuItemId { get; set; }

        public string Icon { get; set; }
        public string ItemName { get; set; }
        public string Link { get; set; }
        public int OrderPosition { get; set; }

        public virtual Menu Menu { get; set; }
    }
}
