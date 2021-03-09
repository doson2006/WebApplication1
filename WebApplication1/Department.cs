using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
{
	[Table("SYS_DEPARTMENT")]
	public class Department
	{
		[Key, Column("ID", TypeName = "NUMBER(19)")]
		public long Id { get; set; }

		[Column("NAME")]
		public string Name { get; set; }

	}
}
