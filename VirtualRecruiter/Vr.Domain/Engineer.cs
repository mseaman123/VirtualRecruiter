using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Vr.Domain
{
	public class Engineer : Person
	{
		public Engineer()
		{
			Skills = new List<Skill>();
		}

		[Required]
		public string Description { get; set; }

		public List<Skill> Skills { get; set; }
	}
}
