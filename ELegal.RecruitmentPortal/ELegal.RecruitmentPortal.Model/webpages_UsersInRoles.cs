using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELegal.RecruitmentPortal.Model
{
    [Table("webpages_UsersInRoles")]
    public class UsersInRole
    {
        [Key, Column(Order = 0)]
        public int RoleId { get; set; }

        [Key, Column(Order = 1)]
        public int UserId { get; set; }

        [Column("RoleId"), InverseProperty("UsersInRoles")]
        public Role Roles { get; set; }

        [Column("UserId"), InverseProperty("UsersInRoles")]
        public Membership Members { get; set; }
    }
}
