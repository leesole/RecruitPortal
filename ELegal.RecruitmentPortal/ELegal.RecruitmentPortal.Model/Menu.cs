using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELegal.RecruitmentPortal.Model
{
    public class Menu
    {
        [Key]
        public int MenuId { get; set; }
        public string MenuName { get; set; }
        public string Link { get; set; }
        public int OrderPosition { get; set; }
        public int MenuType { get; set; }
        public string Icon { get; set; }


        public virtual ICollection<MenuItem> MenuItems { get; set; }
    }
}
