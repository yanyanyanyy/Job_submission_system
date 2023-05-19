using JobSubmissionSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace JobSubmissionSystem.Data
{
    public partial class ParameterContext : DbContext
    {
        public ParameterContext()
        {
        }

        public ParameterContext(DbContextOptions<ParameterContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Parameter> Parameter { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8_general_ci")
                .HasCharSet("utf8");

            //public int Id { get; set; }
            //public string UserName { get; set; } = null!;
            //public string PassWord { get; set; } = null!;
            //public string DepartmentName { get; set; } = null!;


            modelBuilder.Entity<Parameter>(entity =>
            {
                entity.ToTable("Parameter_Table");
                entity.Property(e => e.Swith)
                    .HasMaxLength(200)
                    .HasColumnName("swith");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }


}
