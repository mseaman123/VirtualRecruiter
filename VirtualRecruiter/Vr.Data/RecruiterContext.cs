using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vr.Domain;

namespace Vr.Data
{
    public class RecruiterContext : DbContext
    {

		public DbSet<Person> People { get; set; }
		public DbSet<Company> Companies { get; set; }
		public DbSet<Skill> Skills { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			Database.SetInitializer<RecruiterContext>(null);
			base.OnModelCreating(modelBuilder);

			//modelBuilder.Properties()
			//	.Where(p => p.Name == "Id")
			//	.Configure(p => p.IsKey().HasColumnName(p.ClrPropertyInfo.ReflectedType?.Name + "Id"));

			modelBuilder.Entity<Engineer>()
				 .HasMany(u => u.Skills)
				 .WithMany(l => l.Engineers)
				 .Map(ul =>
				 {
					 ul.MapLeftKey("PersonId");
					 ul.MapRightKey("SkillId");
					 ul.ToTable("EngineerSkills");
				 });
		}
	}
}
