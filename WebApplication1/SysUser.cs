using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
{
    [Table("SYS_USER")]
    public class SysUser
    {
        [Key, Column("USER_ID", TypeName = "NUMBER(19)")]
        public long UserId { get; set; }

        [Column("USER_NAME")]
        public string UserName { get; set; }
    }
}
