using System.ComponentModel.DataAnnotations;

namespace Vr.Domain
{
	public abstract class Person
    {
		public int PersonId { get; set; }

		[Required]
		public string FirstName { get; set; }

		[Required]
		public string LastName { get; set; }
    }
}
