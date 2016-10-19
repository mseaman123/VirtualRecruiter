using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vr.Data;
using Vr.Domain;

namespace Vr.Biz
{
    public class RecruiterBusiness
    {
	    public Engineer GetEngineerDetails(int id)
	    {
		    using (var context = new RecruiterContext())
		    {
			    var engineer =
				    (from e in context.People.OfType<Engineer>().Include("Skills")
					    where e.PersonId == id
					    select e).FirstOrDefault();

				return engineer;
		    }
	    }

		#region "Add methods"
		public void AddEngineeer(Engineer engineer)
		{
			using (var context = new RecruiterContext())
			{
				context.People.Add(engineer);
				context.SaveChanges();
			}
		}

		public void AddHiringResource(HiringResource hr)
		{
			using (var context = new RecruiterContext())
			{
				context.People.Add(hr);
				context.SaveChanges();
			}
		}

		public void AddSkill(Skill skill)
		{
			using (var context = new RecruiterContext())
			{
				context.Skills.Add(skill);
				context.SaveChanges();
			}
		}

		public void AddSkillsToEngineer(int engineerId, IList<int> skillIds)
		{
			using (var context = new RecruiterContext())
			{
				Engineer eng = context.People.OfType<Engineer>().FirstOrDefault(p => p.PersonId == engineerId);

				var skills = context.Skills.Where(s => skillIds.Contains(s.SkillId));

				eng?.Skills.AddRange(skills);
				context.SaveChanges();
			}
		}
		#endregion
	}
}
