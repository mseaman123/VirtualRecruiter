using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vr.Data;
using Vr.Domain;

namespace Vr.Biz
{
    public class RecruiterBusiness : IRecruiterBusiness
    {
	    private readonly RecruiterContext _context;
		public RecruiterBusiness(RecruiterContext context)
		{
			_context = context;
		}

		public IEnumerable<Engineer> GetAllEngineers()
		{
			var engineers =
				(from e in _context.People.AsNoTracking().OfType<Engineer>()
					select e).ToList();

			return engineers;
		}

		public Engineer GetEngineerDetails(int id)
		{
			var engineer =
				(from e in _context.People.AsNoTracking().OfType<Engineer>().Include("Skills")
					where e.PersonId == id
					select e).FirstOrDefault();

			return engineer;
		}

		public Engineer UpdateEngineer(Engineer engineer)
		{
			_context.People.AddOrUpdate(engineer);
			_context.SaveChanges();

			return engineer;
		}

	    public void DeleteEngineer(int id)
	    {
		    var engineer =
			    (from e in _context.People.OfType<Engineer>()
				    where e.PersonId == id
				    select e).FirstOrDefault();

			_context.People.Remove(engineer);
			_context.SaveChanges();
		}

		#region "Add methods"
		public void AddEngineeer(Engineer engineer)
		{
			_context.People.Add(engineer);
			_context.SaveChanges();
		}

		public void AddHiringResource(HiringResource hr)
		{
			_context.People.Add(hr);
			_context.SaveChanges();
		}

		public void AddSkill(Skill skill)
		{
			_context.Skills.Add(skill);
			_context.SaveChanges();
		}

		public void AddSkillsToEngineer(int engineerId, IList<int> skillIds)
		{
			Engineer eng = _context.People.AsNoTracking().OfType<Engineer>().FirstOrDefault(p => p.PersonId == engineerId);

			var skills = _context.Skills.Where(s => skillIds.Contains(s.SkillId));

			eng?.Skills.AddRange(skills);
			_context.SaveChanges();
		}
		#endregion
	}
}
