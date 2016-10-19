using System.Collections.Generic;
using Vr.Domain;

namespace Vr.Biz
{
	public interface IRecruiterBusiness
	{
		IEnumerable<Engineer> GetAllEngineers();
		Engineer GetEngineerDetails(int id);
		Engineer UpdateEngineer(Engineer engineer);
		void DeleteEngineer(int id);
		void AddEngineeer(Engineer engineer);
		void AddHiringResource(HiringResource hr);
		void AddSkill(Skill skill);
		void AddSkillsToEngineer(int engineerId, IList<int> skillIds);
	}
}