using System.Collections.Generic;

namespace Vr.Domain
{
	public class HiringResource : Person
	{
		public HiringResource()
		{
			SkillsNeeded = new List<Skill>();
		}
		public int CompanyId { get; set; }
		public Company Company { get; set; }

		public List<Skill> SkillsNeeded { get; set; }
	}
}
