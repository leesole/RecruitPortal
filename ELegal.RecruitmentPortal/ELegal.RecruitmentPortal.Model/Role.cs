﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELegal.RecruitmentPortal.Model
{
    [Table("webpages_Roles")]
    public class Role
    {
        public Role()
        {
            UsersInRoles = new List<UsersInRole>();
        }

        [Key]
        public int RoleId { get; set; }
        [StringLength(256)]
        public string RoleName { get; set; }

        //public ICollection<Membership> Members { get; set; }

        [ForeignKey("RoleId")]
        public ICollection<UsersInRole> UsersInRoles { get; set; }
       
    }
}
