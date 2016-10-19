using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Vr.Domain
{
	public class Skill
	{
		public int SkillId { get; set; }

		[Required]
		public string SkillName { get; set; }
		//public int? Rating { get; set; }

		public ICollection<Engineer> Engineers { get; set; }
		public ICollection<HiringResource> HiringResources { get; set; }
	}
}
