
using Project.DataAcessLayer.Data.Configruations;
using Project.DataAcessLayer.Models.DepartmentModels;

namespace Project.DAL.Data.Configruations
{
    public class DeparmentConfigruations :BaseEntityConfigruations<Department> , IEntityTypeConfiguration<Department>
    {
        public new void Configure(EntityTypeBuilder<Department> builder)
        {
          builder.Property(d => d.Id).UseIdentityColumn(10, 10);
          builder.Property(d => d.Name).IsRequired().HasColumnType("varchar(25)");
          builder.Property(d => d.Code).IsRequired().HasColumnType("varchar(25)");
          builder.Property(d => d.Description).HasColumnType("varchar(100)");
          builder.HasMany(d => d.Employees)
                 .WithOne(e => e.Department)
                 .HasForeignKey(e => e.DepartmentId)
                 .OnDelete(DeleteBehavior.SetNull);

           


            base.Configure(builder);

        }
    }
}
