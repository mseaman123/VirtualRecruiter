using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vr.Domain
{
	public class Company
	{
		public int CompanyId { get; set; }

		[Required]
		public string CompanyName { get; set; }
	}
}
