using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vr.Biz;
using Vr.Domain;

namespace Vr.Console
{
	class Program
	{
		static void Main(string[] args)
		{
			var biz = new RecruiterBusiness();
			//biz.AddEngineeer(new Engineer {Description = "Cool", FirstName = "Mark", LastName = "Seaman"});
			//biz.AddHiringResource(new HiringResource { Company = new Company() { CompanyName = "Browncoats" }, FirstName = "Sarvesh", LastName = "Chinnappa" });
			//biz.AddHiringResource(new HiringResource { Company = new Company() { CompanyName = "Ryan" }, FirstName = "Steve", LastName = "Veller" });
			//biz.AddSkill(new Skill { SkillName = "C#" });
			//biz.AddSkill(new Skill { SkillName = "javascript" });
			//biz.AddSkill(new Skill { SkillName = "TypeScript" });
			//biz.AddSkill(new Skill { SkillName = "SQL" });
			//biz.AddSkill(new Skill { SkillName = "Angular" });
			//biz.AddSkillsToEngineer(1, new List<int> {1, 2, 3, 4, 5 });

			var mark = biz.GetEngineerDetails(1);
		}
	}
}
